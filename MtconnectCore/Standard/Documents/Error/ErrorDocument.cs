using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Error.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Error
{
    /// <inheritdoc />
    public class ErrorDocument : ResponseDocument<ErrorDocumentHeader, Error>
    {
        /// <inheritdoc/>
        public override DocumentTypes Type => DocumentTypes.Errors;

        /// <inheritdoc/>
        public override string DefaultNamespace => Constants.DEFAULT_XML_NAMESPACE;

        /// <inheritdoc/>
        public override string DataElementName => "Errors";

        internal override ErrorDocumentHeader _header { get; set; }
        /// <inheritdoc cref="_header"/>
        public ErrorDocumentHeader Header => _header;

        /// <inheritdoc/>
        public ErrorDocument(XmlDocument xDoc) : base(xDoc)
        {
            _header = new ErrorDocumentHeader(xDoc.DocumentElement.FirstChild, NamespaceManager, MtconnectVersion.GetValueOrDefault());
        }

        /// <inheritdoc />
        public override bool TryAddItem(XmlNode xNode, XmlNamespaceManager nsmgr, out Error item) => base.TryAdd<Error>(xNode, nsmgr, ref _items, out item);
    }
}
