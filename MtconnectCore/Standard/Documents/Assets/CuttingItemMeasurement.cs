using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Assets;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
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
        public override bool TryValidate(ValidationReport report)
        {
            using (var validationContext = report.CreateContext(this))
            {
                var baseResult = base.TryValidate(report);

                if (!EnumHelper.Contains<CuttingItemMeasurementSubTypes>(SourceNode.LocalName))
                {
                    validationContext.AddExceptions(new MtconnectValidationException(
                        ValidationSeverity.ERROR,
                        $"Unknown CuttingItemMeasurement SubType '{SourceNode.LocalName}'.",
                        SourceNode) {
                        Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.NOT_FOUND,
                        SourceContext = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY,
                        SourceContextScope = SourceNode.LocalName
                    });
                }

                return baseResult && !validationContext.HasErrors();
            }
        }
    }
}
