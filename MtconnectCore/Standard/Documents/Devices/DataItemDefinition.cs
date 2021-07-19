using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Devices
{
    public class DataItemDefinition : MtconnectNode
    {
        /// <inheritdoc cref="DataItemDefinitionElements.DESCRIPTION"/>
        [MtconnectNodeElement(DataItemDefinitionElements.DESCRIPTION)]
        public string Description { get; set; }

        private List<EntryDefinition> _entryDefinitions = new List<EntryDefinition>();
        /// <inheritdoc cref="DataItemDefinitionElements.ENTRY_DEFINITIONS"/>
        [MtconnectNodeElements("EntryDefinitions/*", nameof(TryAddEntryDefinition), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ICollection<EntryDefinition> EntryDefinitions => _entryDefinitions;

        private List<CellDefinition> _cellDefinitions = new List<CellDefinition>();
        /// <inheritdoc cref="DataItemDefinitionElements.CELL_DEFINITIONS"/>
        [MtconnectNodeElements("CellDefinitions/*", nameof(TryAddCellDefinition), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ICollection<CellDefinition> CellDefinitions => _cellDefinitions;

        /// <inheritdoc/>
        public DataItemDefinition() : base() { }

        /// <inheritdoc/>
        public DataItemDefinition(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE) { }

        public bool TryAddEntryDefinition(XmlNode xNode, XmlNamespaceManager nsmgr, out EntryDefinition entryDefinition)
        {
            Logger.Verbose("Reading CellDefinition {XnodeKey}", xNode.TryGetAttribute(CellDefinitionAttributes.KEY));
            entryDefinition = new EntryDefinition(xNode, nsmgr);
            if (!entryDefinition.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Probe] EntryDefinition of DataItemDefinition:\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            _entryDefinitions.Add(entryDefinition);
            return true;
        }

        public bool TryAddCellDefinition(XmlNode xNode, XmlNamespaceManager nsmgr, out CellDefinition cellDefinition)
        {
            Logger.Verbose("Reading CellDefinition {XnodeKey}", xNode.TryGetAttribute(CellDefinitionAttributes.KEY));
            cellDefinition = new CellDefinition(xNode, nsmgr);
            if (!cellDefinition.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Probe] CellDefinition of DataItemDefinition:\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            _cellDefinitions.Add(cellDefinition);
            return true;
        }
    }
}
