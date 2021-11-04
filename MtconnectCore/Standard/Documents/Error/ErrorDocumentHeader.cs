using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Error.Attributes;
using System.Xml;
using HeaderAttributes = MtconnectCore.Standard.Contracts.Enums.Error.Attributes.HeaderAttributes;

namespace MtconnectCore.Standard.Documents.Error
{
    /// <inheritdoc />
    public class ErrorDocumentHeader : ResponseDocumentHeader
    {
        [MtconnectNodeAttribute(HeaderAttributes.TEST_INDICATOR)]
        public bool TestIndicator { get; set; }

        [MtconnectNodeAttribute(HeaderAttributes.BUFFER_SIZE)]
        public int BufferSize { get; set; }

        /// <inheritdoc />
        public ErrorDocumentHeader() : base() { }

        /// <inheritdoc />
        public ErrorDocumentHeader(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE, version) { }
    }
}
