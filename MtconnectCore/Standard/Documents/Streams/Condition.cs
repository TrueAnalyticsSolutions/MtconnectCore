using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System;
using System.Collections.Generic;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class Condition : Value
    {
        private const string MODEL_BROWSER_URL = "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531113_85883_25726";

        public override CategoryEnum Category => CategoryEnum.CONDITION;

        /// <inheritdoc cref="ConditionAttributes.NATIVE_CODE"/>
        [MtconnectNodeAttribute(ConditionAttributes.NATIVE_CODE)]
        public string NativeCode { get; set; }

        /// <inheritdoc cref="ConditionAttributes.NATIVE_SEVERITY"/>
        [MtconnectNodeAttribute(ConditionAttributes.NATIVE_SEVERITY)]
        public string NativeSeverity { get; set; }

        /// <inheritdoc cref="ConditionAttributes.QUALIFIER"/>
        [MtconnectNodeAttribute(ConditionAttributes.QUALIFIER)]
        public string Qualifier { get; set; }

        /// <inheritdoc cref="ConditionAttributes.STATISTIC"/>
        [MtconnectNodeAttribute(ConditionAttributes.STATISTIC)]
        public string Statistic { get; set; }

        /// <inheritdoc cref="ConditionAttributes.CONDITION_ID"/>
        [MtconnectNodeAttribute(ConditionAttributes.CONDITION_ID)]
        public string ConditionId { get; set; }

        /// <summary>
        /// Collected from the xs:lang attribute. Refer to Part 3 Streams - 5.8.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute("lang")] // xs:lang
        public string Language { get; set; }

        /// <summary>
        /// Collected from the textcontent of the Event element. Refer to Part 3 Streams - 5.8.4
        /// </summary>
        [Obsolete]
        public string Value {
            get {
                return Result;
            }
            set {
                Result = value;
            }
        }

        public string State { get; set; }

        /// <inheritdoc/>
        public Condition() : base() { }

        /// <inheritdoc/>
        public Condition(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version)
        {
            Result = xNode.InnerText;
            if (Enum.TryParse<ConditionElements>(TagName, out ConditionElements condition))
            {
                State = condition.ToString();
            }
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.ObservationModel.CONDITION)]
        private bool validateValueProperties(out ICollection<MtconnectValidationException> validationErrors)
            => new NodeValidationContext(this)
            // nativeCode
            .ValidateValueProperty<ConditionAttributes>(nameof(ConditionAttributes.NATIVE_CODE), (o) =>
                o.IsImplemented(NativeCode)
            )
            // nativeSeverity
            .ValidateValueProperty<ConditionAttributes>(nameof(ConditionAttributes.NATIVE_SEVERITY), (o) =>
                o.IsImplemented(NativeSeverity)
            )
            // qualifier
            .ValidateValueProperty<ConditionAttributes>(nameof(ConditionAttributes.QUALIFIER), (o) =>
                o.IsImplemented(Qualifier)
                ?.IsEnumValueType<QualifierEnum>(Qualifier, out _)
            )
            // statistic
            .ValidateValueProperty<ConditionAttributes>(nameof(ConditionAttributes.STATISTIC), (o) =>
                o.IsImplemented(Statistic)
                ?.IsEnumValueType<StatisticEnum>(Statistic, out _)
            )
            // xs:lang
            .ValidateValueProperty<ConditionAttributes>(nameof(ConditionAttributes.XS_LANG), (o) =>
                o.IsImplemented(Language)
                ?.IsRfc4646LanguageTag(Language)
            )
            // state
            .ValidateValueProperty<ConditionAttributes>(nameof(ConditionAttributes.STATE), (o) =>
                o.IsImplemented(State)
                ?.IsEnumValueType<ConditionElements>(State, out _)
            )
            // conditionId
            .ValidateValueProperty<ConditionAttributes>(nameof(ConditionAttributes.CONDITION_ID), (o) =>
                o.WhileIntroduced((x) =>
                    x.IsImplemented()
                    .IsRequired(ConditionId)
                )
                ?.WhileNotIntroduced((x) =>
                    x.IsImplemented(ConditionId)
                )
            )
            .HasError(out validationErrors);
    }
}
