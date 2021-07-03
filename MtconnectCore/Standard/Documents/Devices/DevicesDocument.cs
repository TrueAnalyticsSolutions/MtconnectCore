using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Devices
{
    public class DevicesDocument : MtconnectDocument<DevicesDocumentHeader, Device>
    {
        public override DocumentTypes Type => DocumentTypes.Devices;

        public override string DefaultNamespace => "mt";

        public override string DataElementName => DevicesElements.DEVICES.ToPascalCase();

        [MtconnectNodeElements(DevicesElements.HEADER, nameof(TrySetHeader), XmlNamespace = "mt")]
        internal override DevicesDocumentHeader _header { get; set; }
        public DevicesDocumentHeader Header => (DevicesDocumentHeader)_header;

        public DevicesDocument(XmlDocument xDoc) : base(xDoc)
        {
            _header = new DevicesDocumentHeader(xDoc.DocumentElement.FirstChild, NamespaceManager);
        }

        public override bool TryAddItem(XmlNode xNode, XmlNamespaceManager nsmgr, out Device device)
        {
            Logger.Verbose("Reading Device {XnodeKey}", xNode.TryGetAttribute(DeviceAttributes.ID));
            device = new Device(xNode, nsmgr);
            if (!device.IsValid())
            {
                Logger.Warn($"[Invalid Probe] Device is not formatted properly, refer to Part 2 Section 2.2.1 of MTConnect Standard.");
                return false;
            }
            _items.Add(device);
            return true;
        }
    }
}
