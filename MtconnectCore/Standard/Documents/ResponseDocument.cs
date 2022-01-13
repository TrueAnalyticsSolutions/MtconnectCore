using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents
{
    /// <summary>
    /// Structural interface for a MTConnect Response Document. See Part 1 Section 6 of MTConnect specification.
    /// </summary>
    public abstract class ResponseDocument<THeader, TItem> : MtconnectNode, IResponseDocument where THeader : IResponseDocumentHeader where TItem : MtconnectNode
    {
        internal List<TItem> _items = new List<TItem>();
        /// <summary>
        /// Collection of <see cref="{TItem}"/> contained within a MTConnect Response Document.
        /// </summary>
        public TItem[] Items => _items.ToArray();// ICollection<TItem> Items => _items;

        /// <summary>
        /// Reference to the type of MTConnect Response Document.
        /// </summary>
        public abstract DocumentTypes Type { get; }

        /// <summary>
        /// Reference to the default XML namespace that this type of MTConnect Response Document uses.
        /// </summary>
        public abstract string DefaultNamespace { get; }

        /// <summary>
        /// Internal reference to the <see cref="{THeader}"/>.
        /// </summary>
        internal abstract THeader _header { get; set; }

        /// <summary>
        /// Reference to the root MTConnect Response Document XML element name.
        /// </summary>
        public string DocumentElementName { get; set; }

        /// <summary>
        /// Reference to the XML element name that contains node to be processed into <see cref="{TItem}"/>s.
        /// </summary>
        public abstract string DataElementName { get; }

        /// <summary>
        /// Global XML namespace manager for the source document.
        /// </summary>
        public XmlNamespaceManager NamespaceManager { get; set; }

        /// <summary>
        /// Reference to the source MTConnect Response Document.
        /// </summary>
        internal XmlDocument Source { get; set; }

        /// <summary>
        /// Reference to the version of MTConnect applied to the Response Document.
        /// </summary>
        public MtconnectVersions DocumentVersion { get; set; }

        /// <summary>
        /// Constructs a new Response Document using a source <see cref="XmlDocument"/> from an MTConnect Agent.
        /// </summary>
        /// <param name="xDoc">The source MTConnect Response Document.</param>
        public ResponseDocument(XmlDocument xDoc)
        {
            Source = xDoc;

            DocumentVersion = VersionHelper.GetVersionFromDocument(xDoc);
            MtconnectVersion = DocumentVersion;
            DocumentElementName = Source.DocumentElement.LocalName;
            MtconnectDocumentTypeMismatchException<THeader, TItem> typeError;
            switch (DocumentElementName)
            {
                case "MTConnectStreams":
                    if (Type != DocumentTypes.Streams)
                    {
                        Logger.Error(new MtconnectDocumentTypeMismatchException<THeader, TItem>(this));
                    }
                    break;
                case "MTConnectError":
                    if (Type != DocumentTypes.Errors)
                    {
                        Logger.Error(new MtconnectDocumentTypeMismatchException<THeader, TItem>(this));
                    }
                    break;
                case "MTConnectAssets":
                    if (Type != DocumentTypes.Assets)
                    {
                        Logger.Error(new MtconnectDocumentTypeMismatchException<THeader, TItem>(this));
                    }
                    break;
                case "MTConnectDevices":
                    if (Type != DocumentTypes.Devices)
                    {
                        Logger.Error(new MtconnectDocumentTypeMismatchException<THeader, TItem>(this));
                    }
                    break;
                default:
                    break;
            }
            NamespaceManager = VersionHelper.GetDocumentNamespaces(DocumentVersion, Source, DefaultNamespace);


            XmlNode xDataRoot = xDoc.DocumentElement.SelectSingleNode(DataElementName, NamespaceManager, DefaultNamespace);
            XmlNodeList xDataElements = xDataRoot.ChildNodes;
            Logger.Verbose($"Found {xDataElements?.Count} {DataElementName} in {DocumentElementName}");
            foreach (XmlElement xDataElement in xDataElements)
            {
                if (!xDataElement.HasAttributes) continue;

                _ = this.TryAddItem(xDataElement, NamespaceManager, out _);
            }
        }

        /// <summary>
        /// Safely tries to set the internal <see cref="{THeader}"/> from the source MTConnect Response Document.
        /// </summary>
        /// <param name="xNode">Reference to the <c>&lt;Header&gt;</c> node.</param>
        /// <param name="nsmgr">Reference to a global XML namespace manager.</param>
        /// <param name="header">Outputs the set <see cref="{THeader}"/>.</param>
        /// <returns>Flag for whether or not the header was successfully parsed from the MTConnect Response Document into a <see cref="{THeader}"/>.</returns>
        public bool TrySetHeader(XmlNode xNode, XmlNamespaceManager nsmgr, out THeader header)
        {
            Logger.Verbose("Reading Header {XnodeKey}", xNode.TryGetAttribute(HeaderAttributes.SENDER));
            Type headerType = typeof(THeader);
            ConstructorInfo ctor = headerType.GetConstructor(new Type[] { typeof(XmlDocument), typeof(XmlNamespaceManager) });
            if (ctor != null)
            {
                header = (THeader)ctor.Invoke(new object[] { xNode, nsmgr });
                if (!header.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
                {
                    Logger.Warn($"[Invalid Stream] Header:\r\n{ExceptionHelper.ToString(validationExceptions)}");
                    return false;
                }
                _header = header;
                return true;
            }
            header = default(THeader);
            return false;
        }

        /// <summary>
        /// Safely tries to add a <see cref="{TItem}"/> into the internal collection.
        /// </summary>
        /// <param name="xNode">Reference to the XML element representing an instance of <see cref="{TItem}"/>.</param>
        /// <param name="nsmgr">Reference to a global XML namespace manager.</param>
        /// <param name="item">Outputs the set <see cref="{TItem}"/>.</param>
        /// <returns>Flag for whether or not the item was successfully parsed from the MTConnect Response Document and added to <see cref="Items"/>.</returns>
        public abstract bool TryAddItem(XmlNode xNode, XmlNamespaceManager nsmgr, out TItem item);

        ///// <summary>
        ///// Gets the version of MTConnect that has been applied to the source MTConnect Response Document.
        ///// </summary>
        ///// <returns>The MTConnect Version applied to this MTConnect Response Document.</returns>
        //protected MtconnectVersions GetDocumentVersion()
        //{
        //    MtconnectVersions? version = null;
        //    Regex regVersion = new Regex(@"^urn\:mtconnect.org\:(.*?)\:(?<version>.*?)$");
        //    string docDefaultNamespace = Source.DocumentElement.GetAttribute("xmlns");
        //    string strDocVersion = string.Empty;
        //    var match = regVersion.Match(docDefaultNamespace);
        //    if (match.Success)
        //    {
        //        strDocVersion = match.Groups["version"].Value;
        //    }
        //    if (!string.IsNullOrEmpty(strDocVersion))
        //    {
        //        version = VersionHelper.GetVersion(strDocVersion);
        //    }
        //    return version.GetValueOrDefault();
        //}

        /// <summary>
        /// Safely tries to validate the <see cref="{THeader}"/> and all <see cref="Items"/> in this MTConnect Response Document according to the version of MTConnect.
        /// </summary>
        /// <param name="validationErrors">Outputs a collection of validation errors. Note that this collection may contain errors, warnings, and messages.</param>
        /// <returns>Flag for whether or not any of the validation errors were of the <see cref="ValidationSeverity.ERROR"/> severity.</returns>
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            base.TryValidate(out validationErrors);

            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
