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
            { MtconnectVersions.V_1_7_0, "1.7.0" },
            { MtconnectVersions.V_1_7_1, "1.7.1" },
            { MtconnectVersions.V_1_8_0, "1.8.0" },
            { MtconnectVersions.V_1_8_1, "1.8.1" },
            { MtconnectVersions.V_2_0_0, "2.0.0" },
            { MtconnectVersions.V_2_0_1, "2.0.1" },
            { MtconnectVersions.V_2_1_0, "2.1.0" },
            { MtconnectVersions.V_2_1_1, "2.1.1" },
            { MtconnectVersions.V_2_2_0, "2.2.0" },
            { MtconnectVersions.V_2_2_1, "2.2.1" },
            { MtconnectVersions.V_2_3_0, "2.3.0" },
            { MtconnectVersions.V_2_3_1, "2.3.1" },
            { MtconnectVersions.V_2_4_0, "2.4.0" },
            { MtconnectVersions.V_2_4_1, "2.4.1" },
            { MtconnectVersions.V_2_5_0, "2.5.0" },
            { MtconnectVersions.V_2_5_1, "2.5.1" }
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
            { MtconnectVersions.V_1_7_1, new DateTime(2021, 02, 25) },
            { MtconnectVersions.V_1_8_0, new DateTime(2021, 09, 06) },
            { MtconnectVersions.V_1_8_1, new DateTime(2021, 09, 06) },
            { MtconnectVersions.V_2_0_0, new DateTime(2022, 05, 24) },
            { MtconnectVersions.V_2_0_1, new DateTime(2022, 05, 24) },
            { MtconnectVersions.V_2_1_0, new DateTime(2023, 01, 14) },
            { MtconnectVersions.V_2_1_1, new DateTime(2023, 01, 14) },
            { MtconnectVersions.V_2_2_0, new DateTime(2023, 07, 26) },
            { MtconnectVersions.V_2_2_1, new DateTime(2023, 07, 26) },
            { MtconnectVersions.V_2_3_0, new DateTime(2024, 02, 11) },
            { MtconnectVersions.V_2_3_1, new DateTime(2024, 02, 11) },
            { MtconnectVersions.V_2_4_0, new DateTime(2024, 07, 16) },
            { MtconnectVersions.V_2_4_1, new DateTime(2024, 07, 16) },
            { MtconnectVersions.V_2_5_0, new DateTime(2025, 01, 16) },
            { MtconnectVersions.V_2_5_1, new DateTime(2025, 01, 16) },
        };

        /// <remarks>Find this in the <c>MTConnectDevices_x.x.xsd</c> referenced at <c>/xs:schema[@vs:minVersion]</c></remarks>
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
             { MtconnectVersions.V_1_6_1, null }, // Missing vc:minVersion??? See https://github.com/mtconnect/schema/issues/10
             { MtconnectVersions.V_1_7_0, MtconnectVersions.V_1_1_0 },
             { MtconnectVersions.V_1_7_1, null },
             { MtconnectVersions.V_1_8_0, MtconnectVersions.V_1_1_0 },
             { MtconnectVersions.V_1_8_1, null },
             { MtconnectVersions.V_2_0_0, MtconnectVersions.V_1_1_0 },
             { MtconnectVersions.V_2_0_1, null },
             { MtconnectVersions.V_2_1_0, MtconnectVersions.V_1_1_0 },
             { MtconnectVersions.V_2_1_1, null },
             { MtconnectVersions.V_2_2_0, MtconnectVersions.V_1_1_0 },
             { MtconnectVersions.V_2_2_1, null },
             { MtconnectVersions.V_2_3_0, MtconnectVersions.V_1_1_0 },
             { MtconnectVersions.V_2_3_1, null },
             { MtconnectVersions.V_2_4_0, MtconnectVersions.V_1_1_0 },
             { MtconnectVersions.V_2_4_1, null },
             { MtconnectVersions.V_2_5_0, MtconnectVersions.V_1_1_0 },
             { MtconnectVersions.V_2_5_1, null },
        };

        /// <summary>
        /// Compares the Response Document version against the version specified in the attribute based on the comparison method provided.
        /// </summary>
        /// <param name="implementedVersion">Reference to the version of MTConnect implemented in the Response Document.</param>
        /// <returns>Flag for whether the MTConnect Response Document version matches with the specified <see cref="MinimumVersion"/> according to the <see cref="ComparisonType"/>.</returns>
        public static VersionComparisonTypes Compare(MtconnectVersions implementedVersion, MtconnectVersions introduced, MtconnectVersions? deprecated = null)
        {
            if (implementedVersion < introduced)
                return VersionComparisonTypes.NotImplemented;
            if (implementedVersion >= deprecated)
                return VersionComparisonTypes.Deprecated;
            return VersionComparisonTypes.Implemented;
        }

        public static string ToName(this MtconnectVersions? version) => ToName(version.GetValueOrDefault());
        public static string ToName(this MtconnectVersions version) => versionNames[version];

        /// <summary>
        /// Searches for a MTConnect version by string. Note that this expects the format of the Enum field. For example, "V_1_0_1"
        /// </summary>
        /// <param name="version">String representation of the MTConnect Version.</param>
        /// <returns></returns>
        public static MtconnectVersions? GetVersion(string version) => versionNames.Where(o => version.StartsWith(o.Value) || o.Value.StartsWith(version)).Select(o => o.Key).FirstOrDefault();

        /// <summary>
        /// Looks up the official release date of the provided version.
        /// </summary>
        /// <param name="version">Version of MTConnect</param>
        /// <returns>Official release date of the provided version.</returns>
        public static DateTime GetReleaseDate(this MtconnectVersions? version) => GetReleaseDate(version.GetValueOrDefault());
        /// <summary>
        /// Looks up the official release date of the provided version.
        /// </summary>
        /// <param name="version">Version of MTConnect</param>
        /// <returns>Official release date of the provided version.</returns>
        public static DateTime GetReleaseDate(this MtconnectVersions version) => versionReleaseDate[version];

        /// <summary>
        /// Gets the value of the <c>version</c> attribute that should be present in the <c>Header</c> element according to MTConnect.
        /// </summary>
        /// <param name="xDoc">Reference to the XML document</param>
        /// <returns>Version of MTConnect as described by the <c>version</c> attribute in the <c>Header</c></returns>
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
        /// <summary>
        /// Parses the namespaces of the XML document to determine the version of MTConnect implemented.
        /// </summary>
        /// <param name="xDoc">Reference to the XML document</param>
        /// <returns>Version of MTConnect implemented, based on the namespace definitions in the XML document. If no version could be parsed, then a default version is returned.</returns>
        public static MtconnectVersions GetVersionFromDocument(XmlDocument xDoc)
        {
            MtconnectVersions? version = null;
            string strDocVersion = string.Empty;

            // Regular expression to extract URI schema, address, Response Document type, and version number
            Regex regVersion = new Regex(@"^(?<schema>.*?)\:(?<address>.*?)\:(?<documenttype>.*?)\:(?<version>.*?)$");

            // Attempt to get the default namespace, which should follow the pattern in the regular expression.
            foreach (XmlAttribute attribute in xDoc.DocumentElement.Attributes)
            {
                // Iterate thru all namespace definitions
                if (attribute.Name.StartsWith("xmlns"))
                {
                    string @namespace = attribute.Value;
                    // See if value matches expected format
                    var match = regVersion.Match(@namespace);
                    if (match.Success)
                    {
                        // Determine if the namespace name is a proper MTConnect Response Document
                        const string MTCONNECT = "MTConnect";
                        string strDocumentType = match.Groups["documenttype"].Value;
                        if (strDocumentType.StartsWith(MTCONNECT, StringComparison.OrdinalIgnoreCase)
                            && Enum.TryParse<DocumentTypes>(strDocumentType.Substring(MTCONNECT.Length), out var docType))
                        {
                            strDocVersion = match.Groups["version"].Value;
                            break;
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(strDocVersion))
            {
                version = GetVersion(strDocVersion);
            } else
            {
                // Throw exception?
            }
            return version.GetValueOrDefault();
        }

        /// <summary>
        /// Constructs a namespace table for the XML document in order to use proper XPath.
        /// </summary>
        /// <param name="version">Reference to the version of MTConnect being used in the document.</param>
        /// <param name="xDoc">Reference to the XML document</param>
        /// <param name="defaultNamespace">Reference to the default namespace name (ie. <c>m</c>, or <c>mt</c>)</param>
        /// <returns>XML name table</returns>
        /// <exception cref="Exception"></exception>
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

            // Parse document type for use in the default namespace
            string mtconnectNamespace = xDoc.DocumentElement.LocalName;

            const string MTCONNECT = "MTConnect";
            if (!mtconnectNamespace.StartsWith(MTCONNECT))
                throw new Exception("Root element is not valid for MTConnect");
            string strDocumentType = mtconnectNamespace.Substring(MTCONNECT.Length);
            if (!Enum.TryParse<DocumentTypes>(strDocumentType, out DocumentTypes documentType))
                throw new Exception("Response Document type is not recognized");

            // Get normalized version name. For example, from enum V1_0_1 to 1.0.1
            string normalizedName = versionNames[version];
            // Further normalize by removing unnecessary patch number. For example, from 1.0.1 to 1.0
            normalizedName = normalizedName.Substring(0, normalizedName.LastIndexOf("."));

            // Construct default namespace. For example, urn:mtconnect.org:MTConnectDevices:1.0
            string defaultNamespaceUri = $"urn:mtconnect.org:{MTCONNECT}{documentType}:{normalizedName}";

            // See if document is missing xmlns attribute
            if (string.IsNullOrEmpty(xDoc.DocumentElement.GetAttribute("xmlns")))
            {
                xDoc.DocumentElement.Attributes.Append(xDoc.CreateAttribute("xmlns")).Value = defaultNamespaceUri;
                // You have to reload the XML after changing the default namespace
                xDoc.LoadXml(xDoc.OuterXml);
            } else
            {
                defaultNamespaceUri = xDoc.DocumentElement.GetAttribute("xmlns");
            }

            // See if document is missing xmlns:[m || mt] attribute
            if (string.IsNullOrEmpty(xDoc.DocumentElement.GetAttribute("xmlns:" + defaultNamespace)))
            {
                xDoc.DocumentElement.Attributes.Append(xDoc.CreateAttribute("xmlns:" + defaultNamespace)).Value = defaultNamespaceUri;
                // You have to reload the XML after changing namespaces
                xDoc.LoadXml(xDoc.OuterXml);
            }

            var nsmgr = new XmlNamespaceManager(xDoc.NameTable);
            nsmgr.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
            nsmgr.AddNamespace(defaultNamespace, defaultNamespaceUri);

            switch (version)
            {
                case MtconnectVersions.V_1_0_1:
                    break;
                case MtconnectVersions.V_1_1_0:
                    break;
                case MtconnectVersions.V_1_2_0:
                    break;
                case MtconnectVersions.V_1_3_0:
                    nsmgr.AddNamespace("vc", "http://www.w3.org/2007/XMLSchema-versioning");
                    break;
                case MtconnectVersions.V_1_3_1:
                    break;
                case MtconnectVersions.V_1_4_0:
                    nsmgr.AddNamespace("vc", "http://www.w3.org/2007/XMLSchema-versioning");
                    break;
                case MtconnectVersions.V_1_4_1:
                    break;
                case MtconnectVersions.V_1_5_0:
                    nsmgr.AddNamespace("vc", "http://www.w3.org/2007/XMLSchema-versioning");
                    nsmgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
                    break;
                case MtconnectVersions.V_1_5_1:
                    nsmgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
                    break;
                case MtconnectVersions.V_1_6_0:
                    nsmgr.AddNamespace("vc", "http://www.w3.org/2007/XMLSchema-versioning");
                    nsmgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
                    break;
                case MtconnectVersions.V_1_6_1:
                    nsmgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
                    break;
                case MtconnectVersions.V_1_7_0:
                    nsmgr.AddNamespace("vc", "http://www.w3.org/2007/XMLSchema-versioning");
                    nsmgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
                    break;
                case MtconnectVersions.V_1_7_1:
                    nsmgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
                    break;
                case MtconnectVersions.V_1_8_0:
                    nsmgr.AddNamespace("vc", "http://www.w3.org/2007/XMLSchema-versioning");
                    nsmgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
                    break;
                case MtconnectVersions.V_1_8_1:
                    nsmgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
                    break;
                case MtconnectVersions.V_2_0_0:
                    nsmgr.AddNamespace("vc", "http://www.w3.org/2007/XMLSchema-versioning");
                    nsmgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
                    break;
                case MtconnectVersions.V_2_0_1:
                    nsmgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
                    break;
                case MtconnectVersions.V_2_1_0:
                    nsmgr.AddNamespace("vc", "http://www.w3.org/2007/XMLSchema-versioning");
                    nsmgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
                    break;
                case MtconnectVersions.V_2_1_1:
                    nsmgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
                    break;
                case MtconnectVersions.V_2_2_0:
                    nsmgr.AddNamespace("vc", "http://www.w3.org/2007/XMLSchema-versioning");
                    nsmgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
                    break;
                case MtconnectVersions.V_2_2_1:
                    nsmgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
                    break;
                case MtconnectVersions.V_2_3_0:
                    nsmgr.AddNamespace("vc", "http://www.w3.org/2007/XMLSchema-versioning");
                    nsmgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
                    break;
                case MtconnectVersions.V_2_3_1:
                    nsmgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
                    break;
                case MtconnectVersions.V_2_4_0:
                    nsmgr.AddNamespace("vc", "http://www.w3.org/2007/XMLSchema-versioning");
                    nsmgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
                    break;
                case MtconnectVersions.V_2_4_1:
                    nsmgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
                    break;
                case MtconnectVersions.V_2_5_0:
                    nsmgr.AddNamespace("vc", "http://www.w3.org/2007/XMLSchema-versioning");
                    nsmgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
                    break;
                case MtconnectVersions.V_2_5_1:
                    nsmgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
                    break;
                default:
                    break;
            }

            return nsmgr;
        }
    }
}
