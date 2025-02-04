using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
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
    public class CuttingToolMeasurement : Measurement
    {
        /// <inheritdoc />
        public CuttingToolMeasurement() : base() { }

        /// <inheritdoc />
        public CuttingToolMeasurement(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.20")]
        public bool ValidateSubTypes(out ICollection<MtconnectValidationException> validationErrors)
        {
            return new NodeValidationContext(this)
                //.ValidateValueProperty<CuttingToolMeasurementSubTypes>(nameof(SourceNode.LocalName), o =>
                //    o.IsEnumDefined(SourceNode.LocalName)
                //    ?.AddValidationMessage(
                //        ValidationSeverity.ERROR,
                //        $"Unknown CuttingToolMeasurement SubType '{SourceNode.LocalName}'."
                //    )
                //)
                .HasError(out validationErrors);
        }

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.20")]
        //public bool validateSubTypes(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();

        //    if (!EnumHelper.Contains<CuttingToolMeasurementSubTypes>(SourceNode.LocalName))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Unknown CuttingToolMeasurement SubType '{SourceNode.LocalName}'."));
        //    }

        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}
    }
}
