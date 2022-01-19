using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class Sample : DataItem
    {
        /// <summary>
        /// Collected from the subType attribute. Refer to Part 3 Streams - 5.3.2
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(SampleAttributes.SUB_TYPE)]
        public string SubType { get; set; }

        /// <summary>
        /// Collected from the name attribute. Refer to Part 3 Streams - 5.3.2
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(SampleAttributes.NAME)]
        public string Name { get; set; }

        /// <summary>
        /// Collected from the sampleRate attribute. Refer to Part 3 Streams - 5.3.2
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(SampleAttributes.SAMPLE_RATE)]
        public double SampleRate { get; set; }

        /// <summary>
        /// Collected from the statistic attribute. Refer to Part 3 Streams - 5.3.2
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(SampleAttributes.STATISTIC)]
        public string Statistic { get; set; }

        /// <summary>
        /// Collected from the duration attribute. Refer to Part 3 Streams - 5.3.2
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(SampleAttributes.DURATION)]
        public double? Duration { get; set; }

        /// <summary>
        /// Collected from the resetTriggered attribute. Refer to Part 3 Streams - 5.3.2
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(SampleAttributes.RESET_TRIGGERED)]
        public ResetTriggers? ResetTriggered { get; set; }

        /// <summary>
        /// Collected from the compositionId attribute. Refer to Part 3 Streams - 5.3.2
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(SampleAttributes.COMPOSITION_ID)]
        public string CompositionId { get; set; }

        /// <summary>
        /// Collected from the textcontent of the Sample element. Refer to Part 3 Streams - 5.3.3
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Reference to the name of the element. Refer to Part 3 Streams - 5.3
        /// </summary>
        public string TagName { get; set; }

        [MtconnectNodeAttribute(SampleAttributes.SAMPLE_COUNT)]
        public int? SampleCount { get; set; }

        /// <inheritdoc/>
        public Sample() : base() { }

        /// <inheritdoc/>
        public Sample(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version)
        {
            Value = xNode.InnerText;
            TagName = xNode.LocalName;
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.1", MtconnectVersions.V_1_1_0)]
        protected bool validateName_Required(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Name))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"DataItem MUST include a 'name' attribute.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.8.2")]
        protected bool validateTimeSeriesCount(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            string[] timeSeriesValues = Value.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
            // TODO: Validate when position is 3D
            if (timeSeriesValues.Length > 1 && timeSeriesValues.Length != SampleCount.GetValueOrDefault() && timeSeriesValues.Length != 3){
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, $"SAMPLE number of readings MUST match the sampleCount.", SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 5.3.2")]
        protected bool validateDuration(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(Statistic) && !Duration.HasValue)
            {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, $"'duration' MUST be provided when the 'statistic' attribute is present on a SAMPLE.", SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8")]
        protected override bool validateNode(out ICollection<MtconnectValidationException> validationErrors)
            => validateNode<MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.SampleTypes>(Contracts.Enums.Devices.CategoryTypes.SAMPLE, out validationErrors);

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8")]
        protected override bool validateValue(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();

            if (Enum.TryParse<MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.SampleTypes>(SourceNode.LocalName, out MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.SampleTypes type))
            {
                switch (type)
                {
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.ACCELERATION:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.ACCUMULATED_TIME:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.ANGULAR_ACCELERATION:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.ANGULAR_VELOCITY:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.AMPERAGE:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.AMPERAGE_AC:
                        if (!tryValidateSubType<AmperageAcSubTypes>(SubType, out MtconnectValidationException amperageAcSubTypeError))
                        {
                            validationErrors.Add(amperageAcSubTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.AMPERAGE_DC:
                        if (!tryValidateSubType<AmperageDcSubTypes>(SubType, out MtconnectValidationException amperageDcSubTypeError))
                        {
                            validationErrors.Add(amperageDcSubTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.ANGLE:
                        if (!string.IsNullOrEmpty(SubType) && !tryValidateSubType<AngleSubTypes>(SubType, out MtconnectValidationException angleSubTypeError))
                        {
                            validationErrors.Add(angleSubTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.AXIS_FEEDRATE:
                        if (!string.IsNullOrEmpty(SubType) && !tryValidateSubType<AxisFeedrateSubTypes>(SubType, out MtconnectValidationException axisFeedrateSubTypeError))
                        {
                            validationErrors.Add(axisFeedrateSubTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.CAPACITY_FLUID:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.CAPACITY_SPATIAL:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.CLOCK_TIME:
                        var iso8601 = new Regex(@"^(?:[1-9]\d{3}-(?:(?:0[1-9]|1[0-2])-(?:0[1-9]|1\d|2[0-8])|(?:0[13-9]|1[0-2])-(?:29|30)|(?:0[13578]|1[02])-31)|(?:[1-9]\d(?:0[48]|[2468][048]|[13579][26])|(?:[2468][048]|[13579][26])00)-02-29)T(?:[01]\d|2[0-3]):[0-5]\d:[0-5]\d(?:Z|[+-][01]\d:[0-5]\d)$");
                        if (!iso8601.IsMatch(Value))
                        {
                            validationErrors.Add(new MtconnectValidationException(
                                ValidationSeverity.ERROR,
                                $"ClockTime MUST be reported in W3C ISO 8601 format.",
                                SourceNode));
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.CONCENTRATION:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.CONDUCTIVITY:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.CUTTING_SPEED:
                        if (!string.IsNullOrEmpty(SubType) && !tryValidateSubType<CuttingSpeedSubTypes>(SubType, out MtconnectValidationException cuttingSpeedSubTypeError))
                        {
                            validationErrors.Add(cuttingSpeedSubTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.DENSITY:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.DEPOSITION_ACCELERATION_VOLUMETRIC:
                        if (!string.IsNullOrEmpty(SubType) && !tryValidateSubType<DepositionAccelerationVolumetricSubTypes>(SubType, out MtconnectValidationException depositionAccelerationVolumetricSubTypeError))
                        {
                            validationErrors.Add(depositionAccelerationVolumetricSubTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.DEPOSITION_DENSITY:
                        if (!string.IsNullOrEmpty(SubType) && !tryValidateSubType<DepositionDensitySubTypes>(SubType, out MtconnectValidationException depositionDensitySubTypeError))
                        {
                            validationErrors.Add(depositionDensitySubTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.DEPOSITION_MASS:
                        if (!string.IsNullOrEmpty(SubType) && !tryValidateSubType<DepositionMassSubTypes>(SubType, out MtconnectValidationException depositionMassSubTypeError))
                        {
                            validationErrors.Add(depositionMassSubTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.DEPOSITION_RATE_VOLUMETRIC:
                        if (!string.IsNullOrEmpty(SubType) && !tryValidateSubType<DepositionRateVolumetricSubTypes>(SubType, out MtconnectValidationException depositionRateVolumetricSubTypeError))
                        {
                            validationErrors.Add(depositionRateVolumetricSubTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.DEPOSITION_VOLUME:
                        if (!string.IsNullOrEmpty(SubType) && !tryValidateSubType<DepositionVolumeSubTypes>(SubType, out MtconnectValidationException depositionVolumeSubTypeError))
                        {
                            validationErrors.Add(depositionVolumeSubTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.DIAMETER:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.DISPLACEMENT:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.ELECTRICAL_ENERGY:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.EQUIPMENT_TIMER:
                        if (!string.IsNullOrEmpty(SubType) && !tryValidateSubType<EquipmentTimerSubTypes>(SubType, out MtconnectValidationException equipmentTimerSubTypeError))
                        {
                            validationErrors.Add(equipmentTimerSubTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.FILL_LEVEL:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.FLOW:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.FREQUENCY:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.GLOBAL_POSITION:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.HUMIDITY_ABSOLUTE:
                        if (!string.IsNullOrEmpty(SubType) && !tryValidateSubType<HumidityAbsoluteSubTypes>(SubType, out MtconnectValidationException humidityAbsoluteSubTypeError))
                        {
                            validationErrors.Add(humidityAbsoluteSubTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.HUMIDITY_RELATIVE:
                        if (!string.IsNullOrEmpty(SubType) && !tryValidateSubType<HumidityRelativeSubTypes>(SubType, out MtconnectValidationException humidityRelativeSubTypeError))
                        {
                            validationErrors.Add(humidityRelativeSubTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.HUMIDITY_SPECIFIC:
                        if (!string.IsNullOrEmpty(SubType) && !tryValidateSubType<HumiditySpecificSubTypes>(SubType, out MtconnectValidationException humiditySpecificSubTypeError))
                        {
                            validationErrors.Add(humiditySpecificSubTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.LENGTH:
                        if (!string.IsNullOrEmpty(SubType) && !tryValidateSubType<LengthSubTypes>(SubType, out MtconnectValidationException lengthSubTypeError))
                        {
                            validationErrors.Add(lengthSubTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.LEVEL:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.LINEAR_FORCE:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.LOAD:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.MASS:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.ORIENTATION:
                        if (Value.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length != 3 || Value.Split(' ', StringSplitOptions.RemoveEmptyEntries).All(o => decimal.TryParse(o, out _)) == false)
                        {
                            validationErrors.Add(new MtconnectValidationException(
                                ValidationSeverity.ERROR,
                                $"ORIENTATION value MUST be three space-delimited floating-point numbers.",
                                SourceNode));
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.PATH_FEEDRATE:
                        if (!string.IsNullOrEmpty(SubType) && !tryValidateSubType<PathFeedrateSubTypes>(SubType, out MtconnectValidationException pathFeedrateSubTypeError))
                        {
                            validationErrors.Add(pathFeedrateSubTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.PATH_FEEDRATE_PER_REVOLUTION:
                        if (!string.IsNullOrEmpty(SubType) && !tryValidateSubType<PathFeedratePerRevolutionSubTypes>(SubType, out MtconnectValidationException pathFeedratePerRevolutionSubTypeError))
                        {
                            validationErrors.Add(pathFeedratePerRevolutionSubTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.PATH_POSITION:
                        if (!string.IsNullOrEmpty(SubType) && !tryValidateSubType<PathPositionSubTypes>(SubType, out MtconnectValidationException pathPositionSubTypeError))
                        {
                            validationErrors.Add(pathPositionSubTypeError);
                        } else if (!Value.Split(' ', StringSplitOptions.RemoveEmptyEntries).All(o => decimal.TryParse(o, out _)))
                        {
                            validationErrors.Add(new MtconnectValidationException(
                                ValidationSeverity.ERROR,
                                $"PATH_POSITION value MUST be reported as a set of space-delimited floating-point numbers.",
                                SourceNode));
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.PH:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.POSITION:
                        if (!string.IsNullOrEmpty(SubType) && !tryValidateSubType<PositionSubTypes>(SubType, out MtconnectValidationException positionSubTypeError))
                        {
                            validationErrors.Add(positionSubTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.POWER_FACTOR:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.PRESSURE:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.PROCESS_TIMER:
                        if (!tryValidateSubType<ProcessTimerSubTypes>(SubType, out MtconnectValidationException processTimerSubTypeError))
                        {
                            validationErrors.Add(processTimerSubTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.RESISTANCE:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.ROTARY_VELOCITY:
                        if (!string.IsNullOrEmpty(SubType) && !tryValidateSubType<RotaryVelocitySubTypes>(SubType, out MtconnectValidationException rotaryVelocityTypeError))
                        {
                            validationErrors.Add(rotaryVelocityTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.SOUND_LEVEL:
                        if (!string.IsNullOrEmpty(SubType) && !tryValidateSubType<SoundLeveSubTypes>(SubType, out MtconnectValidationException soundLevelTypeError))
                        {
                            validationErrors.Add(soundLevelTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.SPINDLE_SPEED:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.STRAIN:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.TEMPERATURE:
                        if (!string.IsNullOrEmpty(SubType) && !tryValidateSubType<TemperatureSubTypes>(SubType, out MtconnectValidationException temperatureTypeError))
                        {
                            validationErrors.Add(temperatureTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.TENSION:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.TILT:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.TORQUE:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.VELOCITY:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.VISCOSITY:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.VOLTAGE:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.VOLTAGE_AC:
                        if (!string.IsNullOrEmpty(SubType) && !tryValidateSubType<VoltageAcSubTypes>(SubType, out MtconnectValidationException voltageAcTypeError))
                        {
                            validationErrors.Add(voltageAcTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.VOLTAGE_DC:
                        if (!string.IsNullOrEmpty(SubType) && !tryValidateSubType<VoltageDcSubTypes>(SubType, out MtconnectValidationException voltageDcTypeError))
                        {
                            validationErrors.Add(voltageDcTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.VOLT_AMPERE:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.VOLT_AMPERE_REACTIVE:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.VOLUME_FLUID:
                        if (!string.IsNullOrEmpty(SubType) && !tryValidateSubType<VolumeFluidSubTypes>(SubType, out MtconnectValidationException volumeFluidTypeError))
                        {
                            validationErrors.Add(volumeFluidTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.VOLUME_SPATIAL:
                        if (!string.IsNullOrEmpty(SubType) && !tryValidateSubType<VolumeSpatialSubTypes>(SubType, out MtconnectValidationException volumeSpatialTypeError))
                        {
                            validationErrors.Add(volumeSpatialTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.WATTAGE:
                        if (!string.IsNullOrEmpty(SubType) && !tryValidateSubType<WattageSubTypes>(SubType, out MtconnectValidationException wattageTypeError))
                        {
                            validationErrors.Add(wattageTypeError);
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.X_DIMENSION:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.Y_DIMENSION:
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.Z_DIMENSION:
                        break;
                    default:
                        break;
                }
            }

            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
