using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Assets;
using MtconnectCore.Standard.Contracts.Enums.Assets.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Assets
{
    /// <inheritdoc />
    public class ToolLife : MtconnectNode
    {
        /// <inheritdoc cref="ToolLifeAttributes.TYPE"/>
        [MtconnectNodeAttribute(ToolLifeAttributes.TYPE)]
        public string Type { get; set; }

        /// <inheritdoc cref="ToolLifeAttributes.COUNT_DIRECTION"/>
        [MtconnectNodeAttribute(ToolLifeAttributes.COUNT_DIRECTION)]
        public string CountDirection { get; set; }

        /// <inheritdoc cref="ToolLifeAttributes.LIMIT"/>
        [MtconnectNodeAttribute(ToolLifeAttributes.LIMIT)]
        public double? Limit { get; set; }

        /// <inheritdoc cref="ToolLifeAttributes.INITIAL"/>
        [MtconnectNodeAttribute(ToolLifeAttributes.INITIAL)]
        public double? Initial { get; set; }

        public double Value { get; set; }

        /// <inheritdoc />
        public ToolLife() : base() { }

        /// <inheritdoc />
        public ToolLife(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE)
        {
            if (double.TryParse(xNode.InnerText, out double value)) {
                Value = value;
            }
        }

        /// <inheritdoc />
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();

            if (string.IsNullOrEmpty(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"CuttingTool ToolLife missing 'type' attribute."));
            }
            else if (!Enum.TryParse<ToolLifeTypes>(Type, out ToolLifeTypes toolLifeTypes))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.WARNING,
                    $"Unrecognized CuttingTool ToolLife 'type'."));
            }

            if (string.IsNullOrEmpty(CountDirection))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"CuttingTool ToolLife missing 'countDirection' attribute."));
            }
            else if (!Enum.TryParse<ToolLifeCountDirectionTypes>(Type, out ToolLifeCountDirectionTypes toolLifeCountDirectionTypes))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.WARNING,
                    $"Unrecognized CuttingTool ToolLife 'countDirection'."));
            }

            if (!double.TryParse(SourceNode.InnerText, out double value))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Invalid ToolLife value. CuttingTool ToolLife value must be a number."));
            }

            return !validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR);
        }
    }
}
