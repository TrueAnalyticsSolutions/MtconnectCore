using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
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
    public class ItemLife : MtconnectNode
    {
        /// <inheritdoc cref="ItemLifeAttributes.TYPE"/>
        [MtconnectNodeAttribute(ItemLifeAttributes.TYPE)]
        public string Type { get; set; }

        /// <inheritdoc cref="ItemLifeAttributes.COUNT_DIRECTION"/>
        [MtconnectNodeAttribute(ItemLifeAttributes.COUNT_DIRECTION)]
        public string CountDirection { get; set; }

        /// <inheritdoc cref="ItemLifeAttributes.LIMIT"/>
        [MtconnectNodeAttribute(ItemLifeAttributes.LIMIT)]
        public double? Limit { get; set; }

        /// <inheritdoc cref="ItemLifeAttributes.INITIAL"/>
        [MtconnectNodeAttribute(ItemLifeAttributes.INITIAL)]
        public double? Initial { get; set; }

        public double Value { get; set; }
        /// <inheritdoc />
        public ItemLife() : base() { }

        /// <inheritdoc />
        public ItemLife(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE, version)
        {
            if (double.TryParse(xNode.InnerText, out double value))
            {
                Value = value;
            }
        }

        /// <inheritdoc />
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            base.TryValidate(out validationErrors);

            if (string.IsNullOrEmpty(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"CuttingItem ItemLife missing 'type' attribute."));
            }
            else if (!Enum.TryParse<ItemLifeTypes>(Type, out ItemLifeTypes itemLifeTypes))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.WARNING,
                    $"Unrecognized CuttingItem ItemLife 'type'."));
            }

            if (string.IsNullOrEmpty(CountDirection))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"CuttingItem ItemLife missing 'countDirection' attribute."));
            }
            else if (!Enum.TryParse<ItemLifeCountDirectionTypes>(Type, out ItemLifeCountDirectionTypes itemLifeCountDirectionTypes))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.WARNING,
                    $"Unrecognized CuttingItem ItemLife 'countDirection'."));
            }

            if (!double.TryParse(SourceNode.InnerText, out double value))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Invalid ItemLife value. CuttingItem ItemLife value must be a number."));
            }

            return !validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR);
        }
    }
}
