using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Devices
{
    public class Device : MtconnectNode
    {
        private const string MODEL_BROWSER_URL = "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1620240839406_285612_1596";

        /// <inheritdoc cref="DeviceAttributes.UUID"/>
        [MtconnectNodeAttribute(DeviceAttributes.UUID)]
        public string Uuid { get; set; }

        /// <inheritdoc cref="DeviceAttributes.NAME"/>
        [MtconnectNodeAttribute(DeviceAttributes.NAME)]
        public string Name { get; set; }

        /// <inheritdoc cref="DeviceAttributes.ID"/>
        [MtconnectNodeAttribute(DeviceAttributes.ID)]
        public string Id { get; set; }

        /// <inheritdoc cref="DeviceAttributes.SAMPLE_INTERVAL"/>
        [MtconnectNodeAttribute(DeviceAttributes.SAMPLE_INTERVAL)]
        public string SampleInterval { get; set; }

        /// <inheritdoc cref="DeviceAttributes.NATIVE_NAME"/>
        [MtconnectNodeAttribute(DeviceAttributes.NATIVE_NAME)]
        public string NativeName { get; set; }

        /// <inheritdoc cref="DeviceAttributes.SAMPLE_RATE"/>
        [MtconnectNodeAttribute(DeviceAttributes.SAMPLE_RATE)]
        public string SampleRate { get; set; }

        /// <inheritdoc cref="DeviceAttributes.ISO_841_CLASS"/>
        [MtconnectNodeAttribute(DeviceAttributes.ISO_841_CLASS)]
        public string Iso841Class { get; set; }

        /// <inheritdoc cref="DeviceAttributes.MTCONNECT_VERSION"/>
        [MtconnectNodeAttribute(DeviceAttributes.MTCONNECT_VERSION)]
        public string MtconnectVersionAttribute { get; set; }

        /// <inheritdoc cref="DeviceAttributes.HASH"/>
        [MtconnectNodeAttribute(DeviceAttributes.HASH)]
        public string Hash { get; set; }

        public int Size => _components?.Sum(o => o.Size) ?? 0;

        private List<Component> _components = new List<Component>();
        [MtconnectNodeElements("Components/*", nameof(TryAddComponent), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ICollection<Component> Components => _components;

        private List<Composition> _compositions = new List<Composition>();
        [MtconnectNodeElements("Compositions/*", nameof(TryAddComposition), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ICollection<Composition> Compositions => _compositions;

        private List<DataItem> _dataItems = new List<DataItem>();
        [MtconnectNodeElements("DataItems/*", nameof(TryAddDataItem), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ICollection<DataItem> DataItems => _dataItems;

        [MtconnectNodeElements("Description", nameof(TrySetDescription), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ComponentDescription Description { get; set; }

        /// <inheritdoc cref="ComponentElements.CONFIGURATION"/>
        [MtconnectNodeElements("Configuration", nameof(TrySetConfiguration), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ComponentConfiguration Configuration { get; set; }

        private List<Reference> _references = new List<Reference>();
        /// <inheritdoc cref="DeviceElements.REFERENCES"/>
        [MtconnectNodeElements("References/*", nameof(TryAddReference), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ICollection<Reference> References => _references;

        /// <inheritdoc/>
        public Device() : base() { }

        /// <inheritdoc/>
        public Device(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE, version) { }

        public bool TryAddComponent(XmlNode xNode, XmlNamespaceManager nsmgr, out Component component)
            => base.TryAdd<Component>(xNode, nsmgr, ref _components, out component);

        public bool TryAddComposition(XmlNode xNode, XmlNamespaceManager nsmgr, out Composition composition)
            => base.TryAdd<Composition>(xNode, nsmgr, ref _compositions, out composition);

        public bool TryAddDataItem(XmlNode xNode, XmlNamespaceManager nsmgr, out DataItem dataItem)
            => base.TryAdd<DataItem>(xNode, nsmgr, ref _dataItems, out dataItem);

        public bool TrySetDescription(XmlNode xNode, XmlNamespaceManager nsmgr, out ComponentDescription componentDescription)
            => base.TrySet<ComponentDescription>(xNode, nsmgr, nameof(Description), out componentDescription);

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
        private bool validateId(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Id)) {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, $"Device MUST include a 'id' attribute.", SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL)]
        private bool validateName(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Name))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Device MUST include a 'name' attribute.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, MODEL_BROWSER_URL)]
        private bool validateUuid(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Uuid))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Device MUST include a 'uuid' attribute.",
                    SourceNode));
            } else if (Uuid.Length > 255) {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Device 'uuid' SHOULD be alphanumeric and not exceed 255 characters.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL, MtconnectVersions.V_1_1_0)]
        private bool validateIso841Class_Required(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Iso841Class))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Device MUST include a 'iso841Class' attribute.",
                    SourceNode));
            }
            else
            {
                if (!EnumHelper.Contains<Iso841ClassTypes>(Iso841Class))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"DataItem 'iso841Class' attribute must be one of the following: [{EnumHelper.ToListString<Iso841ClassTypes>(", ", string.Empty, string.Empty)}].",
                        SourceNode));

                }
                else if (!EnumHelper.ValidateToVersion<Iso841ClassTypes>(Iso841Class, MtconnectVersion.GetValueOrDefault()))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"DataItem iso841Class of '{Iso841Class}' is not supported in version '{MtconnectVersion}' of the MTConnect Standard.",
                        SourceNode));
                }
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, MODEL_BROWSER_URL)]
        private bool validateIso841Class_Deprecated(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();

            if (!string.IsNullOrEmpty(Iso841Class))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.WARNING,
                    $"Device 'iso841Class' was DEPRECATED in MTConnect Version 1.2.",
                    SourceNode));

                // Might as well validate the legitamacy of the attribute since it was added
                if (!EnumHelper.Contains<Iso841ClassTypes>(Iso841Class))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"Device 'iso841Class' attribute MUST be one of the following: [{EnumHelper.ToListString<Iso841ClassTypes>(", ", string.Empty, string.Empty)}].",
                        SourceNode));

                }
                else if (!EnumHelper.ValidateToVersion<Iso841ClassTypes>(Iso841Class, MtconnectVersion.GetValueOrDefault()))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"Device 'iso841Class' of '{Iso841Class}' is not supported in version '{MtconnectVersion}' of the MTConnect Standard.",
                        SourceNode));
                }
            }

            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, MODEL_BROWSER_URL)]
        private bool validateDataItemCount(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (DataItems.Count <= 0) {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, "Device must have at least one DataItem. Every Device MUST report AVAILABILITY, ASSET_CHANGED, and ASSET_REMOVED.", SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, MODEL_BROWSER_URL)]
        private bool validateDataItemAvailability(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();

            System.Func<DataItem, bool> containsAvailability = (o) => o.Type == MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.EventTypes.AVAILABILITY.ToString();
            if (!DataItems.Any(containsAvailability))
            {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, "Device MUST have an AVAILABILITY DataItem that represents this device is available to do work.", SourceNode));
            }
            else if (DataItems.Count(containsAvailability) > 1)
            {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, "Multiplicity of AVAILABILITY observed by a Device is 1.", SourceNode));
            }

            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, MODEL_BROWSER_URL)]
        private bool validateDataItemAssets(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();

            System.Func<DataItem, bool> containsAssetChanged = (o) => o.Type == MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.EventTypes.ASSET_CHANGED.ToString();
            if (!DataItems.Any(containsAssetChanged))
            {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, "Device MUST have an ASSET_CHANGED DataItem.", SourceNode));
            } else if (DataItems.Count(containsAssetChanged) > 1)
            {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, "Multiplicity of ASSET_CHANGED observed by a Device is 1.", SourceNode));
            }

            System.Func<DataItem, bool> containsAssetRemoved = (o) => o.Type == MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.EventTypes.ASSET_REMOVED.ToString();
            if (!DataItems.Any(containsAssetRemoved))
            {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, "Device MUST have an ASSET_REMOVED DataItem.", SourceNode));
            }
            else if (DataItems.Count(containsAssetRemoved) > 1)
            {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, "Multiplicity of ASSET_REMOVED observed by a Device is 1.", SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, MODEL_BROWSER_URL)]
        private bool validateContents(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (DataItems.Count <= 0 && Components.Count <= 0 && References.Count <= 0)
            {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, "Device MUST have at least one of Component, DataItem, or Reference entities.", SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

    }
}
