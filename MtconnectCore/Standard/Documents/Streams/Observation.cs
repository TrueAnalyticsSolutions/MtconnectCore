using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices;
using MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    /// <summary>
    /// abstract entity that provides telemetry data for a  DataItem at a point in time.
    /// </summary>
    public abstract class Observation : MtconnectNode, IObservation
    {
        private const string MODEL_BROWSER_URL = "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531115_47734_25731";

        public abstract CategoryEnum Category { get; }

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
        public string Sequence { get; set; }

        /// <inheritdoc cref="ObservationAttributes.SUB_TYPE"/>
        [MtconnectNodeAttribute(ObservationAttributes.SUB_TYPE)]
        public string SubType { get; internal set; }

        /// <inheritdoc cref="ObservationAttributes.TIMESTAMP"/>
        [MtconnectNodeAttribute(ObservationAttributes.TIMESTAMP)]
        public string Timestamp { get; set; }

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
        public virtual string Result { get; set; }

        /// <summary>
        /// Reference to the name of the element. Refer to Part 3 Streams - 5.5
        /// </summary>
        public string TagName { get; set; }

        /// <inheritdoc/>
        public Observation() : base() { }

        /// <inheritdoc/>
        public Observation(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version)
        {
            Result = xNode.InnerText;
            TagName = xNode.LocalName;

            if (string.IsNullOrEmpty(Type) && Category != CategoryEnum.CONDITION)
            {
                if (TagName.EndsWith("DataSet"))
                {
                    Type = TagName.Substring(0, TagName.LastIndexOf("DataSet"));
                }
                else if (TagName.EndsWith("Table"))
                {
                    Type = TagName.Substring(0, TagName.LastIndexOf("Table"));
                }
                else if (TagName.EndsWith("TimeSeries"))
                {
                    Type = TagName.Substring(0, TagName.LastIndexOf("TimeSeries"));
                }
                else
                {
                    Type = TagName;
                }
            }
        }


        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL)]
        private bool validateValueProperties(out ICollection<MtconnectValidationException> validationErrors)
            => new NodeValidationContext(this)
            // compositionId
            .ValidateValueProperty<ObservationAttributes>(nameof(ObservationAttributes.COMPOSITION_ID), (o) =>
                o.IsImplemented(CompositionId)
                ?.IsIdValueType(CompositionId, false)
            )
            // dataItemId
            .ValidateValueProperty<ObservationAttributes>(nameof(ObservationAttributes.DATA_ITEM_ID), (o) =>
                o.WhileIntroduced((x) =>
                    x.IsIdValueType(DataItemId)
                )
                ?.WhileNotIntroduced((x) =>
                    x.IsIdValueType(DataItemId, false)
                )
            )
            // name
            .ValidateValueProperty<ObservationAttributes>(nameof(ObservationAttributes.NAME), (o) =>
                o.IsImplemented(Name)
            )
            // sequence
            .ValidateValueProperty<ObservationAttributes>(nameof(ObservationAttributes.SEQUENCE), (o) =>
                o.WhileIntroduced((x) =>
                    x.IsImplemented()
                    .IsRequired(Sequence)
                )
                ?.WhileNotIntroduced((x) =>
                    x.IsImplemented(Sequence)
                )
                ?.IsUIntValueType(Sequence, out _)
                ?.IsUIntWithinRange(Sequence, 1, (2^64) - 1)
            )
            // type/subType
            .ValidateValueProperty<ObservationAttributes>(nameof(ObservationAttributes.TYPE), (o) =>
                o.IsImplemented(Type)
                ?.IsRequired(Type)
                ?.ValidateType(Category.ToString(), Type, SubType)
            )
            // timestamp
            .ValidateValueProperty<ObservationAttributes>(nameof(ObservationAttributes.TIMESTAMP), (o) =>
                o.IsImplemented(Timestamp)
                ?.IsRequired(Timestamp)
                ?.IsDateTimeValueType(Timestamp, out _)
            )
            // units
            .ValidateValueProperty<ObservationAttributes>(nameof(ObservationAttributes.UNITS), (o) =>
                o.IsImplemented(Units)
                ?.IsEnumValueType<UnitEnum>(Units, out _)
            )
            .UpdateHelpLinks(MODEL_BROWSER_URL)
            .HasError(out validationErrors);

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL)]
        //protected bool validateDataItemId(out ICollection<MtconnectValidationException> validationErrors) {
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (string.IsNullOrEmpty(DataItemId))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Observation MUST include a 'dataItemId' attribute.",
        //                SourceNode));
        //    }
        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL, MtconnectVersions.V_1_1_0)]
        //protected bool validateName_Required(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (string.IsNullOrEmpty(Name))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Observation MUST include a 'name' attribute.",
        //            SourceNode));
        //    }
        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL)]
        //protected bool validateTimestamp(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (Timestamp == null)
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Observation MUST include a 'timestamp' attribute.",
        //                SourceNode));
        //    }
        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL)]
        //protected bool validateUnits(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();

        //    if (!string.IsNullOrEmpty(Units))
        //    {
        //        if (Units.Contains(":"))
        //        {
        //            string extendedUnits = Units.Substring(Units.LastIndexOf(":") + 1);
        //            if (!EnumHelper.Contains<UnitEnum>(extendedUnits))
        //            {
        //                validationErrors.Add(new MtconnectValidationException(
        //                    ValidationSeverity.WARNING,
        //                    $"Observation 'units' of '{extendedUnits}' is an unnecessary extension of the MTConnect Standard as it already exists in version '{MtconnectVersion}'.",
        //                    SourceNode));
        //            }
        //            else if (EnumHelper.CompareToVersion<UnitEnum>(extendedUnits, MtconnectVersion.GetValueOrDefault()) != VersionComparisonTypes.Implemented)
        //            {
        //                validationErrors.Add(new MtconnectValidationException(
        //                    ValidationSeverity.WARNING,
        //                    $"Observation 'units' of '{extendedUnits}' is not valid in version '{MtconnectVersion}' of the MTConnect Standard.",
        //                    SourceNode));
        //            }
        //            else
        //            {
        //                validationErrors.Add(new MtconnectValidationException(
        //                    ValidationSeverity.MESSAGE,
        //                    $"Observation 'units' of '{extendedUnits}' is an extension of the MTConnect Standard in this implementation.",
        //                    SourceNode));
        //            }
        //        }
        //        else if (!EnumHelper.Contains<UnitEnum>(Units))
        //        {
        //            validationErrors.Add(new MtconnectValidationException(
        //                ValidationSeverity.WARNING,
        //                $"Observation 'units' of '{Units}' is not defined in the MTConnect Standard in version '{MtconnectVersion}'.",
        //                SourceNode));
        //        }
        //        else if (EnumHelper.CompareToVersion<UnitEnum>(Units, MtconnectVersion.GetValueOrDefault()) != VersionComparisonTypes.Implemented)
        //        {
        //            validationErrors.Add(new MtconnectValidationException(
        //                ValidationSeverity.WARNING,
        //                $"Observation 'units' of '{Units}' is not supported in version '{MtconnectVersion}' of the MTConnect Standard.",
        //                SourceNode));
        //        }
        //    }
        //    else if (Category == CategoryEnum.SAMPLE)
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Sample MUST include a 'units' attribute.",
        //                SourceNode));
        //    }
        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL)]
        //protected bool validateSequence(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    const long sequenceCeiling = (2 ^ 64) - 1;
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (Sequence < 1 && Sequence > sequenceCeiling)
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Observation MUST include a 'sequence' attribute between 1 and {sequenceCeiling}.",
        //            SourceNode));
        //    }
        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}

        //protected abstract bool validateValue(out ICollection<MtconnectValidationException> validationErrors);

        //protected virtual bool validateNode(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();

        //    ICollection<MtconnectValidationException> extensionErrors = new List<MtconnectValidationException>();
        //    switch (Category)
        //    {
        //        case CategoryEnum.SAMPLE:
        //            validateNodeExtension<SampleTypes>(out extensionErrors);
        //            break;
        //        case CategoryEnum.EVENT:
        //            validateNodeExtension<EventTypes>(out extensionErrors);
        //            break;
        //        case CategoryEnum.CONDITION:
        //            var conditionIsValid = validateNodeExtension<ConditionTypes>(out var conditionErrors);
        //            var eventIsValid = validateNodeExtension<EventTypes>(out var eventErrors);
        //            var sampleIsValid = validateNodeExtension<SampleTypes>(out var sampleErrors);
        //            if (!(conditionIsValid || eventIsValid || sampleIsValid))
        //            {
        //                extensionErrors.Add(new MtconnectValidationException(
        //                    ValidationSeverity.ERROR,
        //                    $"Observation '{DataItemId}' type of '{Type}' is not defined in the MTConnect Standard for category '{Category}' in version '{MtconnectVersion}'.",
        //                    SourceNode));
        //            }
        //            else if (conditionIsValid && conditionErrors.Any())
        //            {
        //                foreach (var error in conditionErrors)
        //                    extensionErrors.Add(error);
        //            }
        //            else if (eventIsValid && eventErrors.Any())
        //            {
        //                foreach (var error in eventErrors)
        //                    extensionErrors.Add(error);
        //            }
        //            else if (sampleIsValid && sampleErrors.Any())
        //            {
        //                foreach (var error in sampleErrors)
        //                    extensionErrors.Add(error);
        //            }
        //            break;
        //        default:
        //            break;
        //    }

        //    if (extensionErrors.Any())
        //    {
        //        validationErrors = extensionErrors;
        //        return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //    }

        //    ICollection<MtconnectValidationException> standardErrors = new List<MtconnectValidationException>();
        //    switch (Category)
        //    {
        //        case CategoryEnum.SAMPLE:
        //            validateNodeInStandard<SampleTypes>(out standardErrors);
        //            break;
        //        case CategoryEnum.EVENT:
        //            validateNodeInStandard<EventTypes>(out standardErrors);
        //            break;
        //        case CategoryEnum.CONDITION:
        //            var conditionIsValid = validateNodeInStandard<ConditionTypes>(out var conditionErrors);
        //            var eventIsValid = validateNodeInStandard<EventTypes>(out var eventErrors);
        //            var sampleIsValid = validateNodeInStandard<SampleTypes>(out var sampleErrors);
        //            if (!(conditionIsValid || eventIsValid || sampleIsValid))
        //            {
        //                standardErrors.Add(new MtconnectValidationException(
        //                    ValidationSeverity.ERROR,
        //                    $"Observation '{DataItemId}' type of '{Type}' is not defined in the MTConnect Standard for category '{Category}' in version '{MtconnectVersion}'.",
        //                    SourceNode));
        //            }
        //            else if (conditionIsValid && conditionErrors.Any())
        //            {
        //                foreach (var error in conditionErrors)
        //                    standardErrors.Add(error);
        //            }
        //            else if (eventIsValid && eventErrors.Any())
        //            {
        //                foreach (var error in eventErrors)
        //                    standardErrors.Add(error);
        //            }
        //            else if (sampleIsValid && sampleErrors.Any())
        //            {
        //                foreach (var error in sampleErrors)
        //                    standardErrors.Add(error);
        //            }
        //            break;
        //        default:
        //            break;
        //    }

        //    if (standardErrors.Any())
        //    {
        //        validationErrors = standardErrors;
        //    }

        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}

        //protected bool validateNodeExtension<T>(out ICollection<MtconnectValidationException> validationErrors) where T: Enum
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (!string.IsNullOrEmpty(this.SourceNode.Name))
        //    {
        //        if (SourceNode.Name.StartsWith("x:"))
        //        {
        //            if (validateNodeInStandard<T>(out ICollection<MtconnectValidationException> inStandardErrors))
        //            {
        //                validationErrors.Add(new MtconnectValidationException(
        //                    ValidationSeverity.WARNING,
        //                    $"Observation '{DataItemId}' type of '{SourceNode.Name}' is an unnecessary extension of the MTConnect Standard for category '{Category}' as it already exists in version '{MtconnectVersion}'.",
        //                    SourceNode));
        //            } else
        //            {
        //                validationErrors.Add(new MtconnectValidationException(
        //                    ValidationSeverity.MESSAGE,
        //                    $"Observation '{DataItemId}' type of '{SourceNode.Name}' is an extension of the MTConnect Standard in for category '{Category}' this implementation.",
        //                    SourceNode));
        //            }
        //        }
        //    }
        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}

        //protected bool validateNodeInStandard<T>(out ICollection<MtconnectValidationException> validationErrors) where T : Enum
        //{
        //    bool isValidType = true, isValidSubType = true;
        //    validationErrors = new List<MtconnectValidationException>();

        //    // Validate the observational type
        //    if (!EnumHelper.Contains<T>(Type))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Observation '{DataItemId}' type of '{Type}' is not defined in the MTConnect Standard for category '{Category}' in version '{MtconnectVersion}'.",
        //            SourceNode));
        //        isValidType = false;
        //    }
        //    else if (EnumHelper.CompareToVersion<T>(Type, MtconnectVersion.GetValueOrDefault()) != VersionComparisonTypes.Implemented)
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.WARNING,
        //            $"Observation '{DataItemId}' type of '{Type}' is not valid for category '{Category}' in version '{MtconnectVersion}' of the MTConnect Standard.",
        //            SourceNode));
        //        isValidType = false;
        //    }

        //    if (isValidType)
        //    {
        //        // Get the Enum and look for an attribute pointing to the SubType enum
        //        Type enumType = typeof(T);
        //        MemberInfo[] typeValueInfos = enumType.GetMember(EnumHelper.Enumify(Type));
        //        var valueInfo = typeValueInfos.FirstOrDefault(o => o.DeclaringType == enumType);
        //        var obsSubType = valueInfo?.GetCustomAttribute<ObservationalSubTypeAttribute>();
        //        // Validate the observational sub-type
        //        if (obsSubType != null && Category != CategoryEnum.CONDITION)
        //        {
        //            if (string.IsNullOrEmpty(SubType))
        //            {
        //                validationErrors.Add(new MtconnectValidationException(
        //                    ValidationSeverity.ERROR,
        //                    $"Observation '{DataItemId}' type '{SourceNode.LocalName}' is missing a subType",
        //                    SourceNode));
        //                isValidSubType = false;
        //            } else if (!EnumHelper.Contains(obsSubType.SubTypeEnum, SubType))
        //            {
        //                validationErrors.Add(new MtconnectValidationException(
        //                ValidationSeverity.ERROR,
        //                    $"Observation '{DataItemId}' subType of '{SubType}' is not defined in the MTConnect Standard for category '{Category}' and type '{SourceNode.LocalName}' in version '{MtconnectVersion}'.",
        //                    SourceNode));
        //                isValidSubType = false;
        //            }
        //            else if (EnumHelper.CompareToVersion(obsSubType.SubTypeEnum, SubType, MtconnectVersion.GetValueOrDefault()) != VersionComparisonTypes.Implemented)
        //            {
        //                validationErrors.Add(new MtconnectValidationException(
        //                ValidationSeverity.WARNING,
        //                    $"Observation '{DataItemId}' subType of '{SubType}' is not valid for category '{Category}' and type '{SourceNode.LocalName}' in version '{MtconnectVersion}' of the MTConnect Standard.",
        //                    SourceNode));
        //                isValidSubType = false;
        //            }
        //        }
        //    }

        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}
    }
}
