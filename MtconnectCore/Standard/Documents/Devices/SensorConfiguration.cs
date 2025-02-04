using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System;
using System.Collections.Generic;
using System.Xml;

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
        public ParsedValue<DateTime?> CalibrationDate { get; set; }

        /// <inheritdoc cref="SensorConfigurationElements.NEXT_CALIBRATION_DATE"/>
        [MtconnectNodeElement(SensorConfigurationElements.NEXT_CALIBRATION_DATE)]
        public ParsedValue<DateTime?> NextCalibrationDate { get; set; }

        /// <inheritdoc cref="SensorConfigurationElements.CALIBRATION_INITIALS"/>
        [MtconnectNodeElement(SensorConfigurationElements.CALIBRATION_INITIALS)]
        public string CalibrationInitials { get; set; }

        private List<Channel> _channels = new List<Channel>();
        /// <inheritdoc cref="SensorConfigurationElements.CHANNELS"/>
        [MtconnectNodeElements("Channels/*", nameof(TryAddChannel))]
        public ICollection<Channel> Channels => _channels;

        /// <inheritdoc />
        public SensorConfiguration() : base() { }

        /// <inheritdoc />
        public SensorConfiguration(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        public bool TryAddChannel(XmlNode xNode, XmlNamespaceManager nsmgr, out Channel channel)
            => base.TryAdd<Channel>(xNode, nsmgr, ref _channels, out channel);


        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.6.7.1")]
        private bool ValidateProperties(out ICollection<MtconnectValidationException> validationErrors)
        {
            return new NodeValidationContext(this)
                // Validate CalibrationDate
                .ValidateValueProperty(
                    SensorConfigurationElements.CALIBRATION_DATE,
                    (o) =>
                        o.IsImplemented(CalibrationDate)
                        ?.IsDateTimeValueType(CalibrationDate, out _)
                )
                // Validate CalibrationInitials
                .ValidateValueProperty(
                    SensorConfigurationElements.CALIBRATION_INITIALS,
                    (o) =>
                        o.IsImplemented(CalibrationInitials)
                )
                // Validate FirmwareVersion
                .ValidateValueProperty(
                    SensorConfigurationElements.FIRMWARE_VERSION,
                    (o) =>
                        o.IsImplemented(FirmwareVersion)
                        ?.WhileIntroduced((i) =>
                            i.IsRequired(FirmwareVersion)
                        )
                )
                // Validate NextCalibrationDate
                .ValidateValueProperty(
                    SensorConfigurationElements.NEXT_CALIBRATION_DATE,
                    (o) =>
                        o.IsImplemented(NextCalibrationDate)
                        ?.IsDateTimeValueType(NextCalibrationDate, out _)
                )
                // Return validation errors
                .HasError(out validationErrors);
        }
    }
}
