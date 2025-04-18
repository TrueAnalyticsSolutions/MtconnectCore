﻿using MtconnectCore.Standard.Contracts;
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
        public Location(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version)
        {
            Value = xNode.InnerText;
        }

        /// <inheritdoc />
        public override bool TryValidate(ValidationReport report)
        {
            using (var validationContext = report.CreateContext(this))
            {
                var baseResult = base.TryValidate(report);

                if (string.IsNullOrEmpty(Type))
                {
                    validationContext.AddExceptions(new MtconnectValidationException(
                        Contracts.Enums.ValidationSeverity.ERROR,
                        $"CuttingTool Location missing 'type' attribute.",
                        SourceNode) {
                        Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.NOT_FOUND,
                        ScopeType = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY,
                        Scope = nameof(Type)
                    });
                }
                else if (!Enum.TryParse<LocationTypes>(Type, out LocationTypes locationType))
                {
                    validationContext.AddExceptions(new MtconnectValidationException(
                        Contracts.Enums.ValidationSeverity.WARNING,
                        $"Unrecognized CuttingTool Location 'type'.",
                        SourceNode) {
                        Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.EXTENDED,
                        ScopeType = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY,
                        Scope = nameof(Type)
                    });
                }

                return baseResult && !validationContext.HasErrors();
            }
        }
    }
}
