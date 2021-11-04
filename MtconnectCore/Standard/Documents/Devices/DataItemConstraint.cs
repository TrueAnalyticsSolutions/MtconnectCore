using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <summary>
    /// Constraints are used by a software application to evaluate the validity of the data reported.
    /// </summary>
    public class DataItemConstraint : MtconnectNode
    {
        /// <inheritdoc cref="ConstraintElements.VALUE"/>
        public string Value { get; set; }

        /// <inheritdoc cref="ConstraintElements.MAXIMUM"/>
        [MtconnectNodeElement(ConstraintElements.MAXIMUM)]
        public string Maximum { get; set; }

        /// <inheritdoc cref="ConstraintElements.MINIMUM"/>
        [MtconnectNodeElement(ConstraintElements.MINIMUM)]
        public string Minimum { get; set; }

        /// <inheritdoc cref="ConstraintElements.NOMINAL"/>
        [MtconnectNodeElement(ConstraintElements.NOMINAL)]
        public string Nominal { get; set; }

        /// <inheritdoc cref="ConstraintElements.FILTER"/>
        [MtconnectNodeElement(ConstraintElements.FILTER)]
        public Filter Filter { get; set; }

        /// <inheritdoc/>
        public DataItemConstraint() : base() { }

        /// <inheritdoc/>
        public DataItemConstraint(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE, version) {
            if (xNode.ChildNodes.Count < 2)
            {
                Value = xNode.InnerText;
            }
        }

        /// <inheritdoc/>
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            base.TryValidate(out validationErrors);

            const string documentationAttributes = "See Part 2 Section 7.2.3.3.1 of the MTConnect standard.";

            if (Filter != null)
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.WARNING,
                    $"Filter DEPRECATED in Version 1.4 - Moved to the Filters element of a DataItem. {documentationAttributes}"));
            }

            return !validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR);
        }
    }
}
