using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    public class ComponentDescription : MtconnectNode
    {
        public string Content { get; set; }

        [MtconnectNodeAttribute(ComponentDescriptionAttributes.MANUFACTURER)]
        public string Manufacturer { get; set; }

        [MtconnectNodeAttribute(ComponentDescriptionAttributes.MODEL)]
        public string Model { get; set; }

        [MtconnectNodeAttribute(ComponentDescriptionAttributes.SERIAL_NUMBER)]
        public string SerialNumber { get; set; }

        [MtconnectNodeAttribute(ComponentDescriptionAttributes.STATION)]
        public string Station { get; set; }

        public ComponentDescription() : base() { }

        public ComponentDescription(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE)
        {
            Content = xNode.Value;
        }

        public override bool IsValid() => Manufacturer != null || Model != null || SerialNumber != null || Station != null; // See Part 2 Section 4.4.3.1 of MTConnect Standard
    }
}
