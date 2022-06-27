using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Standard.Documents;
using MtcAssets = MtconnectCore.Standard.Documents.Assets;
using MtcDevices = MtconnectCore.Standard.Documents.Devices;
using MtcError = MtconnectCore.Standard.Documents.Error;
using MtcStreams = MtconnectCore.Standard.Documents.Streams;
using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using MtconnectCore.Standard;
using System.Threading;
using static MtconnectCore.Logging.MtconnectCoreLogger;
using System.Net.Http;
using System.Net.Sockets;

namespace MtconnectCore
{
    /// <summary>
    /// An asynchronous callback method to call when an interval request receives a complete MTConnect Response Document.
    /// </summary>
    /// <param name="document">A MTConnect Response Document in its generic form. This is because the document responding document could be a <see cref="MtcError.ErrorDocument"/>.</param>
    /// <returns></returns>
    public delegate Task MtconnectIntervalStreamCallback(IResponseDocument document);

    /// <summary>
    /// A HTTP service that standardizes the requests that can be made to a MTConnect Agent according to the MTConnect specification.
    /// </summary>
    public partial class MtconnectAgentService : IDisposable
    {
        /// <summary>
        /// Reference to the underlying HTTP Client that sends requests to the MTConnect Agent
        /// </summary>
        public HttpClient Client { get; }

        /// <summary>
        /// Constructs a new <see cref="MtconnectAgentService"/> with an existing <see cref="HttpClient"/>. Note that the <see cref="HttpClient.Timeout"/> is overwritten during construction with <see cref="Timeout.Infinite"/> to accomodate MTConnect Interval request(s). This can be overwritten again after construction, but is reset to <see cref="Timeout.Infinite"/> each time an Interval request is executed.
        /// </summary>
        /// <param name="client">Reference to an existing <see cref="HttpClient"/>.</param>
        /// <param name="uri">Reference to the <see cref="HttpClient.BaseAddress"/> that should be set for requests to the MTConnect Agent.</param>
        public MtconnectAgentService(HttpClient client, Uri uri)
        {
            Client = client;
            Client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
            Client.BaseAddress = uri;
            Client.DefaultRequestHeaders.Add("Accept", "application/xml");
        }

        /// <summary>
        /// Constructs a new <see cref="MtconnectAgentService"/>.
        /// </summary>
        /// <param name="uri"><inheritdoc cref="MtconnectAgentService.MtconnectAgentService(HttpClient, Uri)" path="/param[@name='uri']"/></param>
        public MtconnectAgentService(Uri uri) : this(new HttpClient(), uri) { }

        /// <summary>
        /// Tries to parse a <see cref="XmlDocument"/> into the appropriate <see cref="IResponseDocument"/> based on the MTConnect standard.
        /// </summary>
        /// <param name="xDoc">The available <see cref="XmlDocument"/> to be parsed</param>
        /// <param name="document">Output of the appropriately formated <see cref="IResponseDocument"/> type. Note that this document could result in a <see cref="MtconnectErrorDocument"/>.</param>
        /// <returns>Flag for whether or not the <see cref="XmlDocument"/> could be identified as an implemented <see cref="IResponseDocument"/>.</returns>
        public static bool TryParse(XmlDocument xDoc, out IResponseDocument document)
        {
            document = null;
            string rootNodeName = xDoc.DocumentElement.LocalName;
            switch (rootNodeName)
            {
                case "MTConnectStreams":
                    document = new MtcStreams.StreamsDocument(xDoc);
                    break;
                case "MTConnectError":
                    document = new MtcError.ErrorDocument(xDoc);
                    break;
                case "MTConnectAssets":
                    document = new MtcAssets.AssetsDocument(xDoc);
                    break;
                case "MTConnectDevices":
                    document = new MtcDevices.DevicesDocument(xDoc);
                    break;
                default:
                    throw new NotSupportedException($"Unknown MTConnect document is not supported.");
                    break;
            }
            return document != null;
        }

