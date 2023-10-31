using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices;
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
        public override CategoryTypes Category => CategoryTypes.SAMPLE;

        /// <summary>
        /// Collected from the sampleRate attribute. Refer to Part 3 Streams - 5.3.2
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(SampleAttributes.SAMPLE_RATE)]
        public float? SampleRate { get; set; }

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
        public string ResetTriggered { get; set; }

        /// <summary>
        /// Collected from the textcontent of the Sample element. Refer to Part 3 Streams - 5.3.3
        /// </summary>
        public float? Value {
            get {
                if (float.TryParse(Result, out float result))
                    return result;
                return null;
            }
            set {
                Result = value.ToString();
            }
        }

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
            string[] timeSeriesValues = SourceNode.InnerText.Split(new[] { " " }, System.StringSplitOptions.RemoveEmptyEntries);
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
            => base.validateNode(out validationErrors);

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8")]
        protected override bool validateValue(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();

            if (Enum.TryParse<MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.SampleTypes>(SourceNode.LocalName, out MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.SampleTypes type))
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
                        break;
                }
            }

            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
