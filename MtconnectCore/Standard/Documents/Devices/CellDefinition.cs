using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    public class CellDefinition : MtconnectNode
    {
        /// <inheritdoc cref="CellDefinitionAttributes.KEY"/>
        [MtconnectNodeAttribute(CellDefinitionAttributes.KEY)]
        public string Key { get; set; }

        /// <inheritdoc cref="CellDefinitionAttributes.UNITS"/>
        [MtconnectNodeAttribute(CellDefinitionAttributes.UNITS)]
        public string Units { get; set; }

        /// <inheritdoc cref="CellDefinitionAttributes.TYPE"/>
        [MtconnectNodeAttribute(CellDefinitionAttributes.TYPE)]
        public string Type { get; set; }

        /// <inheritdoc cref="CellDefinitionAttributes.SUB_TYPE"/>
        [MtconnectNodeAttribute(CellDefinitionAttributes.SUB_TYPE)]
        public string SubType { get; set; }

        [MtconnectNodeElement(CellDefinitionElements.DESCRIPTION)]
        public string Description { get; set; }

        /// <inheritdoc/>
        public CellDefinition() : base() { }

        /// <inheritdoc/>
        public CellDefinition(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE, version) { }

        /// <inheritdoc/>
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            base.TryValidate(out validationErrors);
            const string documentationAttributes = "See Part 2 Section 7.2.3.6.3 of the MTConnect standard.";

            if (string.IsNullOrEmpty(Key))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"CellDefinition MUST include a 'key' attribute. {documentationAttributes}"));
            }

            return !validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR);
        }
    }
}
