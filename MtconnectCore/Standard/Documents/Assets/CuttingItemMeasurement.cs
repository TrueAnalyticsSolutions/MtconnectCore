using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Enums.Assets;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Assets
{
    /// <inheritdoc />
    public class CuttingItemMeasurement : Measurement
    {
        /// <inheritdoc />
        public CuttingItemMeasurement() : base() { }

        /// <inheritdoc />
        public CuttingItemMeasurement(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr) { }

        /// <inheritdoc />
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();

            if (!SourceNode.IsEnumName<CuttingItemMeasurementSubTypes>())
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Unknown CuttingItemMeasurement SubType '{SourceNode.LocalName}'."));
            }

            return !validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR);
        }
    }
}
