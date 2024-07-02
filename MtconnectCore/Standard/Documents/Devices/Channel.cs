using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <summary>
    /// Channel represents each sensing element connected to a sensor unit.
    /// </summary>
    /// <remarks>See Part 2 Section 9.1.3.1.1 of the MTConnect specification.</remarks>
    public class Channel : MtconnectNode
    {
        /// <inheritdoc cref="ChannelAttributes.NUMBER"/>
        [MtconnectNodeAttribute(ChannelAttributes.NUMBER)]
        public string Number { get; set; }

        /// <inheritdoc cref="ChannelAttributes.NAME"/>
        [MtconnectNodeAttribute(ChannelAttributes.NAME)]
        public string Name { get; set; }

        /// <inheritdoc cref="ChannelElements.DESCRIPTION"/>
        [MtconnectNodeElement(ChannelElements.DESCRIPTION)]
        public string Description { get; set; }

        /// <inheritdoc cref="ChannelElements.CALIBRATION_DATE"/>
        [MtconnectNodeElement(ChannelElements.CALIBRATION_DATE)]
        public DateTime? CalibrationDate { get; set; }

        /// <inheritdoc cref="ChannelElements.NEXT_CALIBRATION_DATE"/>
        [MtconnectNodeElement(ChannelElements.NEXT_CALIBRATION_DATE)]
        public DateTime? NextCalibrationDate { get; set; }

        /// <inheritdoc cref="ChannelElements.CALIBRATION_INITIALS"/>
        [MtconnectNodeElement(ChannelElements.CALIBRATION_INITIALS)]
        public string CalibrationInitials { get; set; }

        /// <inheritdoc/>
        public Channel() : base() { }

        /// <inheritdoc/>
        public Channel(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE, version) { }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.CHANNEL)]
        private bool validateValueProperties(out ICollection<MtconnectValidationException> validationErrors)
            => new NodeValidationContext(this)
            // name
            .ValidateValueProperty<ChannelAttributes>(nameof(ChannelAttributes.NAME), (o) =>
                o
            )
            // number
            .ValidateValueProperty<ChannelAttributes>(nameof(ChannelAttributes.NUMBER), (o) => 
                o.WhileIntroduced((x) =>
                    x.ValidateRequired(nameof(Name), Name)
                )
            )
            .HasError(out validationErrors);
        // TODO: Add Parts validation
    }
}
