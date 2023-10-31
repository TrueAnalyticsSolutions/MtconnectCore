using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using System.Collections.Generic;
using System.Xml;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class EventDataSet : Event, IDataSet
    {
        /// <summary>
        /// Description of a means to interpret data consisting of multiple data points or samples reported as a single value.
        /// </summary>
        [MtconnectNodeAttribute(DataItemAttributes.REPRESENTATION)]
        public override string Representation { get; set; } = RepresentationTypes.DATA_SET.ToString();


        /// <summary>
        /// Collected from the count attribute. Refer to Part 3 Streams - 5.6.3.1
        /// 
        /// Occurance: 1
        /// </summary>
        [MtconnectNodeAttribute(DataSetAttributes.COUNT)]
        public int? Count { get; set; }

        private List<Entry> _entries = new List<Entry>();
        /// <summary>
        /// Collected from the textcontent of the Event element. Refer to Part 3 Streams - 5.5.3
        /// </summary>
        [MtconnectNodeElements(DataSetElements.ENTRY, nameof(TryAddEntry), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public new ICollection<Entry> Result => _entries;

        /// <inheritdoc/>
        public EventDataSet() : base() { }

        /// <inheritdoc/>
        public EventDataSet(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        public bool TryAddEntry(XmlNode xNode, XmlNamespaceManager nsmgr, out Entry entry) => base.TryAdd<Entry>(xNode, nsmgr, ref _entries, out entry);
    }
}
