using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System;
using System.Collections.Generic;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class Sample : Value
    {
        private const string MODEL_BROWSER_URL = "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531116_175117_25733";

        public override CategoryEnum Category => CategoryEnum.SAMPLE;

        /// <inheritdoc cref="SampleAttributes.SAMPLE_RATE"/>
        [MtconnectNodeAttribute(SampleAttributes.SAMPLE_RATE)]
        public string SampleRate { get; set; }

        /// <inheritdoc cref="SampleAttributes.STATISTIC"/>
        [MtconnectNodeAttribute(SampleAttributes.STATISTIC)]
        public string Statistic { get; set; }

        /// <inheritdoc cref="SampleAttributes.DURATION"/>
        [MtconnectNodeAttribute(SampleAttributes.DURATION)]
        public string Duration { get; set; }

        /// <inheritdoc cref="SampleAttributes.RESET_TRIGGERED"/>
        [MtconnectNodeAttribute(SampleAttributes.RESET_TRIGGERED)]
        public string ResetTriggered { get; set; }

        /// <summary>
        /// Collected from the textcontent of the Sample element. Refer to Part 3 Streams - 5.3.3
        /// </summary>
        [Obsolete("Use Result instead")]
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

        /// <inheritdoc/>
        public Sample() : base() { }

        /// <inheritdoc/>
        public Sample(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }


        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.ObservationModel.SAMPLE)]
        private bool validateValueProperties(out ICollection<MtconnectValidationException> validationErrors)
            => new NodeValidationContext(this)
            // duration
            .ValidateValueProperty<SampleAttributes>(nameof(SampleAttributes.DURATION), (o) =>
                o.IsImplemented(Duration)
                ?.IsUIntValueType(Duration, out _)
            )
            // resetTriggered
            .ValidateValueProperty<SampleAttributes>(nameof(SampleAttributes.RESET_TRIGGERED), (o) =>
                o.IsImplemented(ResetTriggered)
                ?.IsEnumValueType<ResetTriggeredEnum>(ResetTriggered, out _)
            )
            // sampleRate
            .ValidateValueProperty<SampleAttributes>(nameof(SampleAttributes.SAMPLE_RATE), (o) =>
                o.IsImplemented(SampleRate)
                ?.IsFloatValueType(SampleRate, out _)
            )
            // statistic
            .ValidateValueProperty<SampleAttributes>(nameof(SampleAttributes.STATISTIC), (o) =>
                o.IsImplemented(Statistic)
                ?.IsEnumValueType<StatisticEnum>(Statistic, out _)
            )
            // units
            .ValidateValueProperty<SampleAttributes>(nameof(SampleAttributes.UNITS), (o) =>
                o.IsImplemented()
                ?.IsEnumValueType<UnitEnum>(Units, out _)
            )
            // result
            .Validate((o) =>
                o.ValidateSampleObservationResult(Type, Result)
            )
            .UpdateHelpLinks(MODEL_BROWSER_URL)
            .HasError(out validationErrors);
    }
}
