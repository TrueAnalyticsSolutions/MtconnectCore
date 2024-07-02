using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Enums.Streams;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;
using CoordinateSystemEnum = MtconnectCore.Standard.Contracts.Enums.Devices.CoordinateSystemEnum;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <summary>
    /// information reported about a piece of equipment. <see href="https://model.mtconnect.org/#Structure__EAID_002C94B7_1257_49be_8EAA_CE7FCD7AFF8A">MTConnect Model Browser</see>
    /// </summary>
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
        public string Discrete { get; set; }

        /// <inheritdoc cref="DataItemAttributes.SAMPLE_RATE"/>
        [MtconnectNodeAttribute(DataItemAttributes.SAMPLE_RATE)]
        public string SampleRate { get; set; }

        /// <inheritdoc cref="DataItemElements.SOURCE"/>
        [MtconnectNodeElements(DataItemElements.SOURCE, nameof(TrySetSource), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public Source Source { get; set; }

        // TODO: Fix the multiplicity. The Constraints element can only have one instance, the sub-elements are the properties.
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

        // Validate all attributes for the data item
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DATA_ITEM)]
        private bool validateValueProperties(out ICollection<MtconnectValidationException> validationErrors)
            => (new NodeValidationContext(this))
            // category
            .ValidateValueProperty<DataItemAttributes>(nameof(DataItemAttributes.CATEGORY), (o) =>
                o.IsImplemented(Category)
                ?.IsEnumValueType<CategoryTypes>(Category)
            )
            // compositionId
            .ValidateValueProperty<DataItemAttributes>(nameof(DataItemAttributes.COMPOSITION_ID), (o) =>
                o.IsImplemented(CompositionId)
                ?.IsIdValueType(CompositionId, false)
            )
            // coordinateSystem
            .ValidateValueProperty<DataItemAttributes>(nameof(DataItemAttributes.COORDINATE_SYSTEM), (o) =>
                o.IsImplemented(CoordinateSystem)
                    // scope to v1.8.1 deprecation
                ?.IsEnumValueType<CoordinateSystemEnum>(CoordinateSystem)
            )
            // discrete
            .ValidateValueProperty<DataItemAttributes>(nameof(DataItemAttributes.DISCRETE), (o) =>
                o.IsImplemented(Discrete)
                ?.IsBooleanValueType(Discrete)
            )
            // id
            .ValidateValueProperty<DataItemAttributes>(nameof(DataItemAttributes.ID), (o) =>
                o.IsImplemented(Id)
                ?.IsIdValueType(Id)
            )
            // name
            .ValidateValueProperty<DataItemAttributes>(nameof(DataItemAttributes.NAME), (o) =>
                o.IsImplemented(Name)
            )
            // nativeScale
            .ValidateValueProperty<DataItemAttributes>(nameof(DataItemAttributes.NATIVE_SCALE), (o) =>
                o.IsImplemented(NativeScale)?.IsUIntValueType(NativeScale)
            )
            // nativeUnits
            .ValidateValueProperty<DataItemAttributes>(nameof(DataItemAttributes.NATIVE_UNITS), (o) =>
                o.IsImplemented(NativeUnits)
                ?.ValidateNativeUnits(NativeUnits)
            )
            // sampleRate
            .ValidateValueProperty<DataItemAttributes>(nameof(DataItemAttributes.SAMPLE_RATE), (o) =>
                o.IsImplemented(SampleRate)
                ?.IsFloatValueType(SampleRate)
            )
            // significantDigits
            .ValidateValueProperty<DataItemAttributes>(nameof(DataItemAttributes.SIGNIFICANT_DIGITS), (o) =>
                o.IsImplemented(SignificantDigits)
                ?.IsUIntValueType(SignificantDigits)
            )
            // statistic
            .ValidateValueProperty<DataItemAttributes>(nameof(DataItemAttributes.STATISTIC), (o) =>
                o.IsImplemented(Statistic)
                ?.IsEnumValueType<StatisticTypes>(Statistic)
            )
            // type/subType
            .ValidateValueProperty<DataItemAttributes>(nameof(DataItemAttributes.TYPE), (o) =>
                o.IsImplemented(Type)
                ?.IsImplemented(SubType)
                ?.IsRequired(Type)
                ?.ValidateType(Category, Type, SubType)
            )
            // units
            .ValidateValueProperty<DataItemAttributes>(nameof(DataItemAttributes.UNITS), (o) =>
                o.IsImplemented(Units)
                ?.If(
                    (v) => Category.Equals("SAMPLE", StringComparison.OrdinalIgnoreCase),
                    (v) => o?.IsRequired(Units)
                )
                ?.IsEnumValueType<UnitsTypes>(nameof(Units), Units)
            )
            // representation
            .ValidateValueProperty<DataItemAttributes>(nameof(DataItemAttributes.REPRESENTATION), (o) =>
                o.IsImplemented(Representation)
                ?.IsEnumValueType<RepresentationTypes>(Representation)
            )
            // coordinateSystemIdRef
            .ValidateValueProperty<DataItemAttributes>(nameof(DataItemAttributes.COORDINATE_SYSTEM_ID_REF), (o) =>
                o.IsImplemented(CoordinateSystemIdRef)
                ?.IsIdValueType(CoordinateSystemIdRef, false)
            )
            .HasError(out validationErrors);

        // Validate all elements for the data item
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DATA_ITEM)]
        private bool validateParts(out ICollection<MtconnectValidationException> validationErrors)
            => new NodeValidationContext(this)
            // Source
            .ValidateValueProperty<DataItemElements>(nameof(DataItemElements.SOURCE), o =>
                o
            )
            // Constraints
            .ValidateValueProperty<DataItemElements>(nameof(DataItemElements.CONSTRAINTS), o =>
                o
            )
            // Filter
            .ValidateValueProperty<DataItemElements>(nameof(DataItemElements.FILTERS), o =>
                o.HasMultiplicity(nameof(DataItemElements.FILTERS), Filters, 0, int.MaxValue)
            )
            // InitialValue
            .ValidateValueProperty<DataItemElements>(nameof(DataItemElements.INITIAL_VALUE), o =>
                o
                // InitialValue validated when set
            )
            // ResetTrigger
            .ValidateValueProperty<DataItemElements>(nameof(DataItemElements.RESET_TRIGGER), o =>
                o.IsEnumValueType<ResetTriggeredValues>(nameof(ResetTrigger), ResetTrigger)
            )
            // Definition
            .ValidateValueProperty<DataItemElements>(nameof(DataItemElements.DEFINITION), o =>
                o
                // Definition validated when set
            )
            // TODO: Relationships
            .HasError(out validationErrors);
    }
}
