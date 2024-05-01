using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices;
using MtconnectCore.Standard.Contracts.Enums.Streams;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class Sample : Value
    {
        private const string MODEL_BROWSER_URL = "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531116_175117_25733";

        public override CategoryTypes Category => CategoryTypes.SAMPLE;

        /// <inheritdoc cref="SampleAttributes.SAMPLE_RATE"/>
        [MtconnectNodeAttribute(SampleAttributes.SAMPLE_RATE)]
        public float? SampleRate { get; set; }

        /// <inheritdoc cref="SampleAttributes.STATISTIC"/>
        [MtconnectNodeAttribute(SampleAttributes.STATISTIC)]
        public string Statistic { get; set; }

        /// <inheritdoc cref="SampleAttributes.DURATION"/>
        [MtconnectNodeAttribute(SampleAttributes.DURATION)]
        public double? Duration { get; set; }

        /// <inheritdoc cref="SampleAttributes.RESET_TRIGGERED"/>
        [MtconnectNodeAttribute(SampleAttributes.RESET_TRIGGERED)]
        public string ResetTriggered { get; set; }

        /// <summary>
        /// Collected from the textcontent of the Sample element. Refer to Part 3 Streams - 5.3.3
        /// </summary>
        public virtual float? Value {
            get {
                if (float.TryParse(Result, out float result))
                    return result;
                return null;
            }
            set {
                Result = value.ToString();
            }
        }

        /// <inheritdoc cref="SampleAttributes.SAMPLE_COUNT"/>
        [MtconnectNodeAttribute(SampleAttributes.SAMPLE_COUNT)]
        public int? SampleCount { get; set; }

        /// <inheritdoc/>
        public Sample() : base() { }

        /// <inheritdoc/>
        public Sample(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, MODEL_BROWSER_URL)]
        protected bool validateTimeSeriesCount(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            string[] timeSeriesValues = SourceNode.InnerText.Split(new[] { " " }, System.StringSplitOptions.RemoveEmptyEntries);
            // TODO: Validate when position is 3D
            if (timeSeriesValues.Length > 1 && timeSeriesValues.Length != SampleCount.GetValueOrDefault() && timeSeriesValues.Length != 3){
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Observation result space-delimited value count MUST match the 'sampleCount'.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, MODEL_BROWSER_URL)]
        protected bool validateDuration(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(Statistic) && !Duration.HasValue)
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Observation MUST include 'duration' attribute when the 'statistic' attribute is present.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, MODEL_BROWSER_URL)]
        protected bool validateStatistic(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(Statistic))
            {
                if (!EnumHelper.Contains<StatisticTypes>(Statistic))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.ERROR,
                        $"Observation 'statistic' is unrecognized as '{Statistic}'.",
                        SourceNode));
                }
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, MODEL_BROWSER_URL)]
        protected bool validateResetTriggered(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(ResetTriggered))
            {
                if (!EnumHelper.Contains<ResetTriggeredValues>(ResetTriggered))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.ERROR,
                        $"Observation 'resetTriggered' of '{ResetTriggered}' is not defined in the MTConnect Standard in version '{MtconnectVersion}'.",
                            SourceNode));
                }
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL)]
        protected override bool validateNode(out ICollection<MtconnectValidationException> validationErrors)
            => base.validateNode(out validationErrors);

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL)]
        protected override bool validateValue(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();

            if (Enum.TryParse<MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.SampleTypes>(Type, out MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.SampleTypes type))
            {
                // NOTE: Only validate the VALUE, not the Sub-Type
                switch (type)
                {
                    //case Contracts.Enums.Devices.DataItemTypes.SampleTypes.CLOCK_TIME:
                    //    var iso8601 = new Regex(@"^(?:[1-9]\d{3}-(?:(?:0[1-9]|1[0-2])-(?:0[1-9]|1\d|2[0-8])|(?:0[13-9]|1[0-2])-(?:29|30)|(?:0[13578]|1[02])-31)|(?:[1-9]\d(?:0[48]|[2468][048]|[13579][26])|(?:[2468][048]|[13579][26])00)-02-29)T(?:[01]\d|2[0-3]):[0-5]\d:[0-5]\d(?:Z|[+-][01]\d:[0-5]\d)$");
                    //    if (!iso8601.IsMatch(Value))
                    //    {
                    //        validationErrors.Add(new MtconnectValidationException(
                    //            ValidationSeverity.ERROR,
                    //            $"ClockTime MUST be reported in W3C ISO 8601 format.",
                    //            SourceNode));
                    //    }
                    //    break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.ORIENTATION:
                        if (SourceNode.InnerText.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length != 3 || SourceNode.InnerText.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).All(o => float.TryParse(o, out _)) == false)
                        {
                            validationErrors.Add(new MtconnectValidationException(
                                ValidationSeverity.ERROR,
                                $"ORIENTATION value MUST be three space-delimited floating-point numbers.",
                                SourceNode));
                        }
                        break;
                    case Contracts.Enums.Devices.DataItemTypes.SampleTypes.PATH_POSITION:
                        if (!SourceNode.InnerText.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).All(o => float.TryParse(o, out _)))
                        {
                            validationErrors.Add(new MtconnectValidationException(
                                ValidationSeverity.ERROR,
                                $"PATH_POSITION value MUST be reported as a set of space-delimited floating-point numbers.",
                                SourceNode));
                        }
                        break;
                    default:
                        validateUnavailableFloatValue(validationErrors);
                        break;
                }
            } else
            {
                validateUnavailableFloatValue(validationErrors);
            }

            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        private void validateUnavailableFloatValue(ICollection<MtconnectValidationException> validationErrors)
        {
            if (!string.IsNullOrEmpty(Result))
            {
                if (Result == Constants.UNAVAILABLE)
                {
                    return;
                } else if (Value == null)
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.ERROR,
                        $"SAMPLE result MUST be a float value.",
                        SourceNode));
                }
            } else
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"SAMPLE result MUST contain a value.",
                    SourceNode));
            }
        }
    }
}
