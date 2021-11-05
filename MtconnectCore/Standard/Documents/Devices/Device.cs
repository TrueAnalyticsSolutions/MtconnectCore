﻿using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices;
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
        public Device(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE, version) { }

        public bool TryAddComponent(XmlNode xNode, XmlNamespaceManager nsmgr, out Component component)
            => base.TryAdd<Component>(xNode, nsmgr, ref _components, out component);

        public bool TryAddDataItem(XmlNode xNode, XmlNamespaceManager nsmgr, out DataItem dataItem)
            => base.TryAdd<DataItem>(xNode, nsmgr, ref _dataItems, out dataItem);

        public bool TrySetDescription(XmlNode xNode, XmlNamespaceManager nsmgr, out ComponentDescription componentDescription)
            => base.TrySet<ComponentDescription>(xNode, nsmgr, nameof(Description), out componentDescription);

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 3.4.1")]
        private bool validateId(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(Id)) {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, $"Device MUST include a 'id' attribute."));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 3.4.1")]
        private bool validateName(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Name))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Device MUST include a 'name' attribute."));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.2")]
        private bool validateUuid(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Uuid))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Device MUST include a 'uuid' attribute."));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 3.4.1", MtconnectVersions.V_1_0_1)]
        private bool validateIso841Class_Required(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Iso841Class))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Device MUST include a 'iso841Class' attribute."));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 3.4.1")]
        private bool validateIso841Class(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(Iso841Class))
            {
                if (!EnumHelper.Contains<Iso841ClassTypes>(Iso841Class))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"DataItem 'iso841Class' attribute must be one of the following: [{EnumHelper.ToListString<Iso841ClassTypes>(", ", string.Empty, string.Empty)}]."));

                }
                else if (!EnumHelper.ValidateToVersion<Iso841ClassTypes>(Iso841Class, MtconnectVersion.GetValueOrDefault()))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"DataItem iso841Class of '{Iso841Class}' is not supported in version '{MtconnectVersion}' of the MTConnect Standard."));
                }
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
