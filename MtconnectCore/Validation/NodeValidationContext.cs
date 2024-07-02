using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Standard.Contracts;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MtconnectCore.Validation
{
    public partial class NodeValidationContext
    {
        public MtconnectNode Node { get; set; }

        public ICollection<MtconnectValidationException> Exceptions { get; set; } = new List<MtconnectValidationException>();

        public NodeValidationContext(MtconnectNode node)
        {
            Node = node;
        }

        /// <summary>
        /// Indicates whether a collection of exceptions contains any <c>ERROR</c>-level severities.
        /// </summary>
        /// <param name="errors">Collection of validation exceptions</param>
        /// <returns>Flag for whether or not any of the exceptions are <c>ERROR</c>-level severity</returns>
        public bool HasError(out ICollection<MtconnectValidationException> errors)
        {
            errors = Exceptions;
            return HasError();
        }

        public bool HasError()
            => Exceptions.Any(o => o.Severity == ValidationSeverity.ERROR);

        public NodeValidationContext Validate(Func<NodeValidator, NodeValidator> validator)
        {
            try
            {
                validator.Invoke(new NodeValidator(this));
            }
            catch (Exception ex)
            {
                Exceptions.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Exception prevented further validation of {Node.SourceNode.LocalName}",
                    Node.SourceNode));
            }
            return this;
        }

        public NodeValidationContext ValidateValueProperty<TEnum>(string propertyName, Func<NodeValueValidator<TEnum>, NodeValidator> validator) where TEnum : Enum
        {
            try
            {
                validator.Invoke(new NodeValueValidator<TEnum>(this, propertyName));
            }
            catch (Exception ex)
            {
                Exceptions.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Exception prevented further validation of {Node.SourceNode.LocalName}",
                    Node.SourceNode));
            }
            return this;
        }
    }
}
