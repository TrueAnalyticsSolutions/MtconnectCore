using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <summary>
    /// <inheritdoc cref="IResponseDocument" path="/summary"/>
    /// </summary>
    public class DevicesDocument : ResponseDocument<DevicesDocumentHeader, Device>
    {
        private const string MODEL_BROWSER_URL = "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1620240839406_285612_1596";

        /// <inheritdoc />
        public override DocumentTypes Type => DocumentTypes.Devices;

        /// <inheritdoc />
        public override string DataElementName => DevicesElements.DEVICES.ToPascalCase();

        [MtconnectNodeElements(DevicesElements.HEADER, nameof(TrySetHeader))]
        internal override DevicesDocumentHeader _header { get; set; }
        /// <inheritdoc />
        public DevicesDocumentHeader Header => (DevicesDocumentHeader)_header;

        /// <inheritdoc/>
        public DevicesDocument(XmlDocument xDoc) : base(xDoc)
        {
            _header = new DevicesDocumentHeader(xDoc.DocumentElement.FirstChild, NamespaceManager, MtconnectVersion.GetValueOrDefault());

        }

        public override bool TryAddItem(XmlNode xNode, XmlNamespaceManager nsmgr, out Device device)
            => base.TryAdd<Device>(xNode, nsmgr, ref _items, out device);

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL)]
        private bool validateDevices(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();

            // Check Multiplicity of hasDevice
            if (Items.Length < 1)
            {
                validationErrors.Add(
                    new MtconnectValidationException(
                        ValidationSeverity.FATAL,
                        $"MTConnectDevices MUST include at least one Device element",
                        SourceDocument.DocumentElement) {
                        HelpLink = "https://model.mtconnect.org/#Structure__EAID_76BFE349_267B_45b3_B5FF_3C89D29AE715",
                        Source = SourceDocument.DocumentElement.LocalName,
                        Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.NOT_FOUND,
                        ScopeType = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.PART,
                        Scope = "xmlns:" + DefaultNamespace
                    });
            }

            // Check "All id and name properties MUST be unique"
            var duplicateIds = new HashSet<string>();
            var duplicateNames = new HashSet<string>();
            var duplicateUuids = new HashSet<string>();
            foreach (var device in Items)
            {
                if (Items.Count(o => o.Id == device.Id) > 1)
                    duplicateIds.Add(device.Id);
                if (Items.Count(o => o.Name == device.Name) > 1)
                    duplicateNames.Add(device.Name);
                if (Items.Count(o => o.Uuid == device.Uuid) > 1)
                    duplicateUuids.Add(device.Uuid);
            }

            foreach (string duplicateId in duplicateIds)
            {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, "Duplicate Device 'id' found: " + duplicateId + ". Each Device 'id' MUST be unique.", SourceNode) {
                    Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.DUPLICATE_ENTRY,
                    ScopeType = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY,
                    Scope = "id"
                });
            }
            foreach (string duplicateName in duplicateNames)
            {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, "Duplicate Device 'name' found: " + duplicateName + ". Each Device 'name' MUST be unique.", SourceNode) {
                    Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.DUPLICATE_ENTRY,
                    ScopeType = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY,
                    Scope = "name"
                });
            }
            foreach (string duplicateUuid in duplicateUuids)
            {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, "Duplicate Device 'uuid' found: " + duplicateUuid + ". Each Device 'uuid' MUST be unique.", SourceNode) {
                    Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.DUPLICATE_ENTRY,
                    ScopeType = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY,
                    Scope = "uuid"
                });
            }

            return !validationErrors.Any(o => o.Severity >= ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL)]
        private bool validateComponents(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();

            // Check "All id and name properties MUST be unique"
            var duplicateIds = new HashSet<string>();
            var duplicateNames = new HashSet<string>();
            var duplicateUuids = new HashSet<string>();

            var items = DataItemNavigator.GetAllComponents(this);
            foreach (var item in items)
            {
                if (Items.Count(o => o.Id == item.Id) > 1)
                    duplicateIds.Add(item.Id);
                if (Items.Count(o => o.Name == item.Name) > 1)
                    duplicateNames.Add(item.Name);
                if (Items.Count(o => o.Uuid == item.Uuid) > 1)
                    duplicateUuids.Add(item.Uuid);
            }
            foreach (string duplicateId in duplicateIds)
            {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, "Duplicate Component 'id' found: " + duplicateId + ". Each Component 'id' MUST be unique.", SourceNode) {
                    Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.DUPLICATE_ENTRY,
                    ScopeType = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY,
                    Scope = "id"
                });
            }
            foreach (string duplicateName in duplicateNames)
            {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, "Duplicate Component 'name' found: " + duplicateName + ". Each Component 'name' MUST be unique.", SourceNode) {
                    Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.DUPLICATE_ENTRY,
                    ScopeType = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY,
                    Scope = "name"
                });
            }
            foreach (string duplicateUuid in duplicateUuids)
            {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, "Duplicate Component 'uuid' found: " + duplicateUuid + ". Each Component 'uuid' MUST be unique.", SourceNode) {
                    Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.DUPLICATE_ENTRY,
                    ScopeType = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY,
                    Scope = "uuid"
                });
            }
            return !validationErrors.Any(o => o.Severity >= ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL)]
        private bool validateDataItems(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();

            // Check "All id and name properties MUST be unique"
            var duplicateIds = new HashSet<string>();
            var duplicateNames = new HashSet<string>();
            var namespaces = new HashSet<string>();

            var items = DataItemNavigator.GetAll(this);
            foreach (var item in items)
            {
                // Check uniqueness of Id
                if (Items.Count(o => o.Id == item.Id) > 1)
                    duplicateIds.Add(item.Id);

                // Check uniqueness of Name
                if (Items.Count(o => o.Name == item.Name) > 1)
                    duplicateNames.Add(item.Name);

                // Check if type is extended
                if (!string.IsNullOrEmpty(item.Type) && item.Type.Contains(":"))
                {
                    string typeExtension = item.Type.Substring(0, item.Type.IndexOf(":"));
                    namespaces.Add(typeExtension);
                }

                // Check if subType is extended
                if (!string.IsNullOrEmpty(item.SubType) && item.SubType.Contains(":"))
                {
                    string subTypeExtension = item.SubType.Substring(0, item.SubType.IndexOf(":"));
                    namespaces.Add(subTypeExtension);
                }

                // Check if units is extended
                if (!string.IsNullOrEmpty(item.Units?.RawValue) && item.Units.RawValue.Contains(":"))
                {
                    string unitsExtension = item.Units.RawValue.Substring(0, item.Units.RawValue.IndexOf(":"));
                    namespaces.Add(unitsExtension);
                }

                // Check if nativeUnits is extended
                if (!string.IsNullOrEmpty(item.NativeUnits?.RawValue) && item.NativeUnits.RawValue.Contains(":"))
                {
                    string nativeUnitsExtension = item.NativeUnits.RawValue.Substring(0, item.NativeUnits.RawValue.IndexOf(":"));
                    namespaces.Add(nativeUnitsExtension);
                }
            }
            foreach (string duplicateId in duplicateIds)
            {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, "Duplicate DataItem 'id' found: " + duplicateId + ". Each DataItem 'id' MUST be unique.", SourceNode) {
                    Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.DUPLICATE_ENTRY,
                    ScopeType = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY,
                    Scope = "id"
                });
            }
            foreach (string duplicateName in duplicateNames)
            {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, "Duplicate DataItem 'name' found: " + duplicateName + ". Each DataItem 'name' MUST be unique.", SourceNode) {
                    Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.DUPLICATE_ENTRY,
                    ScopeType = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY,
                    Scope = "name"
                });
            }

            return !validationErrors.Any(o => o.Severity >= ValidationSeverity.ERROR);
        }

        // TODO: Validate DataItemRef idRef links exist
    }
}
