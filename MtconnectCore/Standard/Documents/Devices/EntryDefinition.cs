using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
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
        public EntryDefinition(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE) { }

        public bool TryAddCellDefinition(XmlNode xNode, XmlNamespaceManager nsmgr, out CellDefinition cellDefinition)
        {
            Logger.Verbose("Reading CellDefinition {XnodeKey}", xNode.TryGetAttribute(CellDefinitionAttributes.KEY));
            cellDefinition = new CellDefinition(xNode, nsmgr);
            if (!cellDefinition.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Probe] CellDefinition of EntryDefinition '{Key}':\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            _cellDefinitions.Add(cellDefinition);
            return true;
        }

        /// <inheritdoc/>
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            const string documentationAttributes = "See Part 2 Section 7.2.3.6.2 of the MTConnect standard.";
            validationErrors = new List<MtconnectValidationException>();

            if (string.IsNullOrEmpty(Key))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"EntryDefinition MUST include a 'key' attribute. {documentationAttributes}"));
            }

            return !validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR);
        }
    }
}
