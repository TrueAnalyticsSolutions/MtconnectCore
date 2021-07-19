using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
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

        /// <inheritdoc cref="MtconnectNode.MtconnectNode()"/>
        public Component() : base() { }

        /// <inheritdoc cref="MtconnectNode.MtconnectNode(XmlNode, XmlNamespaceManager, string)"/>
        public Component(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE)
        {
            TagName = xNode.LocalName;
        }

        public bool TryAddComponent(XmlNode xNode, XmlNamespaceManager nsmgr, out Component component)
        {
            Logger.Verbose("Reading Component {XnodeKey}", xNode.TryGetAttribute(ComponentAttributes.ID));
            component = new Component(xNode, nsmgr);
            if (!component.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Probe] Component {component.TagName} of Component '{TagName}':\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            _subComponents.Add(component);
            return true;
        }

        public bool TryAddDataItem(XmlNode xNode, XmlNamespaceManager nsmgr, out DataItem dataItem)
        {
            Logger.Verbose("Reading DataItem {XnodeKey}", xNode.TryGetAttribute(DataItemAttributes.ID));
            dataItem = new DataItem(xNode, nsmgr);
            if (!dataItem.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Probe] DataItem of Component '{TagName}':\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            _dataItems.Add(dataItem);
            return true;
        }

        public bool TrySetDescription(XmlNode xNode, XmlNamespaceManager nsmgr, out ComponentDescription componentDescription)
        {
            Logger.Verbose($"Reading ComponentDescription...");
            componentDescription = new ComponentDescription(xNode, nsmgr);
            if (!componentDescription.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Probe] Description of Component '{TagName}':\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            Description = componentDescription;
            return true;
        }

        public bool TrySetConfiguration(XmlNode xNode, XmlNamespaceManager nsmgr, out ComponentConfiguration componentConfiguration)
        {
            Logger.Verbose($"Reading ComponentConfiguration...");
            componentConfiguration = new ComponentConfiguration(xNode, nsmgr);
            if (!componentConfiguration.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Probe] Configuration of Component '{TagName}':\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            Configuration = componentConfiguration;
            return true;
        }

        public bool TryAddComposition(XmlNode xNode, XmlNamespaceManager nsmgr, out Composition composition)
        {
            Logger.Verbose("Reading Composition {XnodeKey}", xNode.TryGetAttribute(CompositionAttributes.ID));
            composition = new Composition(xNode, nsmgr);
            if (!composition.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Probe] Composition of Component '{TagName}':\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            _compositions.Add(composition);
            return true;
        }

        public bool TryAddReference(XmlNode xNode, XmlNamespaceManager nsmgr, out Reference reference)
        {
            Logger.Verbose("Reading Reference {XnodeKey}", xNode.TryGetAttribute(ReferenceAttributes.ID_REF));
            if (xNode.LocalName == ComponentElements.COMPONENT_REF.ToPascalCase()) {
                reference = new ComponentRef(xNode, nsmgr);
            } else if (xNode.LocalName == ComponentElements.DATA_ITEM_REF.ToPascalCase())
            {
                reference = new DataItemRef(xNode, nsmgr);
            } else
            {
                reference = null;
                Logger.Warn("[Invalid Probe] Unsupported Reference type {XnodeName}", xNode.LocalName);
                return false;
            }
            if (!reference.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Probe] Reference of Component '{TagName}':\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            _references.Add(reference);
            return true;
        }

        /// <inheritdoc cref="MtconnectNode.TryValidate"/>
        /// <remarks>See Part 2 Section 4.4.1 of the MTConnect specification.</remarks>
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            const string documentationAttributes = "See Part 2 Section 4.4.2 of the MTConnect standard.";
            validationErrors = new List<MtconnectValidationException>();

            if (string.IsNullOrEmpty(Id))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"DataItem MUST include a unique 'id' attribute. {documentationAttributes}"));
            }

            if (string.IsNullOrEmpty(Name))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"DataItem MUST include a unique 'name' attribute. {documentationAttributes}"));
            }

            if (SampleRate.HasValue)
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.WARNING,
                    $"DataItem 'sampleRate' is DEPRECATED in MTConnect Version 1.2. Replaced by 'sampleInterval'. {documentationAttributes}"));
            }

            if (!string.IsNullOrEmpty(Uuid) && Uuid.Length > 255)
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"DataItem 'uuid' cannot exceed a length of 255 characters. {documentationAttributes}"));
            }

            return !validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR);
        }
    }
}
