using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
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
        /// <inheritdoc cref="ComponentAttributes.ID"/>
        [MtconnectNodeAttribute(ComponentAttributes.ID)]
        public string Id { get; set; }

        /// <inheritdoc cref="ComponentAttributes.NAME"/>
        [MtconnectNodeAttribute(ComponentAttributes.NAME)]
        public string Name { get; set; }

        /// <inheritdoc cref="ComponentAttributes.NATIVE_NAME"/>
        [MtconnectNodeAttribute(ComponentAttributes.NATIVE_NAME)]
        public string NativeName { get; set; }

        /// <inheritdoc cref="ComponentAttributes.SAMPLE_INTERVAL"/>
        [MtconnectNodeAttribute(ComponentAttributes.SAMPLE_INTERVAL)]
        public double? SampleInterval { get; set; }

        /// <inheritdoc cref="ComponentAttributes.SAMPLE_RATE"/>
        [MtconnectNodeAttribute(ComponentAttributes.SAMPLE_RATE)]
        public double? SampleRate { get; set; }

        /// <inheritdoc cref="ComponentAttributes.UUID"/>
        [MtconnectNodeAttribute(ComponentAttributes.UUID)]
        public string Uuid { get; set; }

        /// <summary>
        /// Explicit reference to the XML tag name. This can be more reliable than referencing <see cref="Name"/>
        /// </summary>
        public string TagName { get; set; }

        /// <inheritdoc cref="ComponentElements.DESCRIPTION"/>
        [MtconnectNodeElements("Description", nameof(TrySetDescription), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ComponentDescription Description { get; set; }

        /// <inheritdoc cref="ComponentElements.CONFIGURATION"/>
        [MtconnectNodeElements("Configuration", nameof(TrySetConfiguration), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ComponentConfiguration Configuration { get; set; }

        /// <summary>
        /// Cumulative number of sub-components, including the size of all sub-components.
        /// </summary>
        public int Size => _subComponents?.Sum(o => o.Size) ?? 1;

        private List<Component> _subComponents = new List<Component>();
        /// <inheritdoc cref="ComponentElements.COMPONENTS"/>
        [MtconnectNodeElements("Components/*", nameof(TryAddComponent), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ICollection<Component> SubComponents => _subComponents;

        private List<DataItem> _dataItems = new List<DataItem>();
        /// <inheritdoc cref="ComponentElements.DATA_ITEMS"/>
        [MtconnectNodeElements("DataItems/*", nameof(TryAddDataItem), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ICollection<DataItem> DataItems => _dataItems;

        private List<Composition> _compositions = new List<Composition>();
        /// <inheritdoc cref="ComponentElements.COMPOSITIONS"/>
        [MtconnectNodeElements("Compositions/*", nameof(TryAddComposition), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ICollection<Composition> Compositions => _compositions;

        private List<Reference> _references = new List<Reference>();
        /// <inheritdoc cref="ComponentElements.REFERENCES"/>
        [MtconnectNodeElements("References/*", nameof(TryAddReference), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ICollection<Reference> References => _references;

        /// <inheritdoc />
        public Component() : base() { }

        /// <inheritdoc />
        public Component(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE, version)
        {
            TagName = xNode.LocalName;
        }

        public bool TryAddComponent(XmlNode xNode, XmlNamespaceManager nsmgr, out Component component)
            => base.TryAdd<Component>(xNode, nsmgr, ref _subComponents, out component);

        public bool TryAddDataItem(XmlNode xNode, XmlNamespaceManager nsmgr, out DataItem dataItem)
            => base.TryAdd<DataItem>(xNode, nsmgr, ref _dataItems, out dataItem);

        public bool TrySetDescription(XmlNode xNode, XmlNamespaceManager nsmgr, out ComponentDescription componentDescription)
            => base.TrySet<ComponentDescription>(xNode, nsmgr, nameof(Description), out componentDescription);

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
        
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 3.3.1")]
        private bool validateId(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Id))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Component MUST include a unique 'id' attribute.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 3.3.1", MtconnectVersions.V_1_2_0)]
        private bool validateName(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Name))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Component MUST include a unique 'name' attribute.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 3.3.1")]
        private bool validateUuid(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(Uuid) && Uuid.Length > 255)
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Component 'uuid' cannot exceed a length of 255 characters.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.3")]
        private bool validateSampleRate_Deprecated(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (SampleRate.HasValue)
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.WARNING,
                    $"Component 'sampleRate' is DEPRECATED in MTConnect Version 1.2. Replaced by 'sampleInterval'.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 3.3.2")]
        private bool validateChildCount(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (SubComponents.Count <= 0 && DataItems.Count <= 0) {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, $"At least one of Components or DataItems MUST be provided.", SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
