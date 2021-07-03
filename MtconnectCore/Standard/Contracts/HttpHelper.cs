using MtconnectCore.Standard.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Contracts
{
    public static partial class HttpHelper
    {
        public static async Task<XmlDocument> QueryAsync(Uri uri)
        {
            XmlDocument response = null;
            try
            {
                Logger.Debug("Sending request to MTConnect Agent:\t{AgentRequestUrl}", null, uri);
                System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);

                //req.Timeout = 1000 * 60 * 10;
                System.Net.WebResponse res = await req.GetResponseAsync();
                Stream responseStream = res.GetResponseStream();

                if (responseStream != null)
                {
                    Logger.Debug("\tConnected to {AgentRequestUrl}", null, uri);
                    response = new XmlDocument();
                    response.Load(responseStream);
                    responseStream.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to get MTConnect Machine Query");
            }
            return response;
        }

        public static async Task<XmlDocument> QueryAsync(string protocol, string ip, string port, RequestTypes mtconnectRequestType, Dictionary<string, string> query = null)
        {
            string reqstr = $"{protocol}://{ip}:{port}/{mtconnectRequestType.ToString().ToLower()}";
            if (query != null && query.Any())
            {
                reqstr += "?" + string.Join("&", query.Select(o => $"{o.Key}={o.Value}").ToArray());
            }
            Uri uri = new Uri(reqstr);
            return await QueryAsync(uri);
        }

        public static async Task<Stream> QueryIntervalAsync(Uri uri, int interval)
        {
            if (interval <= 0)
            {
                throw new ArgumentOutOfRangeException($"Interval MUST be a positive integer greater than zero (0)");
            }
            if (!uri.PathAndQuery.Contains("interval=")) {
                if (string.IsNullOrEmpty(uri.Query)) {
                    uri = new Uri($"{uri}?interval={interval}");
                } else {
                    uri = new Uri($"{uri}&interval={interval}");
                }
            }

            Logger.Debug("Sending request to MTConnect Agent:\t{AgentRequestUrl}", null, uri);
            System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);

            //req.Timeout = 1000 * 60 * 10;
            System.Net.WebResponse res = await req.GetResponseAsync();
            Stream responseStream = res.GetResponseStream();

            return responseStream;
        }

        public static async Task<Stream> QueryIntervalAsync(string protocol, string ip, string port, RequestTypes mtconnectRequestType, int interval, Dictionary<string, string> query = null)
        {

            string reqstr = $"{protocol}://{ip}:{port}/{mtconnectRequestType.ToString().ToLower()}?interval={interval}";
            if (query?.Any() == true)
            {
                reqstr += string.Join("&", query.Select(o => $"{o.Key}={o.Value}").ToArray());
            }
            Uri uri = new Uri(reqstr);
            return await QueryIntervalAsync(uri, interval);
        }

    }
}
