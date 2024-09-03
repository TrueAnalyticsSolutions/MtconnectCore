using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System.Collections.Generic;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    public class EntryDefinition : MtconnectNode
    {
        /// <inheritdoc cref="EntryDefinitionAttributes.KEY"/>
        [MtconnectNodeAttribute(EntryDefinitionAttributes.KEY)]
        public string Key { get; set; }

        /// <inheritdoc cref="EntryDefinitionAttributes.KEY_TYPE"/>
        [MtconnectNodeAttribute(EntryDefinitionAttributes.KEY_TYPE)]
        public string KeyType { get; set; }

        /// <inheritdoc cref="EntryDefinitionAttributes.UNITS"/>
        [MtconnectNodeAttribute(EntryDefinitionAttributes.UNITS)]
        public ParsedValue<UnitEnum?> Units { get; set; }

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
        [MtconnectNodeElements("CellDefinitions/*", nameof(TryAddCellDefinition))]
        public ICollection<CellDefinition> CellDefinitions => _cellDefinitions;

        /// <inheritdoc/>
        public EntryDefinition() : base() { }

        /// <inheritdoc/>
        public EntryDefinition(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        public bool TryAddCellDefinition(XmlNode xNode, XmlNamespaceManager nsmgr, out CellDefinition cellDefinition)
            => base.TryAdd<CellDefinition>(xNode, nsmgr, ref _cellDefinitions, out cellDefinition);


        private bool ValidateProperties(out ICollection<MtconnectValidationException> validationErrors)
        {
            return new NodeValidationContext(this)
                // Validate key
                .ValidateValueProperty(
                    EntryDefinitionAttributes.KEY,
                    (o) =>
                        o.IsImplemented(Key)
                )
                // Validate unit
                .ValidateValueProperty(
                    EntryDefinitionAttributes.UNITS,
                    (o) =>
                        o.IsImplemented(Units)
                        ?.IsEnumValueType(Units, out _)
                )
                // Return validation errors
                .HasError(out validationErrors);
        }
    }
}
