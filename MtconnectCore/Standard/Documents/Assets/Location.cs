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
    public class Location : MtconnectNode
    {
        /// <inheritdoc cref="LocationAttributes.TYPE"/>
        [MtconnectNodeAttribute(LocationAttributes.TYPE)]
        public string Type { get; set; }

        /// <inheritdoc cref="LocationAttributes.POSITIVE_OVERLAP"/>
        [MtconnectNodeAttribute(LocationAttributes.POSITIVE_OVERLAP)]
        public int? PositiveOverlap { get; set; }

        /// <inheritdoc cref="LocationAttributes.NEGATIVE_OVERLAP"/>
        [MtconnectNodeAttribute(LocationAttributes.NEGATIVE_OVERLAP)]
        public int? NegativeOverlap { get; set; }

        public string Value { get; set; }

        /// <inheritdoc />
        public Location() : base() { }

        /// <inheritdoc />
        public Location(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE)
        {
            Value = xNode.InnerText;
        }

        /// <inheritdoc />
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();

            if (string.IsNullOrEmpty(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"CuttingTool Location missing 'type' attribute."));
            } else if (!Enum.TryParse<LocationTypes>(Type, out LocationTypes locationType))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Unrecognized CuttingTool Location 'type'."));
            }

            if (validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR)) {
                return false;
            }

            return true;
        }
    }
}
