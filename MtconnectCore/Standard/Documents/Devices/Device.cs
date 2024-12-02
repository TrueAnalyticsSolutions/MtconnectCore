using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;
using EventTypes = MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.EventTypes;

namespace MtconnectCore.Standard.Documents.Devices
{
    public class Device : MtconnectNode
    {
        private const string MODEL_BROWSER_URL = Constants.ModelBrowserLinks.DeviceModel.DEVICE;

        /// <inheritdoc cref="DeviceAttributes.UUID"/>
        [MtconnectNodeAttribute(DeviceAttributes.UUID)]
        public string Uuid { get; set; }

        /// <inheritdoc cref="DeviceAttributes.NAME"/>
        [MtconnectNodeAttribute(DeviceAttributes.NAME)]
        public string Name { get; set; }

        /// <inheritdoc cref="ComponentAttributes.ID"/>
        [MtconnectNodeAttribute(ComponentAttributes.ID)]
        public string Id { get; set; }

        /// <inheritdoc cref="ComponentAttributes.SAMPLE_INTERVAL"/>
        [MtconnectNodeAttribute(ComponentAttributes.SAMPLE_INTERVAL)]
        public ParsedValue<float?> SampleInterval { get; set; }

        /// <inheritdoc cref="ComponentAttributes.NATIVE_NAME"/>
        [MtconnectNodeAttribute(ComponentAttributes.NATIVE_NAME)]
        public string NativeName { get; set; }

        /// <inheritdoc cref="ComponentAttributes.SAMPLE_RATE"/>
        [MtconnectNodeAttribute(ComponentAttributes.SAMPLE_RATE)]
        public ParsedValue<float?> SampleRate { get; set; }

        /// <inheritdoc cref="DeviceAttributes.ISO_841_CLASS"/>
        [MtconnectNodeAttribute(DeviceAttributes.ISO_841_CLASS)]
        public ParsedValue<Iso841ClassTypes?> Iso841Class { get; set; }

        /// <inheritdoc cref="DeviceAttributes.MTCONNECT_VERSION"/>
        [MtconnectNodeAttribute(DeviceAttributes.MTCONNECT_VERSION)]
        public string MtconnectVersionAttribute { get; set; }

        /// <inheritdoc cref="DeviceAttributes.HASH"/>
        [MtconnectNodeAttribute(DeviceAttributes.HASH)]
        public string Hash { get; set; }

        public int Size => _components?.Sum(o => o.Size) ?? 0;

        private List<Component> _components = new List<Component>();
        [MtconnectNodeElements("Components/*", nameof(TryAddComponent))]
        public ICollection<Component> Components => _components;

        private List<Composition> _compositions = new List<Composition>();
        [MtconnectNodeElements("Compositions/*", nameof(TryAddComposition))]
        public ICollection<Composition> Compositions => _compositions;

        private List<DataItem> _dataItems = new List<DataItem>();
        [MtconnectNodeElements("DataItems/*", nameof(TryAddDataItem))]
        public ICollection<DataItem> DataItems => _dataItems;

        [MtconnectNodeElements("Description", nameof(TrySetDescription))]
        public Description Description { get; set; }

        /// <inheritdoc cref="ComponentElements.CONFIGURATION"/>
        [MtconnectNodeElements("Configuration", nameof(TrySetConfiguration))]
        public ComponentConfiguration Configuration { get; set; }

        private List<Reference> _references = new List<Reference>();
        /// <inheritdoc cref="DeviceElements.REFERENCES"/>
        [MtconnectNodeElements("References/*", nameof(TryAddReference))]
        public ICollection<Reference> References => _references;

        /// <inheritdoc/>
        public Device() : base() { }

