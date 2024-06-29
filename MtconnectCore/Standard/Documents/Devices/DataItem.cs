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
using CoordinateSystemTypes = MtconnectCore.Standard.Contracts.Enums.Devices.CoordinateSystemTypes;

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
            .Validate((o) =>
                o.ValidateValueProperty<DataItemAttributes>(nameof(DataItem), nameof(DataItemAttributes.CATEGORY))
                ?.ValidateEnumValue<CategoryTypes>(nameof(Category), Category)
            )
            // compositionId
            .Validate((o) =>
                o.ValidateValueProperty<DataItemAttributes>(nameof(DataItem), nameof(DataItemAttributes.COMPOSITION_ID))
                ?.ValidateIdValueType(nameof(CompositionId), CompositionId, false)
            )
            // coordinateSystem
            .Validate((o) =>
                o.UpToVersion(MtconnectVersions.V_1_8_1, (a) =>
                    a.ValidateValueProperty<DataItemAttributes>(nameof(DataItem), nameof(DataItemAttributes.COORDINATE_SYSTEM))
                    ?.ValidateEnumValue<CoordinateSystemTypes>(nameof(CoordinateSystem), CoordinateSystem)
                )
            )
            // discrete
            .Validate((o) =>
                o.ValidateValueProperty<DataItemAttributes>(nameof(DataItem), nameof(DataItemAttributes.DISCRETE))
                ?.ValidateBooleanValueType(nameof(Discrete), Discrete)
            )
            // id
            .Validate((o) =>
                o.ValidateValueProperty<DataItemAttributes>(nameof(DataItem), nameof(DataItemAttributes.ID))
                ?.ValidateIdValueType(nameof(Id), Id)
            )
            // name
            .Validate((o) =>
                o.ValidateValueProperty<DataItemAttributes>(nameof(DataItem), nameof(DataItemAttributes.NAME))
            )
            // nativeScale
            .Validate((o) =>
                o.ValidateValueProperty<DataItemAttributes>(nameof(DataItem), nameof(DataItemAttributes.NATIVE_SCALE))
                ?.ValidateIntegerValueType(nameof(NativeScale), NativeScale)
            )
            // nativeUnits
            .Validate((o) =>
                o.ValidateValueProperty<DataItemAttributes>(nameof(DataItem), nameof(DataItemAttributes.NATIVE_UNITS))
                ?.ValidateEnumValue<NativeUnitsTypes>(nameof(NativeUnits), NativeUnits)
            )
            // sampleRate
            .Validate((o) =>
                o.ValidateValueProperty<DataItemAttributes>(nameof(DataItem), nameof(DataItemAttributes.SAMPLE_RATE))
                ?.ValidateFloatValueType(nameof(SampleRate), SampleRate)
            )
            // significantDigits
            .Validate((o) =>
                o.ValidateValueProperty<DataItemAttributes>(nameof(DataItem), nameof(DataItemAttributes.SIGNIFICANT_DIGITS))
                ?.ValidateIntegerValueType(nameof(SignificantDigits), SignificantDigits)
            )
            // statistic
            .Validate((o) =>
                o.ValidateValueProperty<DataItemAttributes>(nameof(DataItem), nameof(DataItemAttributes.STATISTIC))
                ?.ValidateEnumValue<StatisticTypes>(nameof(Statistic), Statistic)
            )
            // type/subType
            .Validate((o) =>
                o.ValidateValueProperty<DataItemAttributes>(nameof(DataItem), nameof(DataItemAttributes.TYPE))
                ?.ValidateValueProperty<DataItemAttributes>(nameof(DataItem), nameof(DataItemAttributes.SUB_TYPE))
                ?.ValidateRequired(nameof(Type), Type)
                ?.ValidateType(Category, Type, SubType)
            )
            // units
            .Validate((o) =>
                o.ValidateValueProperty<DataItemAttributes>(nameof(DataItem), nameof(DataItemAttributes.UNITS))
                ?.If(
                    (v) => Category.Equals("SAMPLE", StringComparison.OrdinalIgnoreCase),
                    (v) => o?.ValidateRequired(nameof(Units), Units)
                )
                ?.ValidateEnumValue<UnitsTypes>(nameof(Units), Units)
            )
            // representation
            .Validate((o) =>
                o.ValidateValueProperty<DataItemAttributes>(nameof(DataItem), nameof(DataItemAttributes.REPRESENTATION))
                ?.ValidateEnumValue<RepresentationTypes>(nameof(Representation), Representation)
            )
            // coordinateSystemIdRef
            .Validate((o) =>
                o.ValidateValueProperty<DataItemAttributes>(nameof(DataItem), nameof(DataItemAttributes.COORDINATE_SYSTEM_ID_REF))
                ?.ValidateIdValueType(nameof(CoordinateSystemIdRef), CoordinateSystemIdRef, false)
            )
            .HasError(out validationErrors);

        // Validate all elements for the data item
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DATA_ITEM)]
        private bool validateParts(out ICollection<MtconnectValidationException> validationErrors)
            => new NodeValidationContext(this)
            // Source
            .Validate(o =>
                o.ValidateValueProperty<DataItemElements>(nameof(DataItem), nameof(DataItemElements.SOURCE))
                // Source validated when set
            )
            // Constraints
            .Validate(o =>
                o.ValidateValueProperty<DataItemElements>(nameof(DataItem), nameof(DataItemElements.CONSTRAINTS))
                // Constraints validated when set
            )
            // Filter
            .Validate(o =>
                o.ValidateValueProperty<DataItemElements>(nameof(DataItem), nameof(DataItemElements.FILTERS))
                // Filter validated when set
            )
            // InitialValue
            .Validate(o =>
                o.ValidateValueProperty<DataItemElements>(nameof(DataItem), nameof(DataItemElements.INITIAL_VALUE))
                // InitialValue validated when set
            )
            // ResetTrigger
            .Validate(o =>
                o.ValidateValueProperty<DataItemElements>(nameof(DataItem), nameof(DataItemElements.RESET_TRIGGER))
                ?.ValidateEnumValue<ResetTriggeredValues>(nameof(ResetTrigger), ResetTrigger)
            )
            // Definition
            .Validate(o =>
                o.ValidateValueProperty<DataItemElements>(nameof(DataItem), nameof(DataItemElements.DEFINITION))
                // Definition validated when set
            )
            // TODO: Relationships
            .HasError(out validationErrors);
    }
}
