using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
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

        protected override bool validateValue(out ICollection<MtconnectValidationException> validationErrors) => throw new System.NotImplementedException();
    }
}
