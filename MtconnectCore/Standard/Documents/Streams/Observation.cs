using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices;
using MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    public abstract class Observation : MtconnectNode, IObservation
    {
        public abstract CategoryTypes Category { get; }

        /// <inheritdoc cref="ObservationAttributes.COMPOSITION_ID"/>
        [MtconnectNodeAttribute(ObservationAttributes.COMPOSITION_ID)]
        public string CompositionId { get; internal set; }

        /// <inheritdoc cref="ObservationAttributes.DATA_ITEM_ID"/>
        [MtconnectNodeAttribute(ObservationAttributes.DATA_ITEM_ID)]
        public string DataItemId { get; internal set; }

        /// <inheritdoc cref="ObservationAttributes.NAME"/>
        [MtconnectNodeAttribute(ObservationAttributes.NAME)]
        public string Name { get; internal set; }

        /// <inheritdoc cref="ObservationAttributes.SEQUENCE"/>
        [MtconnectNodeAttribute(ObservationAttributes.SEQUENCE)]
        public ulong Sequence { get; set; }

        /// <inheritdoc cref="ObservationAttributes.SUB_TYPE"/>
        [MtconnectNodeAttribute(ObservationAttributes.SUB_TYPE)]
        public string SubType { get; internal set; }

        /// <inheritdoc cref="ObservationAttributes.TIMESTAMP"/>
        [MtconnectNodeAttribute(SampleAttributes.TIMESTAMP)]
        public DateTime Timestamp { get; set; }

        /// <inheritdoc cref="ObservationAttributes.TYPE"/>
        [MtconnectNodeAttribute(ObservationAttributes.TYPE)]
        public string Type { get; internal set; }

        /// <inheritdoc cref="ObservationAttributes.UNITS"/>
        [MtconnectNodeAttribute(ObservationAttributes.UNITS)]
        public string Units { get; internal set; }

        /// <inheritdoc cref="ObservationAttributes.IS_UNAVAILABLE"/>
        [MtconnectNodeAttribute(ObservationAttributes.IS_UNAVAILABLE)]
        public virtual bool IsUnavailable { get; } = true;

        /// <inheritdoc cref="ObservationAttributes.RESULT"/>
        [MtconnectNodeAttribute(ObservationAttributes.RESULT)]
        public string Result { get; set; }

        /// <summary>
        /// Reference to the name of the element. Refer to Part 3 Streams - 5.5
        /// </summary>
        public string TagName { get; set; }

        /// <inheritdoc/>
        public Observation() : base() { }

        /// <inheritdoc/>
        public Observation(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE, version)
        {
            Result = xNode.InnerText;
            TagName = xNode.LocalName;

            if (string.IsNullOrEmpty(Type) && Category != CategoryTypes.CONDITION)
            {
                if (TagName.EndsWith("DataSet"))
                {
                    Type = TagName.Substring(0, TagName.LastIndexOf("DataSet"));
                }
                else if (TagName.EndsWith("Table"))
                {
                    Type = TagName.Substring(0, TagName.LastIndexOf("Table"));
                }
                else
                {
                    Type = TagName;
                }
            }
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.1 and 3.8")]
        protected bool validateDataItemId(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(DataItemId))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Observation MUST include a 'dataItemId' attribute.",
                        SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.1 and 3.8")]
        protected bool validateTimestamp(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (Timestamp == null)
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Observation MUST include a 'timestamp' attribute.",
                        SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.1 and 3.8")]
        protected bool validateUnits(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(Units))
            {
                if (!EnumHelper.Contains<UnitsTypes>(Units))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.ERROR,
                        $"Observation units of '{Units}' is not defined in the MTConnect Standard in version '{MtconnectVersion}'.",
                            SourceNode));
                }
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.1 and 3.8")]
        protected bool validateSequence(out ICollection<MtconnectValidationException> validationErrors)
        {
            const long sequenceCeiling = (2 ^ 64) - 1;
            validationErrors = new List<MtconnectValidationException>();
            if (Sequence < 1 && Sequence > sequenceCeiling)
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Observation MUST include a 'sequence' attribute.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        protected abstract bool validateValue(out ICollection<MtconnectValidationException> validationErrors);

        protected virtual bool validateNode(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();

            ICollection<MtconnectValidationException> extensionErrors = new List<MtconnectValidationException>();
            switch (Category)
            {
                case CategoryTypes.SAMPLE:
                    validateNodeExtension<SampleTypes>(out extensionErrors);
                    break;
                case CategoryTypes.EVENT:
                    validateNodeExtension<EventTypes>(out extensionErrors);
                    break;
                case CategoryTypes.CONDITION:
                    var conditionIsValid = validateNodeExtension<ConditionTypes>(out var conditionErrors);
                    var eventIsValid = validateNodeExtension<EventTypes>(out var eventErrors);
                    var sampleIsValid = validateNodeExtension<SampleTypes>(out var sampleErrors);
                    if (!(conditionIsValid || eventIsValid || sampleIsValid))
                    {
                        extensionErrors.Add(new MtconnectValidationException(
                            ValidationSeverity.ERROR,
                            $"Observation '{DataItemId}' type of '{Type}' is not defined in the MTConnect Standard for category '{Category}' in version '{MtconnectVersion}'.",
                            SourceNode));
                    }
                    else if (conditionIsValid && conditionErrors.Any())
                    {
                        foreach (var error in conditionErrors)
                            extensionErrors.Add(error);
                    }
                    else if (eventIsValid && eventErrors.Any())
                    {
                        foreach (var error in eventErrors)
                            extensionErrors.Add(error);
                    }
                    else if (sampleIsValid && sampleErrors.Any())
                    {
                        foreach (var error in sampleErrors)
                            extensionErrors.Add(error);
                    }
                    break;
                default:
                    break;
            }

            if (extensionErrors.Any())
            {
                validationErrors = extensionErrors;
                return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
            }

            ICollection<MtconnectValidationException> standardErrors = new List<MtconnectValidationException>();
            switch (Category)
            {
                case CategoryTypes.SAMPLE:
                    validateNodeInStandard<SampleTypes>(out standardErrors);
                    break;
                case CategoryTypes.EVENT:
                    validateNodeInStandard<EventTypes>(out standardErrors);
                    break;
                case CategoryTypes.CONDITION:
                    var conditionIsValid = validateNodeInStandard<ConditionTypes>(out var conditionErrors);
                    var eventIsValid = validateNodeInStandard<EventTypes>(out var eventErrors);
                    var sampleIsValid = validateNodeInStandard<SampleTypes>(out var sampleErrors);
                    if (!(conditionIsValid || eventIsValid || sampleIsValid))
                    {
                        standardErrors.Add(new MtconnectValidationException(
                            ValidationSeverity.ERROR,
                            $"Observation '{DataItemId}' type of '{Type}' is not defined in the MTConnect Standard for category '{Category}' in version '{MtconnectVersion}'.",
                            SourceNode));
                    }
                    else if (conditionIsValid && conditionErrors.Any())
                    {
                        foreach (var error in conditionErrors)
                            standardErrors.Add(error);
                    }
                    else if (eventIsValid && eventErrors.Any())
                    {
                        foreach (var error in eventErrors)
                            standardErrors.Add(error);
                    }
                    else if (sampleIsValid && sampleErrors.Any())
                    {
                        foreach (var error in sampleErrors)
                            standardErrors.Add(error);
                    }
                    break;
                default:
                    break;
            }

            if (standardErrors.Any())
            {
                validationErrors = standardErrors;
            }

            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        protected bool validateNodeExtension<T>(out ICollection<MtconnectValidationException> validationErrors) where T: Enum
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(this.SourceNode.Name))
            {
                if (SourceNode.Name.StartsWith("x:"))
                {
                    if (validateNodeInStandard<T>(out ICollection<MtconnectValidationException> inStandardErrors))
                    {
                        validationErrors.Add(new MtconnectValidationException(
                            ValidationSeverity.WARNING,
                            $"Observation '{DataItemId}' type of '{SourceNode.Name}' is an unnecessary extension of the MTConnect Standard for category '{Category}' as it already exists in version '{MtconnectVersion}'.",
                            SourceNode));
                    } else
                    {
                        validationErrors.Add(new MtconnectValidationException(
                            ValidationSeverity.MESSAGE,
                            $"Observation '{DataItemId}' type of '{SourceNode.Name}' is an extension of the MTConnect Standard in for category '{Category}' this implementation.",
                            SourceNode));
                    }
                }
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        protected bool validateNodeInStandard<T>(out ICollection<MtconnectValidationException> validationErrors) where T : Enum
        {
            bool isValidType = true, isValidSubType = true;
            validationErrors = new List<MtconnectValidationException>();

            // Validate the observational type
            if (!EnumHelper.Contains<T>(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Observation '{DataItemId}' type of '{Type}' is not defined in the MTConnect Standard for category '{Category}' in version '{MtconnectVersion}'.",
                    SourceNode));
                isValidType = false;
            }
            else if (!EnumHelper.ValidateToVersion<T>(Type, MtconnectVersion.GetValueOrDefault()))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.WARNING,
                    $"Observation '{DataItemId}' type of '{Type}' is not valid for category '{Category}' in version '{MtconnectVersion}' of the MTConnect Standard.",
                    SourceNode));
                isValidType = false;
            }

            if (isValidType)
            {
                // Get the Enum and look for an attribute pointing to the SubType enum
                Type enumType = typeof(T);
                MemberInfo[] typeValueInfos = enumType.GetMember(EnumHelper.Enumify(Type));
                var valueInfo = typeValueInfos.FirstOrDefault(o => o.DeclaringType == enumType);
                var obsSubType = valueInfo?.GetCustomAttribute<ObservationalSubTypeAttribute>();
                // Validate the observational sub-type
                if (obsSubType != null && Category != CategoryTypes.CONDITION)
                {
                    if (string.IsNullOrEmpty(SubType))
                    {
                        validationErrors.Add(new MtconnectValidationException(
                            ValidationSeverity.ERROR,
                            $"Observation '{DataItemId}' type '{SourceNode.LocalName}' is missing a subType",
                            SourceNode));
                        isValidSubType = false;
                    } else if (!EnumHelper.Contains(obsSubType.SubTypeEnum, SubType))
                    {
                        validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.ERROR,
                            $"Observation '{DataItemId}' subType of '{SubType}' is not defined in the MTConnect Standard for category '{Category}' and type '{SourceNode.LocalName}' in version '{MtconnectVersion}'.",
                            SourceNode));
                        isValidSubType = false;
                    }
                    else if (!EnumHelper.ValidateToVersion(obsSubType.SubTypeEnum, SubType, MtconnectVersion.GetValueOrDefault()))
                    {
                        validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                            $"Observation '{DataItemId}' subType of '{SubType}' is not valid for category '{Category}' and type '{SourceNode.LocalName}' in version '{MtconnectVersion}' of the MTConnect Standard.",
                            SourceNode));
                        isValidSubType = false;
                    }
                }
            }

            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
