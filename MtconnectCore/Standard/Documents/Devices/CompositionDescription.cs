using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <summary>
    /// Description can contain any descriptive content for this Composition element.
    /// </summary>
    public class CompositionDescription : MtconnectNode
    {
        /// <inheritdoc cref="CompositionDescriptionAttributes.MANUFACTURER"/>
        [MtconnectNodeAttribute(CompositionDescriptionAttributes.MANUFACTURER)]
        public string Manufacturer { get; set; }

        /// <inheritdoc cref="CompositionDescriptionAttributes.MODEL"/>
        [MtconnectNodeAttribute(CompositionDescriptionAttributes.MODEL)]
        public string Model { get; set; }

        /// <inheritdoc cref="CompositionDescriptionAttributes.SERIAL_NUMBER"/>
        [MtconnectNodeAttribute(CompositionDescriptionAttributes.SERIAL_NUMBER)]
        public string SerialNumber { get; set; }

        /// <inheritdoc cref="CompositionDescriptionAttributes.STATION"/>
        [MtconnectNodeAttribute(CompositionDescriptionAttributes.STATION)]
        public string Station { get; set; }

        public string Value { get; set; }

        /// <inheritdoc/>
        public CompositionDescription() : base() { }

        /// <inheritdoc/>
        public CompositionDescription(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE) {
            Value = xNode.InnerText;
        }
    }
}
