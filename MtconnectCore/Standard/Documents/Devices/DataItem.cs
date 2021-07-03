using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Devices
{
    public class DataItem : MtconnectNode
    {
        [MtconnectNodeAttribute(DataItemAttributes.ID)]
        public string Id { get; set; }

        [MtconnectNodeAttribute(DataItemAttributes.NAME)]
        public string Name { get; set; }

        [MtconnectNodeAttribute(DataItemAttributes.TYPE)]
        public string Type { get; set; }

        [MtconnectNodeAttribute(DataItemAttributes.CATEGORY)]
        public string Category { get; set; }

        [MtconnectNodeAttribute(DataItemAttributes.UNITS)]
        public string Units { get; set; }

        [MtconnectNodeAttribute(DataItemAttributes.SUB_TYPE)]
        public string SubType { get; set; }

        [MtconnectNodeAttribute(DataItemAttributes.NATIVE_UNITS)]
        public string NativeUnits { get; set; }

        [MtconnectNodeAttribute(DataItemAttributes.NATIVE_SCALE)]
        public string NativeScale { get; set; }

        [MtconnectNodeAttribute(DataItemAttributes.STATISTIC)]
        public string Statistic { get; set; }

        [MtconnectNodeAttribute(DataItemAttributes.REPRESENTATION)]
        public string Representation { get; set; }

        [MtconnectNodeAttribute(DataItemAttributes.SIGNIFICANT_DIGITS)]
        public string SignificantDigits { get; set; }

        [MtconnectNodeAttribute(DataItemAttributes.COORDINATE_SYSTEM)]
        public string CoordinateSystem { get; set; }

        [MtconnectNodeAttribute(DataItemAttributes.SAMPLE_RATE)]
        public string SampleRate { get; set; }

        [MtconnectNodeElements(DevicesElements.SOURCE, nameof(TrySetSource), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public Source Source { get; set; }

        public DataItem() : base() { }

        public DataItem(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE) { }

        public bool TrySetSource(XmlNode xNode, XmlNamespaceManager nsmgr, out Source source)
        {
            Logger.Verbose($"Reading Source");
            source = new Source(xNode, nsmgr);
            if (!source.IsValid())
            {
                Logger.Warn($"[Invalid Probe] Source not formatted properly, refer to Part 2 Section 6.2.3.1 of MTConnect Standard.");
                return false;
            }
            Source = source;
            return true;
        }

        public override bool IsValid() => Id != null && Type != null && Category != null; // See Part 2 Section 6.2.1 of MTConnect Standard
    }
}
