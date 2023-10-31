using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using System.Collections.Generic;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class TableEntry : MtconnectNode
    {
        /// <summary>
        /// Collected from the key attribute. Refer to Part 3 Streams - 5.6.5.3.3
        /// 
        /// Occurance: 1
        /// </summary>
        [MtconnectNodeAttribute(TableEntryAttributes.KEY)]
        public string Key { get; set; }

        /// <summary>
        /// Collected from the removed attribute. Refer to Part 3 Streams - 5.6.5.3.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(TableEntryAttributes.REMOVED)]
        public bool Removed { get; set; }

        private List<Cell> _cells = new List<Cell>();
        [MtconnectNodeElements(TableEntryElements.CELL, nameof(TryAddCell), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public ICollection<Cell> Cells => _cells;


        /// <inheritdoc/>
        public TableEntry() : base() { }

        /// <inheritdoc/>
        public TableEntry(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE, version) { }

        public bool TryAddCell(XmlNode xNode, XmlNamespaceManager nsmgr, out Cell entry) => base.TryAdd<Cell>(xNode, nsmgr, ref _cells, out entry);
    }
}
