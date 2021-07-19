using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <summary>
    /// An element that can contain any descriptive content.
    /// </summary>
    /// <remarks>See Part 2 Section 4.4.3.1 of the MTConnect specification</remarks>
    public class ComponentDescription : MtconnectNode
    {
        /// <summary>
        /// The content of the description can be text or XML elements. This is the inner text of the XML element.
        /// </summary>
        public string Content { get; set; }

        /// <inheritdoc cref="ComponentDescriptionAttributes.MANUFACTURER"/>
        [MtconnectNodeAttribute(ComponentDescriptionAttributes.MANUFACTURER)]
        public string Manufacturer { get; set; }

        /// <inheritdoc cref="ComponentDescriptionAttributes.MODEL"/>
        [MtconnectNodeAttribute(ComponentDescriptionAttributes.MODEL)]
        public string Model { get; set; }

        /// <inheritdoc cref="ComponentDescriptionAttributes.SERIAL_NUMBER"/>
        [MtconnectNodeAttribute(ComponentDescriptionAttributes.SERIAL_NUMBER)]
        public string SerialNumber { get; set; }

        /// <inheritdoc cref="ComponentDescriptionAttributes.STATION"/>
        [MtconnectNodeAttribute(ComponentDescriptionAttributes.STATION)]
        public string Station { get; set; }

        /// <inheritdoc/>
        public ComponentDescription() : base() { }

        /// <inheritdoc/>
        public ComponentDescription(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE)
        {
            Content = xNode.Value;
        }
    }
}
