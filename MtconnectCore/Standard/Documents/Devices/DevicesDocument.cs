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
    /// <inheritdoc cref="IResponseDocument" path="/summary"/>
    /// </summary>
    public class DevicesDocument : ResponseDocument<DevicesDocumentHeader, Device>
    {
        /// <inheritdoc />
        public override DocumentTypes Type => DocumentTypes.Devices;

        /// <inheritdoc />
        public override string DefaultNamespace => Constants.DEFAULT_DEVICES_XML_NAMESPACE;

        /// <inheritdoc />
        public override string DataElementName => DevicesElements.DEVICES.ToPascalCase();

        [MtconnectNodeElements(DevicesElements.HEADER, nameof(TrySetHeader), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
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

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.7")]
        private bool validateUniqueDeviceIds(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            var duplicateIds = new HashSet<string>();
            foreach (var device in Items)
            {
                if (Items.Count(o => o.Id == device.Id) > 1) {
                    duplicateIds.Add(device.Id);
                }
            }
            foreach (string duplicateId in duplicateIds)
            {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, "Duplicate Device id found: " + duplicateId + ". Each Device id MUST be unique."));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
