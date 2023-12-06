using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class SampleTimeSeries : Sample, ITimeSeries
    {
        /// <summary>
        /// Description of a means to interpret data consisting of multiple data points or samples reported as a single value.
        /// </summary>
        [MtconnectNodeAttribute(DataItemAttributes.REPRESENTATION)]
        public override string Representation { get; set; } = RepresentationTypes.TIME_SERIES.ToString();

        public new float[] Result { get; set; }

        public override bool IsUnavailable => Result != null && Result.Length >= 1;

        /// <inheritdoc/>
        public SampleTimeSeries() : base() { }

        /// <inheritdoc/>
        public SampleTimeSeries(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version)
        {
            string[] stringValues = xNode.InnerText.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Result = stringValues.Select(o =>
                    float.TryParse(o, out float value)
                    ? new ParseResult{ Success = true, Value = value }
                    : new ParseResult { Success = false, Value = null }
                )
                .Where(o => o.Success)
                .Select(o => o.Value.GetValueOrDefault())
                .ToArray();
        }

        private struct ParseResult
        {
            internal bool Success;
            internal float? Value;
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "See model.mtconnect.org/Observation Information Model/Representations/TimeSeries")]
        private bool validateSampleCount(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (SampleCount != Result?.Length)
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"TimeSeries 'sampleCount' MUST equal the number of result values.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
