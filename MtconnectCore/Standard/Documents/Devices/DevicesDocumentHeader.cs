using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    public class DevicesDocumentHeader : MtconnectDocumentHeader
    {
        [MtconnectNodeAttribute(HeaderAttributes.BUFFER_SIZE)]
        public int BufferSize { get; set; }

        [MtconnectNodeAttribute(HeaderAttributes.TEST_INDICATOR)]
        public bool TestIndicator { get; set; }

        [MtconnectNodeAttribute(HeaderAttributes.ASSET_BUFFER_SIZE)]
        public int AssetBufferSize { get; set; }

        [MtconnectNodeAttribute(HeaderAttributes.ASSET_COUNT)]
        public int AssetCount { get; set; }

        public DevicesDocumentHeader() : base() { }

        public DevicesDocumentHeader(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE) { }
    }
}
