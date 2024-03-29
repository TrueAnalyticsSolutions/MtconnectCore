﻿using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <summary>
    /// SensorConfiguration contains configuration information about a Sensor.
    /// </summary>
    public class SensorConfiguration : MtconnectNode
    {
        /// <inheritdoc cref="SensorConfigurationElements.FIRMWARE_VERSION"/>
        [MtconnectNodeElement(SensorConfigurationElements.FIRMWARE_VERSION)]
        public string FirmwareVersion { get; set; }

        /// <inheritdoc cref="SensorConfigurationElements.CALIBRATION_DATE"/>
        [MtconnectNodeElement(SensorConfigurationElements.CALIBRATION_DATE)]
        public DateTime? CalibrationDate { get; set; }

        /// <inheritdoc cref="SensorConfigurationElements.NEXT_CALIBRATION_DATE"/>
        [MtconnectNodeElement(SensorConfigurationElements.NEXT_CALIBRATION_DATE)]
        public DateTime? NextCalibrationDate { get; set; }

        /// <inheritdoc cref="SensorConfigurationElements.CALIBRATION_INITIALS"/>
        [MtconnectNodeElement(SensorConfigurationElements.CALIBRATION_INITIALS)]
        public string CalibrationInitials { get; set; }

        private List<Channel> _channels = new List<Channel>();
        /// <inheritdoc cref="SensorConfigurationElements.CHANNELS"/>
        [MtconnectNodeElements("Channels/*", nameof(TryAddChannel), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ICollection<Channel> Channels => _channels;

        /// <inheritdoc />
        public SensorConfiguration() : base() { }

        /// <inheritdoc />
        public SensorConfiguration(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE, version) { }

        public bool TryAddChannel(XmlNode xNode, XmlNamespaceManager nsmgr, out Channel channel)
            => base.TryAdd<Channel>(xNode, nsmgr, ref _channels, out channel);


        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.6.7.1")]
        private bool validateFirmwareVersion(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(FirmwareVersion))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"SensorConfiguration MUST include a 'FirmwareVersion' element."));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
