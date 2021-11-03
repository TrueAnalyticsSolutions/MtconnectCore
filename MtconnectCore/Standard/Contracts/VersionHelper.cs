using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Contracts
{
    public static class VersionHelper
    {
        private static Dictionary<MtconnectVersions, string> versionNames = new Dictionary<MtconnectVersions, string>() {
            { MtconnectVersions.V_1_0_1, "1.0.1" },
            { MtconnectVersions.V_1_1_0, "1.1.0" },
            { MtconnectVersions.V_1_2_0, "1.2.0" },
            { MtconnectVersions.V_1_3_0, "1.3.0" },
            { MtconnectVersions.V_1_3_1, "1.3.1" },
            { MtconnectVersions.V_1_4_0, "1.4.0" },
            { MtconnectVersions.V_1_4_1, "1.4.1" },
            { MtconnectVersions.V_1_5_0, "1.5.0" },
            { MtconnectVersions.V_1_5_1, "1.5.1" },
            { MtconnectVersions.V_1_6_0, "1.6.0" },
            { MtconnectVersions.V_1_6_1, "1.6.1" },
            { MtconnectVersions.V_1_7_0, "1.7.0" }
        };

        private static Dictionary<MtconnectVersions, DateTime> versionReleaseDate = new Dictionary<MtconnectVersions, DateTime>() {
            { MtconnectVersions.V_1_0_1, new DateTime(2009, 10, 02) },
            { MtconnectVersions.V_1_1_0, new DateTime(2010, 04, 30) },
            { MtconnectVersions.V_1_2_0, new DateTime(2012, 02, 17) },
            { MtconnectVersions.V_1_3_0, new DateTime(2014, 09, 30) },
            { MtconnectVersions.V_1_3_1, new DateTime(2015, 06, 11) },
            { MtconnectVersions.V_1_4_0, new DateTime(2018, 03, 31) },
            { MtconnectVersions.V_1_4_1, new DateTime(2018, 03, 31) },
            { MtconnectVersions.V_1_5_0, new DateTime(2019, 12, 31) },
            { MtconnectVersions.V_1_5_1, new DateTime(2019, 12, 31) },
            { MtconnectVersions.V_1_6_0, new DateTime(2020, 07, 15) },
            { MtconnectVersions.V_1_6_1, new DateTime(2020, 07, 15) },
            { MtconnectVersions.V_1_7_0, new DateTime(2021, 02, 25) },
        };

        private static Dictionary<MtconnectVersions, MtconnectVersions?> versionMinimumVersion = new Dictionary<MtconnectVersions, MtconnectVersions?>() {
             { MtconnectVersions.V_1_0_1, null },
             { MtconnectVersions.V_1_1_0, null },
             { MtconnectVersions.V_1_2_0, null },
             { MtconnectVersions.V_1_3_0, MtconnectVersions.V_1_1_0 },
             { MtconnectVersions.V_1_3_1, null }, // Missing vc:minVersion??? See https://github.com/mtconnect/schema/issues/10
             { MtconnectVersions.V_1_4_0, MtconnectVersions.V_1_1_0 },
             { MtconnectVersions.V_1_4_1, null }, // Missing vc:minVersion??? See https://github.com/mtconnect/schema/issues/10
             { MtconnectVersions.V_1_5_0, MtconnectVersions.V_1_1_0 },
             { MtconnectVersions.V_1_5_1, null }, // Missing vc:minVersion??? See https://github.com/mtconnect/schema/issues/10
             { MtconnectVersions.V_1_6_0, MtconnectVersions.V_1_1_0 },
             { MtconnectVersions.V_1_7_0, MtconnectVersions.V_1_1_0 }
        };

        public static string ToName(this MtconnectVersions version) => versionNames[version];

        public static MtconnectVersions? GetVersion(string version) => versionNames.Where(o => version.Contains(o.Value) || o.Value.Contains(version)).Select(o => o.Key).FirstOrDefault();

        public static DateTime GetReleaseDate(this MtconnectVersions version) => versionReleaseDate[version];

        public static MtconnectVersions GetVersionFromHeader(XmlDocument xDoc)
        {
            InvalidMtconnectVersionException invalidVersionError;
            // Try to get the MTConnect Version and set the appropriate namespace table
            XmlNode xHeader = xDoc?.ChildNodes[1]?.ChildNodes[0];
            if (xHeader != null)
            {
                string strMtconnectVersion = xHeader.Attributes["version"]?.Value;
                var mtconnectVersion = GetVersion(strMtconnectVersion);
                if (mtconnectVersion.HasValue)
                {
                    return mtconnectVersion.Value;
                }
                invalidVersionError = new InvalidMtconnectVersionException($"Could not determine appropriate MTConnect Version from '{strMtconnectVersion}'.");
                Logger.Error(invalidVersionError);
                throw invalidVersionError;
            }
            invalidVersionError = new InvalidMtconnectVersionException("Could not find Header to determine MTConnect Version.");
            Logger.Error(invalidVersionError);
            throw invalidVersionError;
        }
        public static MtconnectVersions GetVersionFromDocument(XmlDocument xDoc)
        {
            MtconnectVersions? version = null;
            Regex regVersion = new Regex(@"^urn\:mtconnect.org\:(.*?)\:(?<version>.*?)$");
            string docDefaultNamespace = xDoc.DocumentElement.GetAttribute("xmlns");
            string strDocVersion = string.Empty;
            var match = regVersion.Match(docDefaultNamespace);
            if (match.Success)
            {
                strDocVersion = match.Groups["version"].Value;
            }
            if (!string.IsNullOrEmpty(strDocVersion))
            {
                version = GetVersion(strDocVersion);
            }
            return version.GetValueOrDefault();
        }

        public static XmlNamespaceManager GetDocumentNamespaces(this MtconnectVersions version, XmlDocument xDoc, string defaultNamespace)
        {
            MtconnectVersions? docVersion = GetVersionFromDocument(xDoc);
            if (docVersion.HasValue)
            {
                if (version != docVersion)
                {
                    Logger.Debug($"The default namespace for the MTConnect document is different than what's defined in the Header. Overriding the namespace manager to match.");

                    version = docVersion.Value;
                }
            }
            else
            {
                Logger.Warn($"The default namespace for the MTConnect document does not have a recognizable version.");
            }

            var nsmgr = new XmlNamespaceManager(xDoc.NameTable);
            nsmgr.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");

            string mtconnectNamespace = xDoc.DocumentElement.LocalName;

            switch (version)
            {
                case MtconnectVersions.V_1_0_1:
                    nsmgr.AddNamespace(defaultNamespace, $"urn:mtconnect.com:{mtconnectNamespace}:1.0");
                    break;
                case MtconnectVersions.V_1_1_0:
                    nsmgr.AddNamespace(defaultNamespace, $"urn:mtconnect.org:{mtconnectNamespace}:1.1");
                    break;
                case MtconnectVersions.V_1_2_0:
                    nsmgr.AddNamespace(defaultNamespace, $"urn:mtconnect.org:{mtconnectNamespace}:1.2");
                    break;
                case MtconnectVersions.V_1_3_0:
                    nsmgr.AddNamespace(defaultNamespace, $"urn:mtconnect.org:{mtconnectNamespace}:1.3");
                    nsmgr.AddNamespace("vc", "http://www.w3.org/2007/XMLSchema-versioning");
                    break;
                case MtconnectVersions.V_1_3_1:
                    nsmgr.AddNamespace(defaultNamespace, $"urn:mtconnect.org:{mtconnectNamespace}:1.3");
                    // Missing vc:minVersion??? See https://github.com/mtconnect/schema/issues/10
                    break;
                case MtconnectVersions.V_1_4_0:
                    nsmgr.AddNamespace(defaultNamespace, $"urn:mtconnect.org:{mtconnectNamespace}:1.4");
                    nsmgr.AddNamespace("vc", "http://www.w3.org/2007/XMLSchema-versioning");
                    break;
                case MtconnectVersions.V_1_4_1:
                    nsmgr.AddNamespace(defaultNamespace, $"urn:mtconnect.org:{mtconnectNamespace}:1.4");
                    // Missing vc:minVersion??? See https://github.com/mtconnect/schema/issues/10
                    break;
                case MtconnectVersions.V_1_5_0:
                    nsmgr.AddNamespace(defaultNamespace, $"urn:mtconnect.org:{mtconnectNamespace}:1.5");
                    nsmgr.AddNamespace("vc", "http://www.w3.org/2007/XMLSchema-versioning");
                    nsmgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
                    break;
                case MtconnectVersions.V_1_5_1:
                    nsmgr.AddNamespace(defaultNamespace, $"urn:mtconnect.org:{mtconnectNamespace}:1.5");
                    // Missing vc:minVersion??? See https://github.com/mtconnect/schema/issues/10
                    nsmgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
                    break;
                case MtconnectVersions.V_1_6_0:
                    nsmgr.AddNamespace(defaultNamespace, $"urn:mtconnect.org:{mtconnectNamespace}:1.6");
                    nsmgr.AddNamespace("vc", "http://www.w3.org/2007/XMLSchema-versioning");
                    nsmgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
                    break;
                case MtconnectVersions.V_1_6_1:
                    nsmgr.AddNamespace(defaultNamespace, $"urn:mtconnect.org:{mtconnectNamespace}:1.6");
                    // Missing vc:minVersion??? See https://github.com/mtconnect/schema/issues/10
                    nsmgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
                    break;
                case MtconnectVersions.V_1_7_0:
                    nsmgr.AddNamespace(defaultNamespace, $"urn:mtconnect.org:{mtconnectNamespace}:1.7");
                    nsmgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
                    break;
                default:
                    break;
            }

            return nsmgr;
        }

        public static XmlNamespaceManager GetStreamsNamespaces(this MtconnectVersions version, XmlDocument xDoc)
        {
            MtconnectVersions? docVersion = GetVersionFromDocument(xDoc);
            if (docVersion.HasValue)
            {
                if (version != docVersion)
                {
                    Logger.Warn($"The default namespace for the MTConnect document is different than what's defined in the Header. Overriding the namespace manager to match.");

                    version = docVersion.Value;
                }
            }
            else
            {
                Logger.Warn($"The default namespace for the MTConnect document does not have a recognizable version.");
            }


            var nsmgr = new XmlNamespaceManager(xDoc.NameTable);
            nsmgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");

            switch (version)
            {
                case MtconnectVersions.V_1_0_1:
                    nsmgr.AddNamespace("m", "urn:mtconnect.com:MTConnectStreams:1.0");
                    break;
                case MtconnectVersions.V_1_1_0:
                    nsmgr.AddNamespace("m", "urn:mtconnect.org:MTConnectStreams:1.1");
                    break;
                case MtconnectVersions.V_1_2_0:
                    nsmgr.AddNamespace("m", "urn:mtconnect.org:MTConnectStreams:1.2");
                    break;
                case MtconnectVersions.V_1_3_0:
                    nsmgr.AddNamespace("m", "urn:mtconnect.org:MTConnectStreams:1.3");
                    break;
                case MtconnectVersions.V_1_3_1:
                    nsmgr.AddNamespace("m", "urn:mtconnect.org:MTConnectStreams:1.3");
                    break;
                case MtconnectVersions.V_1_4_0:
                    nsmgr.AddNamespace("m", "urn:mtconnect.org:MTConnectStreams:1.4");
                    break;
                case MtconnectVersions.V_1_4_1:
                    nsmgr.AddNamespace("m", "urn:mtconnect.org:MTConnectStreams:1.4");
                    break;
                case MtconnectVersions.V_1_5_0:
                    nsmgr.AddNamespace("m", "urn:mtconnect.org:MTConnectStreams:1.5");
                    break;
                case MtconnectVersions.V_1_5_1:
                    nsmgr.AddNamespace("m", "urn:mtconnect.org:MTConnectStreams:1.5");
                    break;
                case MtconnectVersions.V_1_6_0:
                    nsmgr.AddNamespace("m", "urn:mtconnect.org:MTConnectStreams:1.6");
                    break;
                case MtconnectVersions.V_1_6_1:
                    nsmgr.AddNamespace("m", "urn:mtconnect.org:MTConnectStreams:1.6");
                    break;
                case MtconnectVersions.V_1_7_0:
                    nsmgr.AddNamespace("m", "urn:mtconnect.org:MTConnectStreams:1.7");
                    break;
                default:
                    break;
            }

            return nsmgr;
        }
    }
}
