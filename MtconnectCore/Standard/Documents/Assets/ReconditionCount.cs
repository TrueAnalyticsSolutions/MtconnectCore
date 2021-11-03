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
    public class ReconditionCount : MtconnectNode
    {
        /// <inheritdoc cref="ReconditionCountAttributes.MAXIMUM_COUNT"/>
        [MtconnectNodeAttribute(ReconditionCountAttributes.MAXIMUM_COUNT)]
        public double? MaximumCount { get; set; }

        public int Value { get; set; }

        /// <inheritdoc />
        public ReconditionCount() : base() { }

        /// <inheritdoc />
        public ReconditionCount(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE, version)
        {
            if (int.TryParse(xNode.InnerText, out int value))
            {
                Value = value;
            }
        }

        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            base.TryValidate(out validationErrors);

            if (!int.TryParse(SourceNode.InnerText, out int value))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Invalid ReconditionCount value. CuttingTool ReconditionCount value must be a number."));
            }

            return !validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR);

        }
    }
}
