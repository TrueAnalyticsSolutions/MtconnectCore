using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Enums.Streams;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;
using CoordinateSystemTypes = MtconnectCore.Standard.Contracts.Enums.Devices.CoordinateSystemTypes;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <summary>
    /// information reported about a piece of equipment. <see href="https://model.mtconnect.org/#Structure__EAID_002C94B7_1257_49be_8EAA_CE7FCD7AFF8A">MTConnect Model Browser</see>
    /// </summary>
    public class DataItem : MtconnectNode
    {
        private const string MODEL_BROWSER_URL = "https://model.mtconnect.org/#Structure__EAID_002C94B7_1257_49be_8EAA_CE7FCD7AFF8A";

        /// <inheritdoc cref="DataItemAttributes.ID"/>
        [MtconnectNodeAttribute(DataItemAttributes.ID)]
        public string Id { get; set; }

        /// <inheritdoc cref="DataItemAttributes.NAME"/>
        [MtconnectNodeAttribute(DataItemAttributes.NAME)]
        public string Name { get; set; }

        /// <inheritdoc cref="DataItemAttributes.TYPE"/>
        [MtconnectNodeAttribute(DataItemAttributes.TYPE)]
        public string Type { get; set; }

        /// <inheritdoc cref="DataItemAttributes.CATEGORY"/>
        [MtconnectNodeAttribute(DataItemAttributes.CATEGORY)]
        public string Category { get; set; }

        /// <inheritdoc cref="DataItemAttributes.UNITS"/>
        [MtconnectNodeAttribute(DataItemAttributes.UNITS)]
        public string Units { get; set; }

        /// <inheritdoc cref="DataItemAttributes.SUB_TYPE"/>
        [MtconnectNodeAttribute(DataItemAttributes.SUB_TYPE)]
        public string SubType { get; set; }

        /// <inheritdoc cref="DataItemAttributes.NATIVE_UNITS"/>
        [MtconnectNodeAttribute(DataItemAttributes.NATIVE_UNITS)]
        public string NativeUnits { get; set; }

        /// <inheritdoc cref="DataItemAttributes.NATIVE_SCALE"/>
        [MtconnectNodeAttribute(DataItemAttributes.NATIVE_SCALE)]
        public string NativeScale { get; set; }

        /// <inheritdoc cref="DataItemAttributes.STATISTIC"/>
        [MtconnectNodeAttribute(DataItemAttributes.STATISTIC)]
        public string Statistic { get; set; }

        /// <inheritdoc cref="DataItemAttributes.REPRESENTATION"/>
        [MtconnectNodeAttribute(DataItemAttributes.REPRESENTATION)]
        public string Representation { get; set; } = RepresentationTypes.VALUE.ToCamelCase();

        /// <inheritdoc cref="DataItemAttributes.SIGNIFICANT_DIGITS"/>
        [MtconnectNodeAttribute(DataItemAttributes.SIGNIFICANT_DIGITS)]
        public string SignificantDigits { get; set; }

        /// <inheritdoc cref="DataItemAttributes.COORDINATE_SYSTEM"/>
        [MtconnectNodeAttribute(DataItemAttributes.COORDINATE_SYSTEM)]
        public string CoordinateSystem { get; set; }

        /// <inheritdoc cref="DataItemAttributes.COORDINATE_SYSTEM_ID_REF"/>
        [MtconnectNodeAttribute(DataItemAttributes.COORDINATE_SYSTEM_ID_REF)]
        public string CoordinateSystemIdRef { get; set; }

        /// <inheritdoc cref="DataItemAttributes.COMPOSITION_ID"/>
        [MtconnectNodeAttribute(DataItemAttributes.COMPOSITION_ID)]
        public string CompositionId { get; set; }

        /// <inheritdoc cref="DataItemAttributes.DISCRETE"/>
        [MtconnectNodeAttribute(DataItemAttributes.DISCRETE)]
        public bool? Discrete { get; set; } = false;

        /// <inheritdoc cref="DataItemAttributes.SAMPLE_RATE"/>
        [MtconnectNodeAttribute(DataItemAttributes.SAMPLE_RATE)]
        public string SampleRate { get; set; }

        /// <inheritdoc cref="DataItemElements.SOURCE"/>
        [MtconnectNodeElements(DataItemElements.SOURCE, nameof(TrySetSource), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public Source Source { get; set; }

        private List<DataItemConstraint> _constraints = new List<DataItemConstraint>();
        /// <inheritdoc cref="DataItemElements.CONSTRAINTS"/>
        [MtconnectNodeElements("Constraints/*", nameof(TryAddConstraint), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ICollection<DataItemConstraint> Constraints => _constraints;

        private List<Filter> _filters = new List<Filter>();
        /// <inheritdoc cref="DataItemElements.FILTERS"/>
        [MtconnectNodeElements("Filters/*", nameof(TryAddFilter), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ICollection<Filter> Filters => _filters;

        /// <inheritdoc cref="DataItemElements.INITIAL_VALUE"/>
        [MtconnectNodeElement(DataItemElements.INITIAL_VALUE)]
        public string InitialValue { get; set; }

        /// <inheritdoc cref="DataItemElements.RESET_TRIGGER"/>
        [MtconnectNodeElement(DataItemElements.RESET_TRIGGER)]
        public string ResetTrigger { get; set; }

        [MtconnectNodeElements("Definition", nameof(TrySetDefinition), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public DataItemDefinition Definition { get; set; }

        /// <inheritdoc/>
        public DataItem() : base() { }

        /// <inheritdoc/>
        public DataItem(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE, version) { }

        public bool TrySetSource(XmlNode xNode, XmlNamespaceManager nsmgr, out Source source)
            => base.TrySet<Source>(xNode, nsmgr, nameof(Source), out source);

        public bool TryAddConstraint(XmlNode xNode, XmlNamespaceManager nsmgr, out DataItemConstraint constraint)
            => base.TryAdd<DataItemConstraint>(xNode, nsmgr, ref _constraints, out constraint);

        public bool TryAddFilter(XmlNode xNode, XmlNamespaceManager nsmgr, out Filter filter)
            => base.TryAdd<Filter>(xNode, nsmgr, ref _filters, out filter);

        public bool TrySetDefinition(XmlNode xNode, XmlNamespaceManager nsmgr, out DataItemDefinition dataItemDefinition)
            => base.TrySet<DataItemDefinition>(xNode, nsmgr, nameof(Definition), out dataItemDefinition);

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL)]
        private bool validateId(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Id))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Missing 'id' value.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL)]
        private bool validateCategory(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Category))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Missing 'category' value.",
                    SourceNode));
            }
            else if (!EnumHelper.Contains<CategoryTypes>(Category))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Invalid 'category' value.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL)]
        private bool validateType(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Missing 'type' value.",
                    SourceNode));
            } else if (!string.IsNullOrEmpty(Category))
            {
                if (Enum.TryParse<CategoryTypes>(Category, out CategoryTypes category))
                {
                    switch (category)
                    {
                        case CategoryTypes.SAMPLE:
                            return validateNode<SampleTypes>(category, out validationErrors);
                        case CategoryTypes.EVENT:
                            return validateNode<EventTypes>(category, out validationErrors);
                        case CategoryTypes.CONDITION:
                            return validateNode<ConditionTypes>(category, out validationErrors);
                        default:
                            break;
                    }
                }
            }

            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        private bool validateNode<T>(CategoryTypes categoryType, out ICollection<MtconnectValidationException> validationErrors) where T : Enum
        {
            validationErrors = new List<MtconnectValidationException>();

            ICollection<MtconnectValidationException> extensionErrors;
            validateNodeExtension<T>(categoryType, out extensionErrors);

            if (extensionErrors.Any())
            {
                validationErrors = extensionErrors;
                return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
            }

            ICollection<MtconnectValidationException> standardErrors;
            validateNodeInStandard<T>(categoryType, Type, out standardErrors);

            if (standardErrors.Any())
            {
                validationErrors = standardErrors;
            }

            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        private bool validateNodeExtension<T>(CategoryTypes categoryType, out ICollection<MtconnectValidationException> validationErrors) where T : Enum
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(Type))
            {
                if (Type.Contains(":"))
                {
                    if (validateNodeInStandard<T>(categoryType, Type.Substring(Type.LastIndexOf(":") + 1), out ICollection<MtconnectValidationException> inStandardErrors))
                    {
                        validationErrors.Add(new MtconnectValidationException(
                            ValidationSeverity.WARNING,
                            $"Extended type of '{Type}' already exist in version '{MtconnectVersion}'.",
                            SourceNode));
                    }
                    else
                    {
                        validationErrors.Add(new MtconnectValidationException(
                            ValidationSeverity.MESSAGE,
                            $"Extended type of '{Type}' are used in this implementation.",
                            SourceNode));
                    }
                }
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        private bool validateNodeInStandard<T>(CategoryTypes categoryType, string type, out ICollection<MtconnectValidationException> validationErrors) where T : Enum
        {
            bool isValidType = true, isValidSubType = true;
            validationErrors = new List<MtconnectValidationException>();

            // Validate the observational type
            if (!EnumHelper.Contains<T>(type))
            {
                if (categoryType != CategoryTypes.CONDITION
                    || (!EnumHelper.Contains<MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.EventTypes>(type)
                    && !EnumHelper.Contains<MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.SampleTypes>(type)))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.ERROR,
                        $"Invalid 'type' value.",
                        SourceNode));
                    isValidType = false;
                }
            }
            else if (!EnumHelper.ValidateToVersion<T>(type, MtconnectVersion.GetValueOrDefault()))
            {
                if (categoryType != CategoryTypes.CONDITION
                    || (!EnumHelper.ValidateToVersion<MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.EventTypes>(type, MtconnectVersion.GetValueOrDefault())
                        && !EnumHelper.ValidateToVersion<MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.SampleTypes>(type, MtconnectVersion.GetValueOrDefault())))
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.WARNING,
                    $"Invalid 'type' value in version '{MtconnectVersion}'.",
                    SourceNode));
                isValidType = false;
            }

            if (isValidType && !string.IsNullOrEmpty(SubType))
            {
                // Get the Enum and look for an attribute pointing to the SubType enum
                Type enumType = typeof(T);
                MemberInfo[] typeValueInfos = enumType.GetMember(type);
                var valueInfo = typeValueInfos.FirstOrDefault(o => o.DeclaringType == enumType);
                var obsSubType = valueInfo?.GetCustomAttribute<ObservationalSubTypeAttribute>();
                // Validate the observational sub-type
                if (obsSubType != null)
                {
                    if (!EnumHelper.Contains(obsSubType.SubTypeEnum, SubType))
                    {
                        validationErrors.Add(new MtconnectValidationException(
                            ValidationSeverity.ERROR,
                            $"Invalid 'subType' value.",
                            SourceNode));
                        isValidSubType = false;
                    }
                    else if (!EnumHelper.ValidateToVersion(obsSubType.SubTypeEnum, SubType, MtconnectVersion.GetValueOrDefault()))
                    {
                        validationErrors.Add(new MtconnectValidationException(
                            ValidationSeverity.WARNING,
                            $"Invalid 'subType' value in version '{MtconnectVersion}'.",
                            SourceNode));
                        isValidSubType = false;
                    }
                }
            }

            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL)]
        private bool validateUnits(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(Units))
            {
                if (Units.Contains(":"))
                {
                    string extendedUnits = Units.Substring(Units.LastIndexOf(":") + 1);
                    if (!EnumHelper.Contains<UnitsTypes>(extendedUnits))
                    {
                        validationErrors.Add(new MtconnectValidationException(
                            ValidationSeverity.WARNING,
                            $"Extended units '{extendedUnits}' already exist in version '{MtconnectVersion}'.",
                            SourceNode));
                    }
                    else if (!EnumHelper.ValidateToVersion<UnitsTypes>(extendedUnits, MtconnectVersion.GetValueOrDefault()))
                    {
                        validationErrors.Add(new MtconnectValidationException(
                            ValidationSeverity.WARNING,
                            $"Invalid 'units' value in version '{MtconnectVersion}'.",
                            SourceNode));
                    } else
                    {
                        validationErrors.Add(new MtconnectValidationException(
                            ValidationSeverity.MESSAGE,
                            $"Extended units '{extendedUnits}' are used in this implementation.",
                            SourceNode));
                    }
                }
                else if (!EnumHelper.Contains<UnitsTypes>(Units))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"Invalid 'units' value.",
                        SourceNode));
                }
                else if (!EnumHelper.ValidateToVersion<UnitsTypes>(Units, MtconnectVersion.GetValueOrDefault()))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"Invalid 'units' value in version '{MtconnectVersion}'.",
                        SourceNode));
                }
            } else if (Category.ToUpper() == "SAMPLE") {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Missing 'units' value.",
                        SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL)]
        private bool validateNativeUnits(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(NativeUnits))
            {
                if (!EnumHelper.Contains<NativeUnitsTypes>(NativeUnits) && !EnumHelper.Contains<UnitsTypes>(NativeUnits))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"Invalid 'nativeUnits' value.",
                        SourceNode));
                }
                else if (!EnumHelper.ValidateToVersion<NativeUnitsTypes>(NativeUnits, MtconnectVersion.GetValueOrDefault()) && !EnumHelper.ValidateToVersion<UnitsTypes>(NativeUnits, MtconnectVersion.GetValueOrDefault()))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"Invalid 'nativeUnits' value in version '{MtconnectVersion}'.",
                        SourceNode));
                }
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL)]
        private bool validateNativeScale(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(NativeScale) && !int.TryParse(NativeScale, out int nativeScale))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Invalid 'nativeScale' value. It MUST be an integer.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL)]
        private bool validateSampleRate(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(SampleRate) && !float.TryParse(SampleRate, out float sampleRate))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Invalid 'sampleRate' value. It MUST be a float.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL)]
        private bool validateSignificantDigits(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(SignificantDigits) && !int.TryParse(SignificantDigits, out int significantDigits))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Invalid 'significantDigits' value. It MUST be an integer.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL, MtconnectVersions.V_1_1_0)]
        private bool validateRepresentation_NotImplemented(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(Representation)) {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.WARNING,
                    $"The 'representation' attribute is not supported until version '{MtconnectVersions.V_1_2_0}'.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, MODEL_BROWSER_URL)]
        private bool validateRepresentation(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(Representation))
            {
                if (!EnumHelper.Contains<RepresentationTypes>(Representation))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"Invalid 'representation' value.",
                        SourceNode));
                }
                else if (!EnumHelper.ValidateToVersion<RepresentationTypes>(Representation, MtconnectVersion.GetValueOrDefault()))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"Invalid 'representation' value in version '{MtconnectVersion}'.",
                        SourceNode));
                }
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL, MtconnectVersions.V_1_8_1)]
        private bool validateCoordinateSystem(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(CoordinateSystem))
            {
                if (!EnumHelper.Contains<CoordinateSystemTypes>(CoordinateSystem))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        Contracts.Enums.ValidationSeverity.WARNING,
                        $"Invalid 'coordinateSystem' value.", SourceNode));
                }
                else if (!EnumHelper.ValidateToVersion<CoordinateSystemTypes>(CoordinateSystem, MtconnectVersion.GetValueOrDefault()))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"Invalid 'coordinateSystem' value in version '{MtconnectVersion}'.",
                        SourceNode));
                }
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_2_0_0, MODEL_BROWSER_URL)]
        private bool validateCoordinateSystem_Deprecated(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(CoordinateSystem))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.WARNING,
                    $"The 'coordinateSystem' attribute was DEPRECATED in MTConnect Version '{MtconnectVersions.V_2_0_0}'.", SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, MODEL_BROWSER_URL)]
        private bool validateStatistic(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(Statistic))
            {
                if (!EnumHelper.Contains<StatisticTypes>(Statistic))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.ERROR,
                        $"DataItem 'statistic' attribute must be one of the following: [{EnumHelper.ToListString<StatisticTypes>(", ", string.Empty, string.Empty)}].",
                        SourceNode));
                }
                else if (!EnumHelper.ValidateToVersion<StatisticTypes>(Statistic, MtconnectVersion.GetValueOrDefault()))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"DataItem 'statistic' of '{Statistic}' is not supported in version '{MtconnectVersion}' of the MTConnect Standard.",
                        SourceNode));
                }
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, MODEL_BROWSER_URL)]
        private bool validateResetTrigger(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(ResetTrigger) && !EnumHelper.Contains<ResetTriggeredValues>(ResetTrigger)) {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.WARNING, $"Unrecognized ResetTrigger value '{ResetTrigger}'.", SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
        
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, MODEL_BROWSER_URL)]
        private bool validateRepresentationDiscrete_Deprecated(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(Representation) && EnumHelper.Enumify(Representation).Equals(RepresentationTypes.DISCRETE)) {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.WARNING, $"DataItem 'representation' of 'discrete' is obsolete, the 'discrete' attribute should be used instead.", SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
