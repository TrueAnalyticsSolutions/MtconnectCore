using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Enums;
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
        public CuttingItemMeasurement(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        /// <inheritdoc />
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            base.TryValidate(out validationErrors);

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