        /// <inheritdoc/>
        public Device(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        public bool TryAddComponent(XmlNode xNode, XmlNamespaceManager nsmgr, out Component component)
            => base.TryAdd<Component>(xNode, nsmgr, ref _components, out component);

        public bool TryAddComposition(XmlNode xNode, XmlNamespaceManager nsmgr, out Composition composition)
            => base.TryAdd<Composition>(xNode, nsmgr, ref _compositions, out composition);

        public bool TryAddDataItem(XmlNode xNode, XmlNamespaceManager nsmgr, out DataItem dataItem)
            => base.TryAdd<DataItem>(xNode, nsmgr, ref _dataItems, out dataItem);

        public bool TrySetDescription(XmlNode xNode, XmlNamespaceManager nsmgr, out Description componentDescription)
            => base.TrySet<Description>(xNode, nsmgr, nameof(Description), out componentDescription);

        public bool TrySetConfiguration(XmlNode xNode, XmlNamespaceManager nsmgr, out ComponentConfiguration componentConfiguration)
            => base.TrySet<ComponentConfiguration>(xNode, nsmgr, nameof(Configuration), out componentConfiguration);

        public bool TryAddReference(XmlNode xNode, XmlNamespaceManager nsmgr, out Reference reference)
        {
            Logger.Verbose("Reading Reference {XnodeKey}", xNode.TryGetAttribute(ReferenceAttributes.ID_REF));
            if (xNode.LocalName == DeviceElements.COMPONENT_REF.ToPascalCase())
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
                //Logger.Warn($"[Invalid Probe] Reference of Device '{Uuid}':\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            _references.Add(reference);
            return true;
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL)]
        private bool ValidateProperties(out ICollection<MtconnectValidationException> validationErrors)
        {
            return new NodeValidationContext(this)
                // Validate id
                .ValidateValueProperty(
                    ComponentAttributes.ID,
                    (o) =>
                        o.IsImplemented(Id)
                        ?.WhileIntroduced((i) =>
                            i.IsRequired(Id)
                        )
                        ?.IsIdValueType(Id)
                )
                // Validate name
                .ValidateValueProperty(
                    DeviceAttributes.NAME,
                    (o) =>
                        o.IsImplemented(Name)
                        // TODO: double-check name wasn't required in previous versions
                )
                // Validate uuid
                .ValidateValueProperty(
                    DeviceAttributes.UUID,
                    (o) =>
                        o.IsImplemented(Uuid)
                        ?.WhileIntroduced((i) =>
                            i.IsRequired(Uuid)
                        )
                        ?.IsIdValueType(Uuid, false)
                )
                //// Validate iso841Class
                //.ValidateValueProperty(
                //    DeviceAttributes.ISO_841_CLASS,
                //    (o) =>
                //        o.IsImplemented(Iso841Class)
                //        ?.IsEnumValueType(Iso841Class, out _)
                //)
                // Validate DataItemCount
                .ValidateValueProperty<DeviceAttributes>(
                    nameof(DataItems),
                    (o) => o.HasMultiplicity(nameof(DataItems), DataItems, 1, int.MaxValue)
                )
                // Validate DataItemAvailability
                .ValidateValueProperty<DeviceAttributes>(
                    nameof(EventTypes.AVAILABILITY),
                    (o) =>
                        o.HasMultiplicity(
                            nameof(EventTypes.AVAILABILITY),
                            DataItems.Where(d => d.Type == EventTypes.AVAILABILITY.ToString()),
                            1,
                            int.MaxValue
                        )
                )
                // Validate DataItemAssets
                .ValidateValueProperty<DeviceAttributes>(
                    nameof(DataItems),
                    (o) =>
                        o.HasMultiplicity(
                            nameof(EventTypes.ASSET_CHANGED),
                            DataItems.Where(d => d.Type == nameof(EventTypes.ASSET_CHANGED)),
                            1,
                            int.MaxValue
                        )
                )
                .ValidateValueProperty<DeviceAttributes>(
                    nameof(DataItems),
                    (o) =>
                        o.HasMultiplicity(
                            nameof(EventTypes.ASSET_REMOVED),
                            DataItems.Where(d => d.Type == nameof(EventTypes.ASSET_REMOVED)),
                            1,
                            int.MaxValue
                        )
                )
                // Validate Contents
                .ValidateValueProperty<DeviceAttributes>(
                    nameof(DataItems),
                    (o) =>
                        o.HasMultiplicity(
                            nameof(DataItems),
                            DataItems,
                            1,
                            int.MaxValue
                        )
                )
                .UpdateHelpLinks(MODEL_BROWSER_URL)
                // Return validation errors
                .HasError(out validationErrors);
        }
    }
}
