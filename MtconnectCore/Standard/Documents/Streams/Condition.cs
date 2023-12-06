using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class Condition : Value
    {
        public override CategoryTypes Category => CategoryTypes.CONDITION;

        /// <summary>
        /// Collected from the nativeCode attribute. Refer to Part 3 Streams - 5.8.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(ConditionAttributes.NATIVE_CODE)]
        public string NativeCode { get; set; }

        /// <summary>
        /// Collected from the nativeSeverity attribute. Refer to Part 3 Streams - 5.8.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(ConditionAttributes.NATIVE_SEVERITY)]
        public string NativeSeverity { get; set; }

        /// <summary>
        /// Collected from the qualifier attribute. Refer to Part 3 Streams - 5.8.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        // TODO: Validate Enum
        [MtconnectNodeAttribute(ConditionAttributes.QUALIFIER)]
        public string Qualifier { get; set; }

        /// <summary>
        /// Collected from the statistic attribute. Refer to Part 3 Streams - 5.8.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        // TODO: Validate Enum
        [MtconnectNodeAttribute(ConditionAttributes.STATISTIC)]
        public string Statistic { get; set; }

        /// <summary>
        /// Collected from the xs:lang attribute. Refer to Part 3 Streams - 5.8.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute("lang", XmlNamespace = "xs")]
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

        public ConditionElements? State { get; set; }

        /// <inheritdoc/>
        public Condition() : base() { }

        /// <inheritdoc/>
        public Condition(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version)
        {
            Result = xNode.InnerText;
            if (Enum.TryParse<ConditionElements>(TagName, out ConditionElements condition))
            {
                State = condition;
            }
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "See model.mtconnect.org/Observation Information Model/Condition")]
        private bool validateType(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Condition MUST include a 'type' attribute.",
                    SourceNode));
            }
            else if (!EnumHelper.Contains<Contracts.Enums.Devices.DataItemTypes.ConditionTypes>(Type)
                && !EnumHelper.Contains<Contracts.Enums.Devices.DataItemTypes.EventTypes>(Type)
                && !EnumHelper.Contains<Contracts.Enums.Devices.DataItemTypes.SampleTypes>(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Condition 'type' attribute must be of Condition, Event, or Sample types.",
                    SourceNode));
            }
            else if (!EnumHelper.ValidateToVersion<Contracts.Enums.Devices.DataItemTypes.ConditionTypes>(Type, MtconnectVersion.GetValueOrDefault())
                && !EnumHelper.ValidateToVersion<Contracts.Enums.Devices.DataItemTypes.EventTypes>(Type, MtconnectVersion.GetValueOrDefault())
                && !EnumHelper.ValidateToVersion<Contracts.Enums.Devices.DataItemTypes.SampleTypes>(Type, MtconnectVersion.GetValueOrDefault()))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.WARNING,
                    $"Condition type of '{Type}' is not supported in version '{MtconnectVersion}' of the MTConnect Standard.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "See model.mtconnect.org/Observation Information Model/Condition")]
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

        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "See model.mtconnect.org/Observation Information Model/Condition")]
        protected bool validateQualifier(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(Qualifier))
            {
                if (!EnumHelper.Contains<QualifierTypes>(Qualifier))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.ERROR,
                        $"Observation 'qualifier' is unrecognized as '{Qualifier}'.",
                        SourceNode));
                }
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }


        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "See model.mtconnect.org/Observation Information Model/Sample")]
        protected override bool validateNode(out ICollection<MtconnectValidationException> validationErrors)
            => base.validateNode(out validationErrors);

        protected override bool validateValue(out ICollection<MtconnectValidationException> validationErrors) => throw new NotImplementedException();
    }
}
