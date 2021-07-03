using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents
{
    public abstract class MtconnectDocument<THeader, TItem> : MtconnectNode, IMtconnectDocument where THeader : IMtconnectDocumentHeader where TItem : MtconnectNode
    {
        internal List<TItem> _items = new List<TItem>();
        public ICollection<TItem> Items => _items;

        public abstract DocumentTypes Type { get; }

        public abstract string DefaultNamespace { get; }

        internal abstract THeader _header { get; set; }

        public string DocumentElementName { get; set; }

        public abstract string DataElementName { get; }

        public XmlNamespaceManager NamespaceManager { get; set; }

        internal XmlDocument Source { get; set; }

        public MtconnectVersions DocumentVersion { get; set; }

        public MtconnectDocument(XmlDocument xDoc)
        {
            Source = xDoc;

            DocumentElementName = Source.DocumentElement.LocalName;
            MtconnectDocumentTypeMismatch<THeader, TItem> typeError;
            switch (DocumentElementName)
            {
                case "MTConnectStreams":
                    if (Type != DocumentTypes.Streams)
                    {
                        Logger.Error(new MtconnectDocumentTypeMismatch<THeader, TItem>(this));
                    }
                    break;
                case "MTConnectError":
                    if (Type != DocumentTypes.Errors)
                    {
                        Logger.Error(new MtconnectDocumentTypeMismatch<THeader, TItem>(this));
                    }
                    break;
                case "MTConnectAssets":
                    if (Type != DocumentTypes.Assets)
                    {
                        Logger.Error(new MtconnectDocumentTypeMismatch<THeader, TItem>(this));
                    }
                    break;
                case "MTConnectDevices":
                    if (Type != DocumentTypes.Devices)
                    {
                        Logger.Error(new MtconnectDocumentTypeMismatch<THeader, TItem>(this));
                    }
                    break;
                default:
                    break;
            }

            DocumentVersion = GetDocumentVersion();
            NamespaceManager = VersionHelper.GetDocumentNamespaces(DocumentVersion, Source, DefaultNamespace);// GetNamespaceManager(DocumentVersion);

            XmlNode xDataRoot = xDoc.DocumentElement.SelectSingleNode(DataElementName, NamespaceManager, DefaultNamespace);
            XmlNodeList xDataElements = xDataRoot.ChildNodes;
            Logger.Verbose($"Found {xDataElements?.Count} {DataElementName} in {DocumentElementName}");
            foreach (XmlElement xDataElement in xDataElements)
            {
                if (!xDataElement.HasAttributes) continue;

                _ = this.TryAddItem(xDataElement, NamespaceManager, out _);
            }
        }

        public bool TrySetHeader(XmlNode xNode, XmlNamespaceManager nsmgr, out THeader header)
        {
            Logger.Verbose("Reading Header {XnodeKey}", xNode.TryGetAttribute(HeaderAttributes.SENDER));
            Type headerType = typeof(THeader);
            ConstructorInfo ctor = headerType.GetConstructor(new Type[] { typeof(XmlDocument), typeof(XmlNamespaceManager) });
            if (ctor != null)
            {
                header = (THeader)ctor.Invoke(new object[] { xNode, nsmgr });
                if (!header.IsValid())
                {
                    Logger.Warn($"[Invalid Stream] Header is not formatted properly, refer to Part 1 Section 6.5 of MTConnect Standard.");
                    return false;
                }
                _header = header;
                return true;
            }
            header = default(THeader);
            return false;
        }

        public abstract bool TryAddItem(XmlNode xNode, XmlNamespaceManager nsmgr, out TItem item);

        protected MtconnectVersions GetDocumentVersion()
        {
            MtconnectVersions? version = null;
            Regex regVersion = new Regex(@"^urn\:mtconnect.org\:(.*?)\:(?<version>.*?)$");
            string docDefaultNamespace = Source.DocumentElement.GetAttribute("xmlns");
            string strDocVersion = string.Empty;
            var match = regVersion.Match(docDefaultNamespace);
            if (match.Success)
            {
                strDocVersion = match.Groups["version"].Value;
            }
            if (!string.IsNullOrEmpty(strDocVersion))
            {
                version = VersionHelper.GetVersion(strDocVersion);
            }
            return version.GetValueOrDefault();
        }
    }
}
