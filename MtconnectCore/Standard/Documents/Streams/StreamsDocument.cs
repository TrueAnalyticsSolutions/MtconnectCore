using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using System.Linq;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Streams
{
    public partial class StreamsDocument : MtconnectDocument<StreamsDocumentHeader, Device>
    {
        public override DocumentTypes Type => DocumentTypes.Streams;

        public override string DefaultNamespace => Constants.DEFAULT_XML_NAMESPACE;

        public override string DataElementName => StreamsElements.STREAMS.ToPascalCase();

        [MtconnectNodeElements(StreamsElements.HEADER, nameof(TrySetHeader), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        internal override StreamsDocumentHeader _header { get; set; }
        public StreamsDocumentHeader Header => (StreamsDocumentHeader)_header;

        public StreamsDocument(XmlDocument xDoc) : base(xDoc)
        {
            _header = new StreamsDocumentHeader(xDoc.DocumentElement.FirstChild, NamespaceManager);
        }

        public int GetDataItemCount() => Items.SelectMany(o => o.Components).Select(o => o.Samples.Count + o.Events.Count + o.Conditions.Count).Sum();

        public override bool TryAddItem(XmlNode xNode, XmlNamespaceManager nsmgr, out Device device)
        {
            Logger.Verbose("Reading Device {XnodeKey}", xNode.TryGetAttribute(DeviceAttributes.NAME));
            device = new Device(xNode, nsmgr);
            if (!device.IsValid())
            {
                Logger.Warn($"[Invalid Stream] Device is not formatted properly, refer to Part 3 Section 4.2.2 of MTConnect Standard.");
                return false;
            }
            _items.Add(device);
            return true;
        }
    }
}
