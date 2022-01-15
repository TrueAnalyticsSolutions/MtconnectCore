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
        public Location(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE, version)
        {
            Value = xNode.InnerText;
        }

        /// <inheritdoc />
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            base.TryValidate(out validationErrors);

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

            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
