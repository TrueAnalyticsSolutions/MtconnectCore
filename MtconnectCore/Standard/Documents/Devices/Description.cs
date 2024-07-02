using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System.Collections.Generic;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <summary>
    /// An element that can contain any descriptive content.
    /// </summary>
    /// <remarks>See Part 2 Section 4.4.3.1 of the MTConnect specification</remarks>
    public class Description : MtconnectNode
    {
        /// <summary>
        /// The content of the description can be text or XML elements. This is the inner text of the XML element.
        /// </summary>
        public string Content { get; set; }

        /// <inheritdoc cref="DescriptionAttributes.MANUFACTURER"/>
        [MtconnectNodeAttribute(DescriptionAttributes.MANUFACTURER)]
        public string Manufacturer { get; set; }

        /// <inheritdoc cref="DescriptionAttributes.MODEL"/>
        [MtconnectNodeAttribute(DescriptionAttributes.MODEL)]
        public string Model { get; set; }

        /// <inheritdoc cref="DescriptionAttributes.SERIAL_NUMBER"/>
        [MtconnectNodeAttribute(DescriptionAttributes.SERIAL_NUMBER)]
        public string SerialNumber { get; set; }

        /// <inheritdoc cref="DescriptionAttributes.STATION"/>
        [MtconnectNodeAttribute(DescriptionAttributes.STATION)]
        public string Station { get; set; }

        /// <inheritdoc/>
        public Description() : base() { }

        /// <inheritdoc/>
        public Description(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE, version)
        {
            Content = xNode.Value;
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.COMPONENT)]
        private bool validateValueProperties(out ICollection<MtconnectValidationException> validationErrors)
            => new NodeValidationContext(this)
                // manufacturer
                .ValidateValueProperty<DescriptionAttributes>(nameof(Manufacturer), (o) =>
                    o.IsImplemented(nameof(DescriptionAttributes.MANUFACTURER))
                )
                // model
                .ValidateValueProperty<DescriptionAttributes>(nameof(Model), (o) =>
                    o.IsImplemented(nameof(DescriptionAttributes.MODEL))
                )
                // serialNumber
                .ValidateValueProperty<DescriptionAttributes>(nameof(SerialNumber), (o) =>
                    o.IsImplemented(nameof(DescriptionAttributes.SERIAL_NUMBER))
                )
                // station
                .ValidateValueProperty<DescriptionAttributes>(nameof(Station), (o) =>
                    o.IsImplemented(nameof(DescriptionAttributes.STATION))
                )
                // value
                .ValidateValueProperty<DescriptionAttributes>("value", (o) =>
                    o
                )
                .HasError(out validationErrors);
    }
}
