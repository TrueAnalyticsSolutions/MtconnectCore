using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System.Collections.Generic;
using System.Xml;

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
        public ParsedValue<CategoryEnum> Category { get; set; }

        /// <inheritdoc cref="DataItemAttributes.UNITS"/>
        [MtconnectNodeAttribute(DataItemAttributes.UNITS)]
        public ParsedValue<UnitEnum> Units { get; set; }

        /// <inheritdoc cref="DataItemAttributes.SUB_TYPE"/>
        [MtconnectNodeAttribute(DataItemAttributes.SUB_TYPE)]
        public string SubType { get; set; }

        /// <inheritdoc cref="DataItemAttributes.NATIVE_UNITS"/>
        [MtconnectNodeAttribute(DataItemAttributes.NATIVE_UNITS)]
        public ParsedValue<NativeUnitEnum> NativeUnits { get; set; }

        /// <inheritdoc cref="DataItemAttributes.NATIVE_SCALE"/>
        [MtconnectNodeAttribute(DataItemAttributes.NATIVE_SCALE)]
        public ParsedValue<uint?> NativeScale { get; set; }

        /// <inheritdoc cref="DataItemAttributes.STATISTIC"/>
        [MtconnectNodeAttribute(DataItemAttributes.STATISTIC)]
        public ParsedValue<StatisticEnum> Statistic { get; set; }

        /// <inheritdoc cref="DataItemAttributes.REPRESENTATION"/>
        [MtconnectNodeAttribute(DataItemAttributes.REPRESENTATION)]
        public ParsedValue<RepresentationEnum> Representation { get; set; } = RepresentationEnum.VALUE.ToCamelCase();

        /// <inheritdoc cref="DataItemAttributes.SIGNIFICANT_DIGITS"/>
        [MtconnectNodeAttribute(DataItemAttributes.SIGNIFICANT_DIGITS)]
        public ParsedValue<uint?> SignificantDigits { get; set; }

        /// <inheritdoc cref="DataItemAttributes.COORDINATE_SYSTEM"/>
        [MtconnectNodeAttribute(DataItemAttributes.COORDINATE_SYSTEM)]
        public ParsedValue<CoordinateSystemEnum> CoordinateSystem { get; set; }

        /// <inheritdoc cref="DataItemAttributes.COORDINATE_SYSTEM_ID_REF"/>
        [MtconnectNodeAttribute(DataItemAttributes.COORDINATE_SYSTEM_ID_REF)]
        public string CoordinateSystemIdRef { get; set; }

        /// <inheritdoc cref="DataItemAttributes.COMPOSITION_ID"/>
        [MtconnectNodeAttribute(DataItemAttributes.COMPOSITION_ID)]
        public string CompositionId { get; set; }

        /// <inheritdoc cref="DataItemAttributes.DISCRETE"/>
        [MtconnectNodeAttribute(DataItemAttributes.DISCRETE)]
        public ParsedValue<bool> Discrete { get; set; } = new ParsedValue<bool> { RawValue = "false", Value = false };

        /// <inheritdoc cref="DataItemAttributes.SAMPLE_RATE"/>
        [MtconnectNodeAttribute(DataItemAttributes.SAMPLE_RATE)]
        public ParsedValue<float?> SampleRate { get; set; }

        /// <inheritdoc cref="DataItemElements.SOURCE"/>
        [MtconnectNodeElements(DataItemElements.SOURCE, nameof(TrySetSource))]
        public Source Source { get; set; }

        // TODO: Fix the multiplicity. The Constraints element can only have one instance, the sub-elements are the properties.
        private List<DataItemConstraint> _constraints = new List<DataItemConstraint>();
        /// <inheritdoc cref="DataItemElements.CONSTRAINTS"/>
        [MtconnectNodeElements("Constraints/*", nameof(TryAddConstraint))]
        public ICollection<DataItemConstraint> Constraints => _constraints;

        private List<Filter> _filters = new List<Filter>();
        /// <inheritdoc cref="DataItemElements.FILTERS"/>
        [MtconnectNodeElements("Filters/*", nameof(TryAddFilter))]
        public ICollection<Filter> Filters => _filters;

        /// <inheritdoc cref="DataItemElements.INITIAL_VALUE"/>
        [MtconnectNodeElement(DataItemElements.INITIAL_VALUE)]
        public string InitialValue { get; set; }

        /// <inheritdoc cref="DataItemElements.RESET_TRIGGER"/>
        [MtconnectNodeElement(DataItemElements.RESET_TRIGGER)]
        public string ResetTrigger { get; set; }

        [MtconnectNodeElements("Definition", nameof(TrySetDefinition))]
        public DataItemDefinition Definition { get; set; }

        /// <inheritdoc/>
        public DataItem() : base() { }

        /// <inheritdoc/>
        public DataItem(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        public bool TrySetSource(XmlNode xNode, XmlNamespaceManager nsmgr, out Source source)
            => base.TrySet<Source>(xNode, nsmgr, nameof(Source), out source);

        public bool TryAddConstraint(XmlNode xNode, XmlNamespaceManager nsmgr, out DataItemConstraint constraint)
            => base.TryAdd<DataItemConstraint>(xNode, nsmgr, ref _constraints, out constraint);

        public bool TryAddFilter(XmlNode xNode, XmlNamespaceManager nsmgr, out Filter filter)
            => base.TryAdd<Filter>(xNode, nsmgr, ref _filters, out filter);

        public bool TrySetDefinition(XmlNode xNode, XmlNamespaceManager nsmgr, out DataItemDefinition dataItemDefinition)
            => base.TrySet<DataItemDefinition>(xNode, nsmgr, nameof(Definition), out dataItemDefinition);

        // Validate all attributes for the data item
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DeviceModel.DATA_ITEM)]
        private bool validateValueProperties(out ICollection<MtconnectValidationException> validationErrors)
            => (new NodeValidationContext(this))
            // category
            .ValidateValueProperty(
                DataItemAttributes.CATEGORY,
                (o) =>
                    o.IsImplemented(Category)
                    ?.WhileIntroduced((i) =>
                        i.IsRequired(Category)
                    )
                    ?.IsEnumValueType(Category, out _)
            )
            // compositionId
            .ValidateValueProperty(
                DataItemAttributes.COMPOSITION_ID,
                (o) =>
                    o.IsImplemented(CompositionId)
                    ?.IsIdValueType(CompositionId, false)
            )
            // coordinateSystem
            .ValidateValueProperty(
                DataItemAttributes.COORDINATE_SYSTEM,
                (o) =>
                    o.IsImplemented(CoordinateSystem)
                    ?.IsEnumValueType<CoordinateSystemEnum>(CoordinateSystem, out _)
            )
            // discrete
            .ValidateValueProperty(
                DataItemAttributes.DISCRETE,
                (o) =>
                    o.IsImplemented(Discrete)
                    ?.WhileIntroduced((i) =>
                        i.IsRequired(Discrete)
                    )
                    ?.IsBooleanValueType(Discrete, out _)
            )
            // id
            .ValidateValueProperty(
                DataItemAttributes.ID,
                (o) =>
                    o.IsImplemented(Id)
                    ?.WhileIntroduced((i) =>
                        i.IsRequired(Id)
                    )
                    ?.IsIdValueType(Id)
            )
            // name
            .ValidateValueProperty(
                DataItemAttributes.NAME,
                (o) =>
                    o.IsImplemented(Name)
            )
            // nativeScale
            .ValidateValueProperty(
                DataItemAttributes.NATIVE_SCALE,
                (o) =>
                    o.IsImplemented(NativeScale)
                    ?.IsUIntValueType(NativeScale, out _)
            )
            // nativeUnits
            .ValidateValueProperty(
                DataItemAttributes.NATIVE_UNITS,
                (o) =>
                    o.IsImplemented(NativeUnits)
                    ?.ValidateNativeUnits(NativeUnits)
            )
            // sampleRate
            .ValidateValueProperty(
                DataItemAttributes.SAMPLE_RATE,
                (o) =>
                    o.IsImplemented(SampleRate)
                    ?.IsFloatValueType(SampleRate, out _)
            )
            // significantDigits
            .ValidateValueProperty(
                DataItemAttributes.SIGNIFICANT_DIGITS,
                (o) =>
                    o.IsImplemented(SignificantDigits)
                    ?.IsUIntValueType(SignificantDigits, out _)
            )
            // statistic
            .ValidateValueProperty(
                DataItemAttributes.STATISTIC,
                (o) =>
                    o.IsImplemented(Statistic)
                    ?.IsEnumValueType(Statistic, out _)
            )
            // type/subType
            .ValidateValueProperty(
                DataItemAttributes.TYPE,
                ValidateTypeSubType
            )
            // units
            .ValidateValueProperty(
                DataItemAttributes.UNITS,
                (o) =>
                    o.IsImplemented(Units)
                    ?.If(
                        (v) => Category == CategoryEnum.SAMPLE,
                        (v) => o?.IsRequired(Units)
                                ?.IsEnumValueType(Units, out _)
                    )
            )
            // representation
            .ValidateValueProperty(
                DataItemAttributes.REPRESENTATION,
                (o) =>
                    o.IsImplemented(Representation)
                    ?.IsEnumValueType(Representation, out _)
            )
            // coordinateSystemIdRef
            .ValidateValueProperty(
                DataItemAttributes.COORDINATE_SYSTEM_ID_REF,
                (o) =>
                    o.IsImplemented(CoordinateSystemIdRef)
                    ?.IsIdValueType(CoordinateSystemIdRef, false)
            )
            .UpdateHelpLinks(MODEL_BROWSER_URL)
            .HasError(out validationErrors);

        /// <summary>
        /// Validates the <see cref="Type"/> and <see cref="SubType"/> fields according to the standard DataItemEnum
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        protected virtual NodeValidationContext.NodeValidator ValidateTypeSubType(NodeValidationContext.NodeValueValidator<DataItemAttributes> o)
            => o.IsImplemented(Type)
                ?.IsImplemented(SubType)
                ?.IsRequired(Type)
                ?.ValidateType(Category, Type, SubType);

        // Validate all elements for the data item
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DeviceModel.DATA_ITEM)]
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
            .ValidateValueProperty(
                DataItemElements.FILTERS,
                o =>
                    o.HasMultiplicity(nameof(DataItemElements.FILTERS), Filters, 0, int.MaxValue)
            )
            // InitialValue
            .ValidateValueProperty<DataItemElements>(nameof(DataItemElements.INITIAL_VALUE), o =>
                o
                // InitialValue validated when set
            )
            // ResetTrigger
            .ValidateValueProperty(
                DataItemElements.RESET_TRIGGER,
                o =>
                    o.IsEnumValueType<ResetTriggeredEnum>(nameof(ResetTrigger), ResetTrigger, out _)
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
