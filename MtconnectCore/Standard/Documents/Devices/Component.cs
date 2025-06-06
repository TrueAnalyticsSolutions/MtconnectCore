﻿using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.ComponentTypes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <summary>
    /// Channel represents each sensing element connected to a sensor unit.
    /// </summary>
    /// <remarks>See Part 2 Section 4.4 of the MTConnect specification.</remarks>
    public class Component : MtconnectNode
    {
        private const string MODEL_BROWSER_URL = "https://model.mtconnect.org/#Structure__EAID_8548C620_467A_4f50_9A22_58D84B7E8779";

        /// <inheritdoc cref="ComponentAttributes.ID"/>
        [MtconnectNodeAttribute(ComponentAttributes.ID)]
        public string Id { get; set; }

        /// <inheritdoc cref="ComponentAttributes.SUB_CLASS"/>
        public ParsedValue<ComponentTypes> SubClass { get; set; } = new ParsedValue<ComponentTypes>();

        /// <inheritdoc cref="ComponentAttributes.NAME"/>
        [MtconnectNodeAttribute(ComponentAttributes.NAME)]
        public string Name { get; set; }

        /// <inheritdoc cref="ComponentAttributes.NATIVE_NAME"/>
        [MtconnectNodeAttribute(ComponentAttributes.NATIVE_NAME)]
        public string NativeName { get; set; }

        /// <inheritdoc cref="ComponentAttributes.SAMPLE_INTERVAL"/>
        [MtconnectNodeAttribute(ComponentAttributes.SAMPLE_INTERVAL)]
        public string SampleInterval { get; set; }

        /// <inheritdoc cref="ComponentAttributes.SAMPLE_RATE"/>
        [MtconnectNodeAttribute(ComponentAttributes.SAMPLE_RATE)]
        public string SampleRate { get; set; }

        /// <inheritdoc cref="ComponentAttributes.UUID"/>
        [MtconnectNodeAttribute(ComponentAttributes.UUID)]
        public string Uuid { get; set; }

        /// <inheritdoc cref="ComponentAttributes.COORDINATE_SYSTEM_ID_REF"/>
        [MtconnectNodeAttribute(ComponentAttributes.COORDINATE_SYSTEM_ID_REF)]
        public string CoordinateSystemIdRef { get; set; }

        /// <summary>
        /// Explicit reference to the XML tag name. This can be more reliable than referencing <see cref="Name"/>
        /// </summary>
        public string TagName { get; set; }

        /// <inheritdoc cref="ComponentElements.DESCRIPTION"/>
        [MtconnectNodeElements("Description", nameof(TrySetDescription))]
        public Description Description { get; set; }

        /// <inheritdoc cref="ComponentElements.CONFIGURATION"/>
        [MtconnectNodeElements("Configuration", nameof(TrySetConfiguration))]
        public ComponentConfiguration Configuration { get; set; }

        /// <summary>
        /// Cumulative number of sub-components, including the size of all sub-components.
        /// </summary>
        public int Size => _subComponents?.Sum(o => o.Size) ?? 1;

        private List<Component> _subComponents = new List<Component>();
        /// <inheritdoc cref="ComponentElements.COMPONENTS"/>
        [MtconnectNodeElements("Components/*", nameof(TryAddComponent))]
        public ICollection<Component> SubComponents => _subComponents;

        private List<DataItem> _dataItems = new List<DataItem>();
        /// <inheritdoc cref="ComponentElements.DATA_ITEMS"/>
        [MtconnectNodeElements("DataItems/*", nameof(TryAddDataItem))]
        public ICollection<DataItem> DataItems => _dataItems;

        private List<Composition> _compositions = new List<Composition>();
        /// <inheritdoc cref="ComponentElements.COMPOSITIONS"/>
        [MtconnectNodeElements("Compositions/*", nameof(TryAddComposition))]
        public ICollection<Composition> Compositions => _compositions;

        private List<Reference> _references = new List<Reference>();
        /// <inheritdoc cref="ComponentElements.REFERENCES"/>
        [MtconnectNodeElements("References/*", nameof(TryAddReference))]
        public ICollection<Reference> References => _references;

        // WARNING: This is a deviation from the standard model, but I'm not sure how to model interfaces quite yet.
        private List<Interface> _interfaces = new List<Interface>();
        public ICollection<Interface> Interfaces => _interfaces;

        /// <inheritdoc />
        public Component() : base() { }

        /// <inheritdoc />
        public Component(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version)
        {
            TagName = xNode.LocalName;
            SubClass.RawValue = TagName;
            if (!string.IsNullOrEmpty(TagName) && EnumHelper.TryParse<ComponentTypes>(TagName, out var componentType) && componentType.HasValue)
            {
                SubClass.Value = componentType.Value;
            }
        }

        public bool TryAddComponent(XmlNode xNode, XmlNamespaceManager nsmgr, out Component component)
        {
            if (xNode.LocalName.EndsWith("Interface", System.StringComparison.OrdinalIgnoreCase))
            {
                var result = base.TryAdd<Interface>(xNode, nsmgr, ref _interfaces, out Interface @interface);
                component = null;
                return result;
            } else
            {
                return base.TryAdd<Component>(xNode, nsmgr, ref _subComponents, out component);
            }
        }

        public bool TryAddInterface(XmlNode xNode, XmlNamespaceManager nsmgr, out Interface @interface)
            => base.TryAdd<Interface>(xNode, nsmgr, ref _interfaces, out @interface);

        public bool TryAddDataItem(XmlNode xNode, XmlNamespaceManager nsmgr, out DataItem dataItem)
            => base.TryAdd<DataItem>(xNode, nsmgr, ref _dataItems, out dataItem);

        public bool TrySetDescription(XmlNode xNode, XmlNamespaceManager nsmgr, out Description componentDescription)
            => base.TrySet<Description>(xNode, nsmgr, nameof(Description), out componentDescription);

        public bool TrySetConfiguration(XmlNode xNode, XmlNamespaceManager nsmgr, out ComponentConfiguration componentConfiguration)
            => base.TrySet<ComponentConfiguration>(xNode, nsmgr, nameof(Configuration), out componentConfiguration);

        public bool TryAddComposition(XmlNode xNode, XmlNamespaceManager nsmgr, out Composition composition)
            => base.TryAdd<Composition>(xNode, nsmgr, ref _compositions, out composition);

        public bool TryAddReference(XmlNode xNode, XmlNamespaceManager nsmgr, out Reference reference)
        {
            Logger.Verbose("Reading Reference {XnodeKey}", xNode.TryGetAttribute(ReferenceAttributes.ID_REF));
            if (xNode.LocalName == ComponentElements.COMPONENT_REF.ToPascalCase()) {
                reference = new ComponentRef(xNode, nsmgr, MtconnectVersion.GetValueOrDefault());
            }
            else if (xNode.LocalName == ComponentElements.DATA_ITEM_REF.ToPascalCase())
            {
                reference = new DataItemRef(xNode, nsmgr, MtconnectVersion.GetValueOrDefault());
            } else
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


        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DeviceModel.COMPONENT)]
        protected virtual bool validateValueProperties(out ICollection<MtconnectValidationException> validationErrors)
            => new NodeValidationContext(this)
            .ValidateValueProperty<ComponentAttributes>(nameof(ComponentAttributes.SUB_CLASS), (o) => 
                o.IsEnumValueType<ComponentTypes>(nameof(ComponentAttributes.SUB_CLASS), this.TagName, out var componentType)
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

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DeviceModel.COMPONENT)]
        protected virtual bool validateParts(out ICollection<MtconnectValidationException> validationErrors)
            => new NodeValidationContext(this)
                .Validate((o) =>
                    o.HasAtLeastOne(
                        Pairings.Of(nameof(ComponentElements.COMPONENTS), SubComponents),
                        Pairings.Of(nameof(ComponentElements.DATA_ITEMS), DataItems),
                        Pairings.Of(nameof(ComponentElements.REFERENCES), References)
                    )
                )
                .UpdateHelpLinks(MODEL_BROWSER_URL)
                .HasError(out validationErrors);
    }
}
