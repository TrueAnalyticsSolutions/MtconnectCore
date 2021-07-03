using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    public class Source : MtconnectNode
    {
        [MtconnectNodeAttribute(SourceAttributes.COMPONENT_ID)]
        public string ComponentId { get; set; }

        [MtconnectNodeAttribute(SourceAttributes.DATA_ITEM_ID)]
        public string DataItemId { get; set; }

        public Source() : base() { }

        public Source(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE) { }

        public override bool IsValid() => ComponentId != null || DataItemId != null; // See Part 2 Section 6.2.1 of MTConnect Standard
    }
}
