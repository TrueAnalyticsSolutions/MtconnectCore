using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using System.Collections.Generic;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    public class DataItemDefinition : MtconnectNode
    {
        /// <inheritdoc cref="DataItemDefinitionElements.DESCRIPTION"/>
        [MtconnectNodeElement(DataItemDefinitionElements.DESCRIPTION)]
        public string Description { get; set; }

        private List<EntryDefinition> _entryDefinitions = new List<EntryDefinition>();
        /// <inheritdoc cref="DataItemDefinitionElements.ENTRY_DEFINITIONS"/>
        [MtconnectNodeElements("EntryDefinitions/*", nameof(TryAddEntryDefinition))]
        public ICollection<EntryDefinition> EntryDefinitions => _entryDefinitions;

        private List<CellDefinition> _cellDefinitions = new List<CellDefinition>();
        /// <inheritdoc cref="DataItemDefinitionElements.CELL_DEFINITIONS"/>
        [MtconnectNodeElements("CellDefinitions/*", nameof(TryAddCellDefinition))]
        public ICollection<CellDefinition> CellDefinitions => _cellDefinitions;

        /// <inheritdoc/>
        public DataItemDefinition() : base() { }

        /// <inheritdoc/>
        public DataItemDefinition(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        public bool TryAddEntryDefinition(XmlNode xNode, XmlNamespaceManager nsmgr, out EntryDefinition entryDefinition)
            => base.TryAdd<EntryDefinition>(xNode, nsmgr, ref _entryDefinitions, out entryDefinition);

        public bool TryAddCellDefinition(XmlNode xNode, XmlNamespaceManager nsmgr, out CellDefinition cellDefinition)
            => base.TryAdd<CellDefinition>(xNode, nsmgr, ref _cellDefinitions, out cellDefinition);
    }
}
