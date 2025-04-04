using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Assets;
using MtconnectCore.Standard.Contracts.Enums.Assets.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
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

        /// <inheritdoc cref="ToolLifeAttributes.WARNING"/>
        [MtconnectNodeAttribute(ToolLifeAttributes.WARNING)]
        public double? Warning { get; set; }

        /// <inheritdoc cref="ToolLifeAttributes.INITIAL"/>
        [MtconnectNodeAttribute(ToolLifeAttributes.INITIAL)]
        public double? Initial { get; set; }

        public double Value { get; set; }

        /// <inheritdoc />
        public ToolLife() : base() { }

        /// <inheritdoc />
        public ToolLife(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version)
        {
            if (double.TryParse(xNode.InnerText, out double value)) {
                Value = value;
            }
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.15.1")]
        public bool ValidateToolLife(out ICollection<MtconnectValidationException> validationErrors)
        {
            return new NodeValidationContext(this)
                //.ValidateProperty(nameof(Type), Type)
                //    .IsNotNullOrEmpty()
                //    .IsEnum<ToolLifeTypes>("Invalid ToolLife 'type'.")
                //.ValidateProperty(nameof(CountDirection), CountDirection)
                //    .IsNotNullOrEmpty()
                //    .IsEnum<ToolLifeCountDirectionTypes>("Invalid ToolLife 'countDirection'.")
                //.ValidateValueProperty(nameof(Value), o =>
                //    o.AddCondition(
                //        !double.TryParse(SourceNode.InnerText, out _),
                //        $"Invalid ToolLife value. CuttingTool ToolLife value must be a number.",
                //        ValidationSeverity.ERROR
                //    )
                //)
                .HasError(out validationErrors);
        }

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.15.1")]
        //private bool validateType(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (string.IsNullOrEmpty(Type))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"CuttingTool ToolLife missing 'type' attribute."));
        //    }
        //    else if (!Enum.TryParse<ToolLifeTypes>(Type, out ToolLifeTypes toolLifeTypes))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.WARNING,
        //            $"Unrecognized CuttingTool ToolLife 'type'."));
        //    }
        //    return !validationErrors.Any(o => o.Severity ?= ValidationSeverity.ERROR);
        //}

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.15.1")]
        //private bool validateCountDirection(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (string.IsNullOrEmpty(CountDirection))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"CuttingTool ToolLife missing 'countDirection' attribute."));
        //    }
        //    else if (!Enum.TryParse<ToolLifeCountDirectionTypes>(Type, out ToolLifeCountDirectionTypes toolLifeCountDirectionTypes))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.WARNING,
        //            $"Unrecognized CuttingTool ToolLife 'countDirection'."));
        //    }
        //    return !validationErrors.Any(o => o.Severity >= ValidationSeverity.ERROR);
        //}

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.15.1")]
        //private bool validateValue(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (!double.TryParse(SourceNode.InnerText, out double value))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Invalid ToolLife value. CuttingTool ToolLife value must be a number."));
        //    }
        //    return !validationErrors.Any(o => o.Severity >= ValidationSeverity.ERROR);
        //}
    }
}
