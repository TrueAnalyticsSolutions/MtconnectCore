using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    public partial class StreamsDocumentHeader : MtconnectDocumentHeader
    {
        [MtconnectNodeAttribute(HeaderAttributes.BUFFER_SIZE)]
        public int BufferSize { get; set; }

        [MtconnectNodeAttribute(HeaderAttributes.FIRST_SEQUENCE)]
        public int FirstSequence { get; set; }

        [MtconnectNodeAttribute(HeaderAttributes.LAST_SEQUENCE)]
        public int LastSequence { get; set; }

        [MtconnectNodeAttribute(HeaderAttributes.NEXT_SEQUENCE)]
        public int NextSequence { get; set; }

        public StreamsDocumentHeader() : base() { }

        public StreamsDocumentHeader(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE) { }
    }
}
