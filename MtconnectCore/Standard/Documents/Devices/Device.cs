using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Devices
{
    public class Device : MtconnectNode
    {
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

        public int Size => _components?.Sum(o => o.Size) ?? 0;

        private List<Component> _components = new List<Component>();
        [MtconnectNodeElements("Components/*", nameof(TryAddComponent), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ICollection<Component> Components => _components;

        private List<DataItem> _dataItems = new List<DataItem>();
        [MtconnectNodeElements("DataItems/*", nameof(TryAddDataItem), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ICollection<DataItem> DataItems => _dataItems;

        [MtconnectNodeElements("Description", nameof(TrySetDescription), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ComponentDescription Description { get; set; }

        /// <inheritdoc/>
        public Device() : base() { }

        /// <inheritdoc/>
        public Device(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE) { }

        public bool TryAddComponent(XmlNode xNode, XmlNamespaceManager nsmgr, out Component component)
        {
            Logger.Verbose("Reading Component {XnodeKey}", xNode.TryGetAttribute(ComponentAttributes.ID));
            component = new Component(xNode, nsmgr);
            if (!component.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Probe] Component '{component.TagName}' of Device '{Name}':\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            _components.Add(component);
            return true;
        }

        public bool TryAddDataItem(XmlNode xNode, XmlNamespaceManager nsmgr, out DataItem dataItem)
        {
            Logger.Verbose("Reading DataItem {XnodeKey}", xNode.TryGetAttribute(DataItemAttributes.ID));
            dataItem = new DataItem(xNode, nsmgr);
            if (!dataItem.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Probe] DataItem '{dataItem.Id}' of Device '{Name}':\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            _dataItems.Add(dataItem);
            return true;
        }

        public bool TrySetDescription(XmlNode xNode, XmlNamespaceManager nsmgr, out ComponentDescription componentDescription)
        {
            Logger.Verbose("Reading ComponentDescription");
            componentDescription = new ComponentDescription(xNode, nsmgr);
            if (!componentDescription.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Probe] Description of Device '{Name}':\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            Description = componentDescription;
            return true;
        }

        /// <inheritdoc/>
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            const string documentationAttributes = "See Part 2 Section 4.2 of the MTConnect standard.";
            validationErrors = new List<MtconnectValidationException>();

            if (string.IsNullOrEmpty(Name))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Device MUST include a 'name' attribute. {documentationAttributes}"));
            }

            if (string.IsNullOrEmpty(Uuid))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Device MUST include a 'uuid' attribute. {documentationAttributes}"));
            }

            return !validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR);
        }
    }
}
