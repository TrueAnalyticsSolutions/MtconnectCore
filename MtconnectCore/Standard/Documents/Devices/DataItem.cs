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
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;
using CoordinateSystemTypes = MtconnectCore.Standard.Contracts.Enums.Devices.CoordinateSystemTypes;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <inheritdoc />
    public class DataItem : MtconnectNode
    {
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

        [MtconnectNodeElement(DataItemElements.INITIAL_VALUE)]
        public string InitialValue { get; set; }

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

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.1")]
        private bool validateId(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Id))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"DataItem MUST include a unique 'id' attribute.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.1")]
        private bool validateCategory(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Category))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"DataItem MUST include a 'category' attribute.",
                    SourceNode));
            }
            else if (!EnumHelper.Contains<CategoryTypes>(Category))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"DataItem 'category' attribute must be one of the following: [{EnumHelper.ToListString<CategoryTypes>(", ", string.Empty, string.Empty)}].",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.1")]
        private bool validateType(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"DataItem MUST include a 'type' attribute.",
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
                if (Type.StartsWith("x:"))
                {
                    if (validateNodeInStandard<T>(categoryType, Type.Replace("x:", string.Empty), out ICollection<MtconnectValidationException> inStandardErrors))
                    {
                        validationErrors.Add(new MtconnectValidationException(
                            ValidationSeverity.WARNING,
                            $"{Category} type of '{Type}' is an unnecessary extension of the MTConnect Standard as it already exists in version '{MtconnectVersion}'.",
                            SourceNode));
                    }
                    else
                    {
                        validationErrors.Add(new MtconnectValidationException(
                            ValidationSeverity.MESSAGE,
                            $"{Category} type of '{Type}' is an extension of the MTConnect Standard in this implementation.",
                            SourceNode));
                    }
                }
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        private bool validateNodeInStandard<T>(CategoryTypes categoryType, string type, out ICollection<MtconnectValidationException> validationErrors) where T : Enum
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!EnumHelper.Contains<T>(type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"DataItem type of '{type}' is not defined in the MTConnect Standard for category '{Category}' in version '{MtconnectVersion}'.",
                    SourceNode));
            }
            else if (!EnumHelper.ValidateToVersion<T>(type, MtconnectVersion.GetValueOrDefault()))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.WARNING,
                    $"DataItem type of '{type}' is not valid for category '{Category}' in version '{MtconnectVersion}' of the MTConnect Standard.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.1")]
        private bool validateUnits(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(Units))
            {
                if (!EnumHelper.Contains<UnitsTypes>(Units))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"DataItem units of '{Units}' is not defined in the MTConnect Standard in version '{MtconnectVersion}'.",
                        SourceNode));
                }
                else if (!EnumHelper.ValidateToVersion<UnitsTypes>(Units, MtconnectVersion.GetValueOrDefault()))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"DataItem units of '{Units}' is not supported in version '{MtconnectVersion}' of the MTConnect Standard.",
                        SourceNode));
                }
            } else if (Category.ToUpper() == "SAMPLE") {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"DataItem MUST include a 'units' attribute when 'category' equals 'SAMPLE'.",
                        SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.1")]
        private bool validateNativeUnits(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(NativeUnits))
            {
                if (!EnumHelper.Contains<NativeUnitsTypes>(NativeUnits) && !EnumHelper.Contains<UnitsTypes>(NativeUnits))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"DataItem nativeUnits of '{NativeUnits}' is not defined in the MTConnect Standard in version '{MtconnectVersion}'.",
                        SourceNode));
                }
                else if (!EnumHelper.ValidateToVersion<NativeUnitsTypes>(NativeUnits, MtconnectVersion.GetValueOrDefault()) && !EnumHelper.ValidateToVersion<UnitsTypes>(NativeUnits, MtconnectVersion.GetValueOrDefault()))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"DataItem nativeUnits of '{NativeUnits}' is not supported in version '{MtconnectVersion}' of the MTConnect Standard.",
                        SourceNode));
                }
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.1", MtconnectVersions.V_1_1_0)]
        private bool validateRepresentation_NotImplemented(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(Representation)) {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.WARNING, "DataItem does not yet support 'representation' until version 1.2.0 of the MTConnect Standard.", SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.2")]
        private bool validateRepresentation(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(Representation))
            {
                if (!EnumHelper.Contains<RepresentationTypes>(Representation))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"DataItem representation of '{Representation}' is not defined in the MTConnect Standard in version '{MtconnectVersion}'.",
                        SourceNode));
                }
                else if (!EnumHelper.ValidateToVersion<RepresentationTypes>(Representation, MtconnectVersion.GetValueOrDefault()))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"DataItem representation of '{Representation}' is not supported in version '{MtconnectVersion}' of the MTConnect Standard.",
                        SourceNode));
                }

            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.1")]
        private bool validateCoordinateSystem(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(CoordinateSystem))
            {
                if (!EnumHelper.Contains<CoordinateSystemTypes>(CoordinateSystem))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        Contracts.Enums.ValidationSeverity.WARNING,
                        $"DataItem 'coordinateSystem' attribute must be one of the following: [{EnumHelper.ToListString<Contracts.Enums.Devices.CoordinateSystemTypes>(", ", string.Empty, string.Empty)}].", SourceNode));
                }
                else if (!EnumHelper.ValidateToVersion<CoordinateSystemTypes>(CoordinateSystem, MtconnectVersion.GetValueOrDefault()))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"DataItem coordinateSystem of '{CoordinateSystem}' is not supported in version '{MtconnectVersion}' of the MTConnect Standard.",
                        SourceNode));
                }
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.2")]
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
                        $"DataItem statistic of '{Statistic}' is not supported in version '{MtconnectVersion}' of the MTConnect Standard.",
                        SourceNode));
                }
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 7.2.3.5")]
        private bool validateResetTrigger(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(ResetTrigger) && !EnumHelper.Contains<ResetTriggerValues>(ResetTrigger)) {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.WARNING, $"Unrecognized ResetTrigger value '{ResetTrigger}'.", SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
        
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 7.2.2")]
        private bool validateRepresentationDiscrete_Deprecated(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(Representation) && EnumHelper.Enumify(Representation).Equals(RepresentationTypes.DISCRETE)) {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.WARNING, $"DataItem representation 'discrete' is obsolete, the 'discrete' attribute should be used instead.", SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
