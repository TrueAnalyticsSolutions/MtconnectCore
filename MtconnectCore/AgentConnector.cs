using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Standard.Documents;
using MtconnectCore.Standard.Documents.Devices;
using MtconnectCore.Standard.Documents.Error;
using MtconnectCore.Standard.Documents.Streams;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore
{
    /// <summary>
    /// An asynchronous callback method to call when an interval request receives a complete MTConnect document.
    /// </summary>
    /// <param name="document"></param>
    /// <returns></returns>
    public delegate Task MtconnectIntervalStreamCallback(IMtconnectDocument document);

    /// <summary>
    /// Provides methods for connecting and querying a MTConnect Agent.
    /// </summary>
    public static class AgentConnector
    {
        public static async Task<IMtconnectDocument> QueryAsync(Uri uri)
        {
            XmlDocument xDoc = await HttpHelper.QueryAsync(uri);
            if (xDoc == null)
            {
                MtconnectProbeFailure connectionFailure = new MtconnectProbeFailure($"Failure to fetch MTConnect Document from {uri}");
                Logger.Error(connectionFailure);
                throw connectionFailure;
            }

            if (TryParse(xDoc, out IMtconnectDocument mtconnectDocument))
            {
                return mtconnectDocument;
            }
            Exception exception = new Exception("Failed to parse Xml into a MTConnect Document");
            Logger.Error(exception);
            throw exception;
        }

        public static async Task<IMtconnectDocument> QueryAsync(string protocol, string ip, int port, RequestTypes mtconnectRequestType, Dictionary<string, string> parameters = null)
        {
            string reqstr = $"{protocol}://{ip}:{port}/{mtconnectRequestType.ToString().ToLower()}";
            if (parameters?.Any() == true)
            {
                reqstr += "?" + string.Join("&", parameters.Select(o => $"{o.Key}={o.Value}"));
            }
            Uri uri = new Uri(reqstr);
            return await QueryAsync(uri);
        }

        /// <summary>
        /// Tries to parse a <see cref="XmlDocument"/> into the appropriate <see cref="IMtconnectDocument"/> based on the MTConnect standard.
        /// </summary>
        /// <param name="xDoc">The available <see cref="XmlDocument"/> to be parsed</param>
        /// <param name="document">Output of the appropriately formated <see cref="IMtconnectDocument"/> type. Note that this document could result in a <see cref="MtconnectErrorDocument"/>.</param>
        /// <returns>Flag for whether or not the <see cref="XmlDocument"/> could be identified as an implemented <see cref="IMtconnectDocument"/>.</returns>
        public static bool TryParse(XmlDocument xDoc, out IMtconnectDocument document)
        {
            document = null;
            string rootNodeName = xDoc.DocumentElement.LocalName;
            switch (rootNodeName)
            {
                case "MTConnectStreams":
                    document = new StreamsDocument(xDoc);
                    break;
                case "MTConnectError":
                    document = new ErrorDocument(xDoc);
                    break;
                case "MTConnectAssets":
                    throw new NotSupportedException($"MTConnect Assets is not supported at this time.");
                    break;
                case "MTConnectDevices":
                    document = new DevicesDocument(xDoc);
                    break;
                default:
                    throw new NotSupportedException($"Unknown MTConnect document is not supported.");
                    break;
            }
            return document != null;
        }

        public static async Task QueryStreamAsync(Uri uri, int interval, MtconnectIntervalStreamCallback callback, CancellationToken cancelToken)
        {
            if (!uri.Query.ToLower().Contains("interval")) {
                uri = new Uri($"{uri}{(string.IsNullOrEmpty(uri.Query) ? "?" : "&")}interval={interval}");
            }
            System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);

            using (System.Net.WebResponse res = req.GetResponse())
            using (Stream responseStream = res.GetResponseStream())
            {
                // Set timeout to 150% of expected stream interval
                try
                {
                    responseStream.ReadTimeout = (int)Math.Ceiling(interval * 1.5);
                }
                catch (InvalidOperationException ioException)
                {
                    // Do nothing
                }

                byte[] data = new byte[4096];

                // These are used to determine when a document in the stream start and stops
                byte[] start = Encoding.UTF8.GetBytes("<?xml");
                byte[] end = Encoding.UTF8.GetBytes("</MTConnectStreams>");

                int read;

                // Open memory stream to temporarily hold the incoming document from the HTTP stream
                MemoryStream memory = new MemoryStream();
                while ((read = responseStream.Read(data, 0, data.Length)) > 0 && !cancelToken.IsCancellationRequested)
                {
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

                            if (TryParse(xDoc, out IMtconnectDocument mtcDoc))
                            {
                                callback(mtcDoc);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex);
                            throw ex;
                        }
                        finally
                        {
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
        }

        /// <summary>
        /// Opens a constant connection to a MTConnect document stream from the provided <paramref name="requestType"/> and MTConnect Agent URI.
        /// </summary>
        /// <param name="protocol">URI protocol of the MTConnect Agent</param>
        /// <param name="ip">URI host of the MTConnect Agent</param>
        /// <param name="port">URI port of the MTConnect Agent</param>
        /// <param name="interval">Interval parameter as outlined in the MTConnect standard (Part 1)</param>
        /// <param name="requestType">Type of request per the MTConnect standard (Part 1)</param>
        /// <param name="callback">Method to be called when an <see cref="IMtconnectDocument"/> is parsed from the stream</param>
        /// <param name="cancelToken">Reference to a cancellation token to break constant stream</param>
        /// <param name="parameters">Optional query parameters to include in URI</param>
        /// <returns>Asyncronous task while the HTTP stream remains open</returns>
        public static async Task QueryStreamAsync(string protocol, string ip, int port, int interval, RequestTypes requestType, MtconnectIntervalStreamCallback callback, CancellationToken cancelToken, Dictionary<string, string> parameters = null)
        {
            string reqstr = $"{protocol}://{ip}:{port}/{requestType.ToString().ToLower()}?interval={interval}";
            if (parameters?.Any() == true)
            {
                reqstr += "&" + string.Join("&", parameters.Select(o => $"{o.Key}={o.Value}"));
            }
            Uri uri = new Uri(reqstr);
            await QueryStreamAsync(uri, interval, callback, cancelToken);
        }

        static private T[] CopyAndResize<T>(T[] sourceArray, long sourceIndex, long length)
        {
            T[] newArray = new T[length];
            Array.Copy(sourceArray, sourceIndex, newArray, 0, length);
            return newArray;
        }
        static private IEnumerable<int> SearchBytePattern(byte[] pattern, byte[] bytes)
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
    }
}
