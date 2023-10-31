using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using System.Collections.Generic;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class SampleTable : Sample, ITable
    {
        /// <summary>
        /// Description of a means to interpret data consisting of multiple data points or samples reported as a single value.
        /// </summary>
        [MtconnectNodeAttribute(DataItemAttributes.REPRESENTATION)]
        public override string Representation { get; set; } = RepresentationTypes.TABLE.ToString();


        /// <summary>
        /// Collected from the count attribute. Refer to Part 3 Streams - 5.6.3.1
        /// 
        /// Occurance: 1
        /// </summary>
        [MtconnectNodeAttribute(TableAttributes.COUNT)]
        public int? Count { get; set; }

        private List<TableEntry> _entries = new List<TableEntry>();
        /// <summary>
        /// Collected from the textcontent of the Event element. Refer to Part 3 Streams - 5.5.3
        /// </summary>
        [MtconnectNodeElements(TableElements.ENTRY, nameof(TryAddEntry), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public new ICollection<TableEntry> Result => _entries;

        public bool TryAddEntry(XmlNode xNode, XmlNamespaceManager nsmgr, out TableEntry entry) => base.TryAdd<TableEntry>(xNode, nsmgr, ref _entries, out entry);
    }
}
