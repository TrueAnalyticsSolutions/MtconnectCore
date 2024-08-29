using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
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
        public DataItemConstraint(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) {
            if (xNode.ChildNodes.Count < 2)
            {
                Value = xNode.InnerText;
            }
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 7.2.3.2.1")]
        private bool ValidateProperties(out ICollection<MtconnectValidationException> validationErrors)
        {
            return new NodeValidationContext(this)
                // Validate Filter - Check if the Filter is present and warn that it is deprecated in version 1.4
                .ValidateValueProperty<ConstraintElements>(nameof(Filter), (o) =>
                    o.IsImplemented(Filter.Value)
                    ?.If(
                        (v) => Filter != null,
                        (v) => throw new MtconnectValidationException(
                            ValidationSeverity.WARNING,
                            "Filter DEPRECATED in Version 1.4 - Moved to the Filters element of a DataItem."
                        )
                    )
                )
                // Return validation errors
                .HasError(out validationErrors);
        }

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 7.2.3.2.1")]
        //private bool validateFilter(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (Filter != null)
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.WARNING,
        //            $"Filter DEPRECATED in Version 1.4 - Moved to the Filters element of a DataItem."));
        //    }
        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}
    }
}
