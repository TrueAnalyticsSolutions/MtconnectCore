using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.ComponentTypes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Enums.Devices.InterfaceTypes;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Devices
{
    public class Interface : MtconnectNode
    {
        private const string MODEL_BROWSER_URL = "https://model.mtconnect.org/#Structure__EAID_8548C620_467A_4f50_9A22_58D84B7E8779";

        /// <inheritdoc cref="InterfaceAttributes.ID"/>
        public InterfaceState State { get; set; }

        /// <inheritdoc cref="InterfaceAttributes.ID"/>
        [MtconnectNodeAttribute(InterfaceAttributes.ID)]
        public string Id { get; set; }

        /// <inheritdoc cref="InterfaceAttributes.SUB_CLASS"/>
        public ParsedValue<InterfaceTypes> SubClass { get; set; } = new ParsedValue<InterfaceTypes>();

        /// <inheritdoc cref="InterfaceAttributes.NAME"/>
        [MtconnectNodeAttribute(InterfaceAttributes.NAME)]
        public string Name { get; set; }

        /// <inheritdoc cref="InterfaceAttributes.NATIVE_NAME"/>
        [MtconnectNodeAttribute(InterfaceAttributes.NATIVE_NAME)]
        public string NativeName { get; set; }

        /// <inheritdoc cref="InterfaceAttributes.SAMPLE_INTERVAL"/>
        [MtconnectNodeAttribute(InterfaceAttributes.SAMPLE_INTERVAL)]
        public string SampleInterval { get; set; }

        /// <inheritdoc cref="InterfaceAttributes.SAMPLE_RATE"/>
        [MtconnectNodeAttribute(InterfaceAttributes.SAMPLE_RATE)]
        public string SampleRate { get; set; }

        /// <inheritdoc cref="InterfaceAttributes.UUID"/>
        [MtconnectNodeAttribute(InterfaceAttributes.UUID)]
        public string Uuid { get; set; }

        /// <inheritdoc cref="InterfaceAttributes.COORDINATE_SYSTEM_ID_REF"/>
        [MtconnectNodeAttribute(InterfaceAttributes.COORDINATE_SYSTEM_ID_REF)]
        public string CoordinateSystemIdRef { get; set; }

        /// <summary>
        /// Explicit reference to the XML tag name. This can be more reliable than referencing <see cref="Name"/>
        /// </summary>
        public string TagName { get; set; }

        /// <inheritdoc cref="InterfaceElements.DESCRIPTION"/>
        [MtconnectNodeElements("Description", nameof(TrySetDescription))]
        public Description Description { get; set; }

        /// <inheritdoc cref="InterfaceElements.CONFIGURATION"/>
        [MtconnectNodeElements("Configuration", nameof(TrySetConfiguration))]
        public ComponentConfiguration Configuration { get; set; }

        /// <summary>
        /// Cumulative number of sub-components, including the size of all sub-components.
        /// </summary>
        public int Size => _subComponents?.Sum(o => o.Size) ?? 1;

        private List<Component> _subComponents = new List<Component>();
        /// <inheritdoc cref="InterfaceElements.COMPONENTS"/>
        [MtconnectNodeElements("Components/*", nameof(TryAddComponent))]
        public ICollection<Component> SubComponents => _subComponents;

        private List<DataItem> _dataItems = new List<DataItem>();
        /// <inheritdoc cref="InterfaceElements.DATA_ITEMS"/>
        [MtconnectNodeElements("DataItems/*", nameof(TryAddDataItem))]
        public ICollection<DataItem> DataItems => _dataItems;

        private List<Composition> _compositions = new List<Composition>();
        /// <inheritdoc cref="InterfaceElements.COMPOSITIONS"/>
        [MtconnectNodeElements("Compositions/*", nameof(TryAddComposition))]
        public ICollection<Composition> Compositions => _compositions;

        private List<Reference> _references = new List<Reference>();
        /// <inheritdoc cref="InterfaceElements.REFERENCES"/>
        [MtconnectNodeElements("References/*", nameof(TryAddReference))]
        public ICollection<Reference> References => _references;

        /// <inheritdoc />
        public Interface() : base() { }

        /// <inheritdoc />
        public Interface(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version)
        {
            TagName = xNode.LocalName;
            SubClass.RawValue = TagName;
            if (!string.IsNullOrEmpty(TagName) && EnumHelper.TryParse<InterfaceTypes>(TagName, out var interfaceType) && interfaceType.HasValue)
            {
                SubClass.Value = interfaceType.Value;
            }
        }

        public bool TryAddComponent(XmlNode xNode, XmlNamespaceManager nsmgr, out Component component)
            => base.TryAdd<Component>(xNode, nsmgr, ref _subComponents, out component);

        public bool TryAddDataItem(XmlNode xNode, XmlNamespaceManager nsmgr, out DataItem dataItem)
        {
            if ((xNode is XmlElement xElement) && xElement.LocalName.Equals("DataItem", StringComparison.OrdinalIgnoreCase) && xElement.HasAttribute("type"))
            {
                var type = xElement.GetAttribute("type");
                if (type.Equals("INTERFACE_STATE", StringComparison.OrdinalIgnoreCase))
                {
                    State = new InterfaceState(xNode, nsmgr, this.MtconnectVersion.GetValueOrDefault());
                    dataItem = State;
                    return true;
                } else
                {
                    return base.TryAdd<DataItem>(xNode, nsmgr, ref _dataItems, out dataItem);
                }
            }
            dataItem = null;
            return false;
        }

        public bool TrySetDescription(XmlNode xNode, XmlNamespaceManager nsmgr, out Description componentDescription)
            => base.TrySet<Description>(xNode, nsmgr, nameof(Description), out componentDescription);

        public bool TrySetConfiguration(XmlNode xNode, XmlNamespaceManager nsmgr, out ComponentConfiguration componentConfiguration)
            => base.TrySet<ComponentConfiguration>(xNode, nsmgr, nameof(Configuration), out componentConfiguration);

        public bool TryAddComposition(XmlNode xNode, XmlNamespaceManager nsmgr, out Composition composition)
            => base.TryAdd<Composition>(xNode, nsmgr, ref _compositions, out composition);

        public bool TryAddReference(XmlNode xNode, XmlNamespaceManager nsmgr, out Reference reference)
        {
            Logger.Verbose("Reading Reference {XnodeKey}", xNode.TryGetAttribute(ReferenceAttributes.ID_REF));
            if (xNode.LocalName == ComponentElements.COMPONENT_REF.ToPascalCase())
            {
                reference = new ComponentRef(xNode, nsmgr, MtconnectVersion.GetValueOrDefault());
            }
            else if (xNode.LocalName == ComponentElements.DATA_ITEM_REF.ToPascalCase())
            {
                reference = new DataItemRef(xNode, nsmgr, MtconnectVersion.GetValueOrDefault());
            }
            else
            {
                reference = null;
                Logger.Warn("[Invalid Probe] Unsupported Reference type {XnodeName}", xNode.LocalName);
                return false;
            }
            if (!reference.TryValidate())
            {
                //InitializationErrors.AddRange(validationExceptions);
                //Logger.Warn($"[Invalid Probe] Reference of Component '{TagName}':\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            _references.Add(reference);
            return true;
        }


        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, Constants.ModelBrowserLinks.DeviceModel.INTERFACE)]
        protected virtual bool validateValueProperties(out ICollection<MtconnectValidationException> validationErrors)
            => new NodeValidationContext(this)
            .ValidateValueProperty<InterfaceAttributes>(nameof(InterfaceAttributes.SUB_CLASS), (o) =>
                o.IsEnumValueType<InterfaceTypes>(nameof(InterfaceAttributes.SUB_CLASS), this.TagName, out var componentType)
            )
            // id
            .ValidateValueProperty<ComponentAttributes>(nameof(ComponentAttributes.ID), (o) =>
                o.WhileIntroduced((x) =>
                    x.IsImplemented()
                    .IsIdValueType(Id)
                )
                ?.WhileNotIntroduced((x) =>
                    x.IsImplemented(nameof(ComponentAttributes.ID))
                    .IsIdValueType(Id, false)
                )
            )
            // name
            .ValidateValueProperty<ComponentAttributes>(nameof(ComponentAttributes.NAME), (o) =>
                o.IsImplemented(nameof(ComponentAttributes.NAME))
            )
            // nativeName
            .ValidateValueProperty<ComponentAttributes>(nameof(ComponentAttributes.NATIVE_NAME), (o) =>
                o.IsImplemented(nameof(ComponentAttributes.NATIVE_NAME))
            )
            // sampleInterval
            .ValidateValueProperty<ComponentAttributes>(nameof(ComponentAttributes.SAMPLE_INTERVAL), (o) =>
                o.IsImplemented(nameof(ComponentAttributes.SAMPLE_INTERVAL))
                ?.IsFloatValueType(SampleInterval, out _)
            )
            // sampleRate
            .ValidateValueProperty<ComponentAttributes>(nameof(ComponentAttributes.SAMPLE_RATE), (o) =>
                o.IsImplemented(nameof(ComponentAttributes.SAMPLE_RATE))
                ?.IsFloatValueType(SampleRate, out _)
            )
            // uuid
            .ValidateValueProperty<ComponentAttributes>(nameof(ComponentAttributes.UUID), (o) =>
                o.IsImplemented(nameof(ComponentAttributes.UUID))
                ?.IsIdValueType(Uuid, false)
            )
            // coordinateSystemIdRef
            .ValidateValueProperty<ComponentAttributes>(nameof(ComponentAttributes.COORDINATE_SYSTEM_ID_REF), (o) =>
                o.IsImplemented(nameof(ComponentAttributes.COORDINATE_SYSTEM_ID_REF))
                ?.IsIdValueType(CoordinateSystemIdRef, false)
            )
            .UpdateHelpLinks(MODEL_BROWSER_URL)
            .HasError(out validationErrors);

        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, Constants.ModelBrowserLinks.DeviceModel.INTERFACE)]
        protected virtual bool validateParts(out ICollection<MtconnectValidationException> validationErrors)
            => new NodeValidationContext(this)
                .Validate((o) =>
                    o.HasAtLeastOne(
                        Pairings.Of(nameof(ComponentElements.COMPONENTS), SubComponents),
                        Pairings.Of(nameof(ComponentElements.DATA_ITEMS), DataItems),
                        Pairings.Of(nameof(ComponentElements.REFERENCES), References)
                    )
                )
                .ValidateValueProperty<InterfaceElements>(nameof(InterfaceElements.INTERFACE_STATE), (o) => {
                    var ns = MtconnectNodeParser.GetNamespaceName(SourceNode);
                    var interfaceStateCount = SourceNode.SelectNodes($"{ns}:DataItems/{ns}:DataItem[@type='INTERFACE_STATE']", base.NamespaceManager).Count;
                    if (interfaceStateCount > 1)
                    {
                        o.AddError($"Only one DataItem with type='INTERFACE_STATE'.", Pairings.Of("count(DataItem[type='INTERFACE_STATE'])", interfaceStateCount));
                    }
                    else if (interfaceStateCount <= 0)
                    {
                        o.AddError($"Must contain one DataItem with type='INTERFACE_STATE'.", Pairings.Of("count(DataItem[type='INTERFACE_STATE'])", interfaceStateCount));
                    }
                    else if (State == null)
                    {
                        o.AddError($"Unable to validate INTERFACE_STATE");
                    }
                    return o;
                })
                .UpdateHelpLinks(MODEL_BROWSER_URL)
                .HasError(out validationErrors);
    }
}
