using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <inheritdoc />
    public class DevicesDocument : ResponseDocument<DevicesDocumentHeader, Device>
    {
        /// <inheritdoc />
        public override DocumentTypes Type => DocumentTypes.Devices;

        /// <inheritdoc />
        public override string DefaultNamespace => "mt";

        /// <inheritdoc />
        public override string DataElementName => DevicesElements.DEVICES.ToPascalCase();

        [MtconnectNodeElements(DevicesElements.HEADER, nameof(TrySetHeader), XmlNamespace = "mt")]
        internal override DevicesDocumentHeader _header { get; set; }
        /// <inheritdoc />
        public DevicesDocumentHeader Header => (DevicesDocumentHeader)_header;

        /// <inheritdoc/>
        public DevicesDocument(XmlDocument xDoc) : base(xDoc)
        {
            _header = new DevicesDocumentHeader(xDoc.DocumentElement.FirstChild, NamespaceManager);
        }

        /// <inheritdoc />
        public override bool TryAddItem(XmlNode xNode, XmlNamespaceManager nsmgr, out Device device)
        {
            Logger.Verbose("Reading Device {XnodeKey}", xNode.TryGetAttribute(DeviceAttributes.ID));
            device = new Device(xNode, nsmgr);
            if (!device.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Probe] Device:\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            _items.Add(device);
            return true;
        }
    }
}
