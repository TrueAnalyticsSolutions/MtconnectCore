using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using System.Xml;
using HeaderAttributes = MtconnectCore.Standard.Contracts.Enums.Streams.Attributes.HeaderAttributes;

namespace MtconnectCore.Standard.Documents.Streams
{
    /// <inheritdoc />
    public partial class StreamsDocumentHeader : ResponseDocumentHeader
    {
        [MtconnectNodeAttribute(HeaderAttributes.BUFFER_SIZE)]
        public int BufferSize { get; set; }

        [MtconnectNodeAttribute(HeaderAttributes.FIRST_SEQUENCE)]
        public int FirstSequence { get; set; }

        [MtconnectNodeAttribute(HeaderAttributes.LAST_SEQUENCE)]
        public int LastSequence { get; set; }

        [MtconnectNodeAttribute(HeaderAttributes.NEXT_SEQUENCE)]
        public int NextSequence { get; set; }

        /// <inheritdoc/>
        public StreamsDocumentHeader() : base() { }

        /// <inheritdoc/>
        public StreamsDocumentHeader(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE, version) { }
    }
}
