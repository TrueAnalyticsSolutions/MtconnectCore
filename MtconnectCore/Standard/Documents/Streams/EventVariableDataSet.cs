using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class EventVariableDataSet : Event
    {
        /// <summary>
        /// Collected from the count attribute. Refer to Part 3 Streams - 5.6.3.1
        /// 
        /// Occurance: 1
        /// </summary>
        [MtconnectNodeAttribute(VariableDataSetAttributes.COUNT)]
        public int? Count { get; set; }

        /// <summary>
        /// Collected from Sample elements. Refer to Part 3 Streams - 4.3.3
        /// </summary>
        private List<VariableDataSetEntry> _entries = new List<VariableDataSetEntry>();
        [MtconnectNodeElements(VariableDataSetElements.ENTRY, nameof(TryAddEntry), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public ICollection<VariableDataSetEntry> Entries => _entries;

        /// <inheritdoc/>
        public EventVariableDataSet() : base() { }

        /// <inheritdoc/>
        public EventVariableDataSet(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        public bool TryAddEntry(XmlNode xNode, XmlNamespaceManager nsmgr, out VariableDataSetEntry entry) => base.TryAdd<VariableDataSetEntry>(xNode, nsmgr, ref _entries, out entry);

        protected override bool validateNode(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            return true;
        }
    }
}
