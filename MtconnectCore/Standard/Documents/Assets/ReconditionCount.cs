using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Assets.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Assets
{
    /// <inheritdoc />
    public class ReconditionCount : MtconnectNode
    {
        /// <inheritdoc cref="ReconditionCountAttributes.MAXIMUM_COUNT"/>
        [MtconnectNodeAttribute(ReconditionCountAttributes.MAXIMUM_COUNT)]
        public double? MaximumCount { get; set; }

        public int Value { get; set; }

        /// <inheritdoc />
        public ReconditionCount() : base() { }

        /// <inheritdoc />
        public ReconditionCount(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version)
        {
            if (int.TryParse(xNode.InnerText, out int value))
            {
                Value = value;
            }
        }

        public override bool TryValidate(ValidationReport report)
        {
            using (var validationContext = report.CreateContext(this))
            {
                var baseResult = base.TryValidate(report);

                if (!int.TryParse(SourceNode.InnerText, out int value))
                {
                    validationContext.AddExceptions(new MtconnectValidationException(
                        ValidationSeverity.ERROR,
                        $"Invalid ReconditionCount value. CuttingTool ReconditionCount value must be a number.",
                        SourceNode) {
                        Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.INVALID_FORMAT,
                        SourceContext = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY,
                        SourceContextScope = nameof(Value)
                    });
                }

                return baseResult && !validationContext.HasErrors();
            }
        }
    }
}
