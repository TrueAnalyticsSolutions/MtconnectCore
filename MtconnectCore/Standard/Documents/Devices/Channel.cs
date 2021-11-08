using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
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

        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.6.7.2")]
        private bool validateNumber(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Number))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Channel MUST include a 'number' attribute."));
            } else if (Number.Length > 255) {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Channel 'number' must not exceed 255 characters."));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
