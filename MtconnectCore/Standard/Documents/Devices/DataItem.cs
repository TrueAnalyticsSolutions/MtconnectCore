﻿using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

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
        public string Representation { get; set; }

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
        public bool? Discrete { get; set; }

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

        /// <remarks>See Part 2 Section 6.2.1 of MTConnect Standard</remarks>
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            base.TryValidate(out validationErrors);

            const string documentationAttributes = "See Part 2 Section 7.2.2 of the MTConnect standard.";

            if (string.IsNullOrEmpty(Id))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"DataItem MUST include a unique 'id' attribute. {documentationAttributes}"));
            }

            if (string.IsNullOrEmpty(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"DataItem MUST include a 'type' attribute. {documentationAttributes}"));
            }

            if (string.IsNullOrEmpty(Category))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"DataItem MUST include a 'category' attribute. {documentationAttributes}"));
            } else if (!EnumHelper.Contains<CategoryTypes>(Category)) {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"DataItem 'category' attribute must be one of the following: [{EnumHelper.ToListString<CategoryTypes>(", ", string.Empty, string.Empty)}]. {documentationAttributes}"));
            }

            // Validate Category, Type and SubType
            if (!string.IsNullOrEmpty(Type) && !string.IsNullOrEmpty(Category)) {
                if (Enum.TryParse<CategoryTypes>(Category, out CategoryTypes category)) {
                    switch (category)
                    {
                        case CategoryTypes.SAMPLE:
                            if (!EnumHelper.Contains<SampleTypes>(Type))
                            {
                                validationErrors.Add(new MtconnectValidationException(
                                    ValidationSeverity.WARNING,
                                    $"DataItem type of '{Type}' is not defined in the MTConnect Standard for category '{Category}' in version '{MtconnectVersion}'. {documentationAttributes}"));
                            }
                            break;
                        case CategoryTypes.EVENT:
                            if (!EnumHelper.Contains<EventTypes>(Type))
                            {
                                validationErrors.Add(new MtconnectValidationException(
                                    ValidationSeverity.WARNING,
                                    $"DataItem type of '{Type}' is not defined in the MTConnect Standard for category '{Category}' in version '{MtconnectVersion}'. {documentationAttributes}"));
                            }
                            break;
                        case CategoryTypes.CONDITION:
                            if (!EnumHelper.Contains<ConditionTypes>(Type))
                            {
                                validationErrors.Add(new MtconnectValidationException(
                                    ValidationSeverity.WARNING,
                                    $"DataItem type of '{Type}' is not defined in the MTConnect Standard for category '{Category}' in version '{MtconnectVersion}'. {documentationAttributes}"));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            // Validate units
            if (!string.IsNullOrEmpty(Units) && !EnumHelper.Contains<UnitsTypes>(Units))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.WARNING,
                    $"DataItem units of '{Units}' is not defined in the MTConnect Standard in version '{MtconnectVersion}'. {documentationAttributes}"));
            }

            // Validate nativeUnits
            if (!string.IsNullOrEmpty(NativeUnits) && !EnumHelper.Contains<NativeUnitsTypes>(NativeUnits))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.WARNING,
                    $"DataItem nativeUnits of '{NativeUnits}' is not defined in the MTConnect Standard in version '{MtconnectVersion}'. {documentationAttributes}"));
            }

            if (Category.ToUpper() == "SAMPLE" && string.IsNullOrEmpty(Units))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"DataItem MUST include a 'units' attribute when 'category' equals 'SAMPLE'. {documentationAttributes}"));
            }

            if (!string.IsNullOrEmpty(CoordinateSystem) && !EnumHelper.Contains<Contracts.Enums.Devices.CoordinateSystemTypes>(CoordinateSystem))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"DataItem 'coordinateSystem' attribute must be one of the following: [{EnumHelper.ToListString<Contracts.Enums.Devices.CoordinateSystemTypes>(", ", string.Empty, string.Empty)}]. {documentationAttributes}"));
            }

            return !validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR);
        }
    }
}
