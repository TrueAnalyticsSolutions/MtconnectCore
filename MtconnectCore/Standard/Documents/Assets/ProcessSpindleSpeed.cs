using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Assets.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Assets
{
    /// <inheritdoc />
    public class ProcessSpindleSpeed : MtconnectNode
    {
        /// <inheritdoc cref="ProcessSpindleSpeedAttributes.MAXIMUM"/>
        [MtconnectNodeAttribute(ProcessSpindleSpeedAttributes.MAXIMUM)]
        public double? Maximum { get; set; }

        /// <inheritdoc cref="ProcessSpindleSpeedAttributes.MINIMUM"/>
        [MtconnectNodeAttribute(ProcessSpindleSpeedAttributes.MINIMUM)]
        public double? Minimum { get; set; }

        /// <inheritdoc cref="ProcessSpindleSpeedAttributes.NOMINAL"/>
        [MtconnectNodeAttribute(ProcessSpindleSpeedAttributes.NOMINAL)]
        public double? Nominal { get; set; }

        public double Value { get; set; }

        /// <inheritdoc />
        public ProcessSpindleSpeed() : base() { }

        /// <inheritdoc />
        public ProcessSpindleSpeed(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE, version)
        {
            if (double.TryParse(xNode.InnerText, out double value)) {
                Value = value;
            }
        }

        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            base.TryValidate(out validationErrors);

            if (!double.TryParse(SourceNode.InnerText, out double value))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Invalid ProcessSpindleSpeed value. CuttingTool ProcessSpindleSpeed value must be a number."));
            }

            return !validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR);

        }
    }
}