        internal async Task<T> Request<T>(string request) where T : IResponseDocument
        {
            using (HttpResponseMessage res = await Client.GetAsync(request))
            {
                using (var responseStream = await res.Content.ReadAsStreamAsync())
                {
                    if (responseStream == null)
                        throw new NullReferenceException("No content returned from stream response.");

                    XmlDocument response = new XmlDocument();
                    response.Load(responseStream);
                    responseStream.Close();

                    IResponseDocument mtcDocument;
                    if (!TryParse(response, out mtcDocument))
                        throw new MtconnectProbeFailure($"Failed to parse MTConnect Response Document");

                    if (!(mtcDocument is T))
                        throw new Exception($"Expected {typeof(T)} and received {mtcDocument.Type} instead.");

                    return (T)mtcDocument;
                }
            }
        }

        internal async Task RequestInterval(string request, MtconnectIntervalStreamCallback callback, CancellationToken cancelToken)
        {
            Client.CancelPendingRequests();
            Client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
            using (var httpRequest = new HttpRequestMessage(HttpMethod.Get, request))
            using (HttpResponseMessage httpResponse = await Client.SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead))
            using (Stream responseStream = await httpResponse.Content.ReadAsStreamAsync())
            {
                byte[] data = new byte[4096];

                // These are used to determine when a document in the stream start and stops
                byte[] start = Encoding.UTF8.GetBytes("<?xml");
                byte[] end = Encoding.UTF8.GetBytes("</MTConnectStreams>");

                int read;

                // Open memory stream to temporarily hold the incoming document from the HTTP stream
                MemoryStream memory = new MemoryStream();
                bool endOfStream = false;
                try
                {
                    while (!endOfStream && !cancelToken.IsCancellationRequested)
                    {
                        if (responseStream.CanSeek)
                        {
                            endOfStream = responseStream.Position == (responseStream.Length - 1);
                        }

                        read = responseStream.Read(data, 0, data.Length);

                        // Fill the byte sequence with what was just read in the 'while'
                        byte[] remainder = CopyAndResize(data, 0, read);

                        // Search for the 'start' sequence in the current byte sequence
                        IEnumerable<int> startLocations = SearchBytePattern(start, remainder);
                        if (startLocations.Any())
                        {
                            // Re-initialize the memory stream to hold the incoming Xml document
                            memory = new MemoryStream();
                            // Get location of the start of the 'start' sequence
                            int startLocation = startLocations.First();
                            // Write the contents of the byte sequence starting at the start location
                            // NOTE: This may be too much sent into the document memory stream because it's possible the document is within this request as well.
                            memory.Write(remainder, startLocation, remainder.Length - startLocation);
                            // Reset current byte sequence
                            remainder = new byte[0];
                        }

                        // Search for the 'end' sequence in the current byte sequence
                        IEnumerable<int> endLocations = SearchBytePattern(end, remainder);
                        if (endLocations.Any())
                        {
                            // Get location of the start of the 'end' sequence
                            int endLocation = endLocations.First();
                            // Write the contents of the byte sequence starting from the beginning until the end of the 'end' sequence
                            memory.Write(remainder, 0, endLocation + end.Length);
                            // Re-initialize the remaining byte sequence after the 'end' sequence
                            remainder = CopyAndResize(remainder, endLocation + end.Length, remainder.Length - (endLocation + end.Length));

                            // Now that we have a full Xml document, we can invoke the callback
                            try
                            {
                                // Get the raw Xml contents from the memory stream
                                string rawXml = Encoding.UTF8.GetString(memory.ToArray());
                                XmlDocument xDoc = new XmlDocument();
                                // Load the raw Xml into a document to be parsed into an IMtconnectDocument
                                xDoc.LoadXml(rawXml);

                                if (TryParse(xDoc, out IResponseDocument mtcDoc))
                                {
                                    await callback(mtcDoc);
                                }
                                else
                                {
                                    throw new InvalidCastException("Response was not valid MTConnect Response Document.");
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Error(ex);
                                throw ex;
                            }
                            finally
                            {
                                memory.Close();
                                memory.Dispose();
                                // Re-initialize the memory stream to hold the incoming Xml document
                                memory = new MemoryStream();
                            }
                        }

                        // If anything remains in the current byte sequence, then add it to the memory stream
                        if (remainder.Length > 0)
                        {
                            memory.Write(remainder, 0, remainder.Length);
                        }
                    }
                }
                finally
                {
                    httpResponse.Dispose();
                    if (memory != null)
                    {
                        memory.Close();
                        memory.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// Sends a Probe Request to the MTConnect Agent. See Part 1 Section 8.3.1 of MTConnect specification.
        /// </summary>
        /// <param name="equipmentId">If present, specifies that only the Equipment Metadata for the piece of equipment represented by the name or uuid will be published. See Part 1 Section 8.3.1.1 of MTConnect specification.</param>
        /// <returns>A generic reference to a <see cref="IResponseDocument"/> in case the unexpected, but handlable <see cref="MtcError.ErrorDocument"/> is returned from the MTConnect Agent.</returns>
        public async Task<IResponseDocument> Probe(string equipmentId = "")
        {
            string request = string.Empty;
            if (!string.IsNullOrEmpty(equipmentId)) {
                request = $"{equipmentId}/";
            }
            request += RequestTypes.PROBE.ToString().ToLower();

            return await Request<MtcDevices.DevicesDocument>(request);
        }

        /// <summary>
        /// Sends a Current Request to the MTConnect Agent. See Part 1 Section 8.3.2 of MTConnect specification.
        /// </summary>
        /// <param name="equipmentId">If present, specifies that only the Equipment Metadata for the piece of equipment represented by the name or uuid will be published. See Part 1 Section 8.3.2.1 of MTConnect specification.</param>
        /// <param name="query">If present, specifies various query parameters to precisely define the specific information to be included in the response document. See Part 1 Section 8.3.2.2 of MTConnect specification.</param>
        /// <returns><inheritdoc cref="Probe" path="/returns"/></returns>
        public async Task<IResponseDocument> Current(string equipmentId = "", CurrentRequestQuery query = null)
        {
            string request = string.Empty;
            if (!string.IsNullOrEmpty(equipmentId)) {
                request = $"{equipmentId}/";
            }
            request += RequestTypes.CURRENT.ToString().ToLower();
            Exception queryException = null;
            if (query?.Validate(out queryException) == true) {
                if (query?.Interval != null) {
                    throw new InvalidOperationException($"The {nameof(Current)} request should not be made with the '{nameof(CurrentRequestQuery.Interval)}' query parameter included. Instead, use {nameof(CurrentInterval)}.");
                }
                request += $"?{query}";
            } else if (queryException != null) {
                throw queryException;
            }

            return await Request<MtcStreams.StreamsDocument>(request);
        }

        /// <summary>
        /// Sends a Current Request in the form of a HTTP Data Streaming request or Publish/Subscribe. See Part 1 Section 8.3.6 of MTConnect specification.
        /// </summary>
        /// <param name="callback">An asynchronous callback method to call when an interval request receives a complete MTConnect document.</param>
        /// <param name="cancelToken">A token for cancelling the loop that keeps the HTTP Data Stream open.</param>
        /// <param name="equipmentId">If present, specifies that only the Equipment Metadata for the piece of equipment represented by the name or uuid will be published. See Part 1 Section 8.3.2.1 of MTConnect specification.</param>
        /// <param name="query">If present, specifies various query parameters to precisely define the specific information to be included in the response document. See Part 1 Section 8.3.2.2 of MTConnect specification.</param>
        /// <returns></returns>
        public async Task CurrentInterval(MtconnectIntervalStreamCallback callback, CancellationToken cancelToken, string equipmentId = "", CurrentRequestQuery query = null)
        {
            if (query?.Interval == null) {
                throw new ArgumentNullException("'Interval' parameter cannot be null when requesting an stream Response Document.");
            }

            string request = string.Empty;
            if (!string.IsNullOrEmpty(equipmentId))
            {
                request = $"{equipmentId}/";
            }
            request += RequestTypes.CURRENT.ToString().ToLower();
            Exception queryException = null;
            if (query?.Validate(out queryException) == true)
            {
                request += $"?{query}";
            }
            else if (queryException != null)
            {
                throw queryException;
            }

            await RequestInterval(request, callback, cancelToken);
        }

        /// <summary>
        /// Sends a Sample Request to the MTConnect Agent. See Part 1 Section 8.3.3 of MTConnect specification.
        /// </summary>
        /// <param name="equipmentId">If present, specifies that only the Equipment Metadata for the piece of equipment represented by the name or uuid will be published. See Part 1 Section 8.3.3.1 of MTConnect specification.</param>
        /// <param name="query">If present, specifies various query parameters to precisely define the specific information to be included in the response document. See Part 1 Section 8.3.3.2 of MTConnect specification.</param>
        /// <returns><inheritdoc cref="Probe" path="/returns"/></returns>
        public async Task<IResponseDocument> Sample(string equipmentId = "", SampleRequestQuery query = null)
        {
            string request = string.Empty;
            if (!string.IsNullOrEmpty(equipmentId))
            {
                request = $"{equipmentId}/";
            }
            request += RequestTypes.SAMPLE.ToString().ToLower();
            Exception queryException = null;
            if (query?.Validate(out queryException) == true)
            {
                if (query?.Interval != null)
                {
                    throw new InvalidOperationException($"The {nameof(Sample)} request should not be made with the '{nameof(SampleRequestQuery.Interval)}' query parameter included. Instead, use {nameof(SampleInterval)}.");
                }
                request += $"?{query}";
            }
            else if (queryException != null)
            {
                throw queryException;
            }

            return await Request<IResponseDocument>(request);
        }

        /// <summary>
        /// Sends a Sample Request in the form of a HTTP Data Streaming request or Publish/Subscribe. See Part 1 Section 8.3.6 of MTConnect specification.
        /// </summary>
        /// <param name="callback">An asynchronous callback method to call when an interval request receives a complete MTConnect document.</param>
        /// <param name="cancelToken">A token for cancelling the loop that keeps the HTTP Data Stream open.</param>
        /// <param name="equipmentId">If present, specifies that only the Equipment Metadata for the piece of equipment represented by the name or uuid will be published. See Part 1 Section 8.3.3.1 of MTConnect specification.</param>
        /// <param name="query">If present, specifies various query parameters to precisely define the specific information to be included in the response document. See Part 1 Section 8.3.3.2 of MTConnect specification.</param>
        /// <returns></returns>
        public async Task SampleInterval(MtconnectIntervalStreamCallback callback, CancellationToken cancelToken, string equipmentId = "", SampleRequestQuery query = null)
        {
            if (query?.Interval == null)
            {
                throw new ArgumentNullException("'Interval' parameter cannot be null when requesting an stream Response Document.");
            }

            string request = string.Empty;
            if (!string.IsNullOrEmpty(equipmentId))
            {
                request = $"{equipmentId}/";
            }
            request += RequestTypes.SAMPLE.ToString().ToLower();
            Exception queryException = null;
            if (query?.Validate(out queryException) == true)
            {
                request += $"?{query}";
            }
            else if (queryException != null)
            {
                throw queryException;
            }

            await RequestInterval(request, callback, cancelToken);
        }

        /// <summary>
        /// Sends an Assets Request to the MTConnect Agent.
        /// </summary>
        /// <param name="query">If present, specifies various query parameters to precisely define the specific information to be included in the response document.</param>
        /// <returns><inheritdoc cref="Probe" path="/returns"/></returns>
        public async Task<IResponseDocument> Assets(AssetRequestQuery query = null)
        {
            string request = string.Empty;
            request += RequestTypes.ASSETS.ToString().ToLower();
            Exception queryException = null;
            if (query?.Validate(out queryException) == true)
            {
                if (string.IsNullOrEmpty(query?.Type))
                {
                    //throw new InvalidOperationException($"The {nameof(Asset)} request should not be made with the '{nameof(AssetRequestQuery.Type)}' query parameter included. Instead, use {nameof(SampleInterval)}.");
                }
                request += $"?{query}";
            }
            else if (queryException != null)
            {
                throw queryException;
            }

            return await Request<MtcAssets.AssetsDocument>(request);
        }

        /// <summary>
        /// Sends an Asset Request to the MTConnect Agent for a specific asset by id.
        /// </summary>
        /// <param name="assetId">Reference to a specific Asset ID.</param>
        /// <param name="query">If present, specifies various query parameters to precisely define the specific information to be included in the response document.</param>
        /// <returns><inheritdoc cref="Probe" path="/returns"/></returns>
        public async Task<IResponseDocument> Asset(string assetId = "", AssetRequestQuery query = null)
        {
            string request = string.Empty;
            if (!string.IsNullOrEmpty(assetId))
            {
                request = $"{assetId}/";
            }
            request += RequestTypes.ASSET.ToString().ToLower();
            Exception queryException = null;
            if (query?.Validate(out queryException) == true)
            {
                if (string.IsNullOrEmpty(query?.Type))
                {
                    //throw new InvalidOperationException($"The {nameof(Asset)} request should not be made with the '{nameof(AssetRequestQuery.Type)}' query parameter included. Instead, use {nameof(SampleInterval)}.");
                }
                request += $"?{query}";
            }
            else if (queryException != null)
            {
                throw queryException;
            }

            return await Request<MtcAssets.AssetsDocument>(request);
        }

        /// <summary>
        /// Performs an audit on the Agent to validate the appropriate endpoints are exposed as well as the format of the Response Documents are valid according to the standard.
        /// </summary>
        /// <returns>Collection of any errors or messages received from the request and initialization of MTConnect Response Documents.</returns>
        public async Task<ICollection<MtconnectValidationException>> Audit()
        {
            var errors = new List<MtconnectValidationException>();
            #region Audit Probe
            var devices = await Probe();
            if (devices is MtcDevices.DevicesDocument)
            {
                if (!devices.TryValidate(out ICollection<MtconnectValidationException> devicesErrors))
                {
                    errors.AddRange(devicesErrors);
                }
            }
            else
            {
                errors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, $"MTConnect Agent MUST provide an endpoint for 'probe' requests."));
            }
            #endregion
            #region Audit Current
            var current = await Current();
            if (current is MtcStreams.StreamsDocument)
            {
                if (!current.TryValidate(out ICollection<MtconnectValidationException> currentErrors))
                {
                    errors.AddRange(currentErrors);
                }
            }
            else
            {
                errors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, $"MTConnect Agent MUST provide an endpoint for 'current' requests."));
            }
            #endregion
            #region Audit Sample
            var sample = await Sample();
            if (sample is MtcStreams.StreamsDocument)
            {
                if (!sample.TryValidate(out ICollection<MtconnectValidationException> sampleErrors))
                {
                    errors.AddRange(sampleErrors);
                }
            }
            else
            {
                errors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, $"MTConnect Agent MUST provide an endpoint for 'sample' requests."));
            }
            #endregion
            #region Audit Assets
            var assets = await Assets();
            if (assets is MtcAssets.AssetsDocument)
            {
                if (!assets.TryValidate(out ICollection<MtconnectValidationException> assetsErrors))
                {
                    errors.AddRange(assetsErrors);
                }
            }
            else
            {
                errors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, $"MTConnect Agent MUST provide an endpoint for 'assets' requests."));
            }
            #endregion
            #region Audit Error
            var expectedError = await Request<MtcError.ErrorDocument>("error");
            if (expectedError is MtcError.ErrorDocument)
            {
                if (!expectedError.TryValidate(out ICollection<MtconnectValidationException> expectedErrorsErrors))
                {
                    errors.AddRange(expectedErrorsErrors);
                }
            }
            else
            {
                errors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, $"MTConnect Agent MUST return a MTConnect Errors Response Document in the event of an error."));
            }
            #endregion

            return errors;
        }

        private T[] CopyAndResize<T>(T[] sourceArray, long sourceIndex, long length)
        {
            T[] newArray = new T[length];
            Array.Copy(sourceArray, sourceIndex, newArray, 0, length);
            return newArray;
        }
        private IEnumerable<int> SearchBytePattern(byte[] pattern, byte[] bytes)
        {
            List<int> positions = new List<int>();
            int patternLength = pattern.Length;
            int totalLength = bytes.Length;
            byte firstMatchByte = pattern[0];
            byte[] match;
            for (int i = 0; i < totalLength; i++)
            {
                if (firstMatchByte == bytes[i] && totalLength - i >= patternLength)
                {
                    match = new byte[patternLength];
                    Array.Copy(bytes, i, match, 0, patternLength);
                    if (match.SequenceEqual<byte>(pattern))
                    {
                        positions.Add(i);
                        i += patternLength - 1;
                    }
                }
            }
            return positions;
        }
        
        /// <inheritdoc/>
        public void Dispose()
        {
            Client.Dispose();
        }
    }
}
