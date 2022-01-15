using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Devices
{
    public class EntryDefinition : MtconnectNode
    {
        /// <inheritdoc cref="EntryDefinitionAttributes.KEY"/>
        [MtconnectNodeAttribute(EntryDefinitionAttributes.KEY)]
        public string Key { get; set; }

        /// <inheritdoc cref="EntryDefinitionAttributes.UNITS"/>
        [MtconnectNodeAttribute(EntryDefinitionAttributes.UNITS)]
        public string Units { get; set; }

        /// <inheritdoc cref="EntryDefinitionAttributes.TYPE"/>
        [MtconnectNodeAttribute(EntryDefinitionAttributes.TYPE)]
        public string Type { get; set; }

        /// <inheritdoc cref="EntryDefinitionAttributes.SUB_TYPE"/>
        [MtconnectNodeAttribute(EntryDefinitionAttributes.SUB_TYPE)]
        public string SubType { get; set; }

        [MtconnectNodeElement(EntryDefinitionElements.DESCRIPTION)]
        public string Description { get; set; }

        private List<CellDefinition> _cellDefinitions = new List<CellDefinition>();
        /// <inheritdoc cref="EntryDefinitionElements.CELL_DEFINITIONS"/>
        [MtconnectNodeElements("CellDefinitions/*", nameof(TryAddCellDefinition), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ICollection<CellDefinition> CellDefinitions => _cellDefinitions;

        /// <inheritdoc/>
        public EntryDefinition() : base() { }

        /// <inheritdoc/>
        public EntryDefinition(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE, version) { }

        public bool TryAddCellDefinition(XmlNode xNode, XmlNamespaceManager nsmgr, out CellDefinition cellDefinition)
            => base.TryAdd<CellDefinition>(xNode, nsmgr, ref _cellDefinitions, out cellDefinition);


        private bool validateId(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Key))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"EntryDefinition MUST include a 'key' attribute."));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
