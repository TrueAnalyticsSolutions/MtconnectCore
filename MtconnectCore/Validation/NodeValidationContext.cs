using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Standard.Contracts;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MtconnectCore.Validation
{
    /// <summary>
    /// Represents the context for validating a node within the MTConnect standard.
    /// </summary>
    public partial class NodeValidationContext
    {
        /// <summary>
        /// Gets or sets the MTConnect node that is being validated.
        /// </summary>
        public MtconnectNode Node { get; set; }

        /// <summary>
        /// Gets or sets the collection of validation exceptions that occur during the validation process.
        /// </summary>
        public ICollection<MtconnectValidationException> Exceptions { get; set; } = new List<MtconnectValidationException>();

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeValidationContext"/> class with the specified node.
        /// </summary>
        /// <param name="node">The MTConnect node that is being validated.</param>
        public NodeValidationContext(MtconnectNode node)
        {
            Node = node;
        }

        /// <summary>
        /// Determines whether the collection of validation exceptions contains any <c>ERROR</c>-level severities.
        /// </summary>
        /// <param name="errors">The collection of validation exceptions.</param>
        /// <returns><c>true</c> if any of the exceptions are of <c>ERROR</c>-level severity; otherwise, <c>false</c>.</returns>
        public bool HasError(out ICollection<MtconnectValidationException> errors)
        {
            errors = Exceptions;
            return HasError();
        }

        /// <summary>
        /// Determines whether the collection of validation exceptions contains any <c>ERROR</c>-level severities.
        /// </summary>
        /// <returns><c>true</c> if any of the exceptions are of <c>ERROR</c>-level severity; otherwise, <c>false</c>.</returns>
        public bool HasError()
            => Exceptions.Any(o => o.Severity == ValidationSeverity.ERROR || o.Severity == ValidationSeverity.FATAL);

        /// <summary>
        /// Validates the current node using the specified validation logic.
        /// </summary>
        /// <param name="validator">A function that defines the validation logic.</param>
        /// <returns>The current <see cref="NodeValidationContext"/>.</returns>
        public NodeValidationContext Validate(Func<NodeValidator, NodeValidator> validator)
        {
            try
            {
                validator.Invoke(new NodeValidator(this));
            }
            catch (Exception ex)
            {
                Exceptions.Add(new MtconnectValidationException(
                    ValidationSeverity.FATAL,
                    $"Exception prevented further validation of {Node.SourceNode.LocalName}",
                    Node.SourceNode));
            }
            return this;
        }

        /// <summary>
        /// Validates a property based on the provided enum value, which represents the property name.
        /// </summary>
        /// <typeparam name="TEnum">The enum type representing the property.</typeparam>
        /// <param name="enumProperty">The enum value representing the property name.</param>
        /// <param name="validator">A function that defines the validation logic for the property.</param>
        /// <returns>The current <see cref="NodeValidationContext"/>.</returns>
        public NodeValidationContext ValidateValueProperty<TEnum>(TEnum enumProperty, Func<NodeValueValidator<TEnum>, NodeValidator> validator) where TEnum : Enum
        {
            string propertyName = enumProperty.ToString();
            return ValidateValueProperty(propertyName, validator);
        }
        public NodeValidationContext ValidateValueProperty<TEnum>(TEnum enumProperty, string helpLink, Func<NodeValueValidator<TEnum>, NodeValidator> validator) where TEnum : Enum
        {
            string propertyName = enumProperty.ToString();
            return ValidateValueProperty(propertyName, helpLink, validator);
        }

        /// <summary>
        /// Validates a property based on the provided string value, which represents the property name.
        /// </summary>
        /// <typeparam name="TEnum">The enum type representing the property.</typeparam>
        /// <param name="propertyName">The string value representing the property name.</param>
        /// <param name="validator">A function that defines the validation logic for the property.</param>
        /// <returns>The current <see cref="NodeValidationContext"/>.</returns>
        public NodeValidationContext ValidateValueProperty<TEnum>(string propertyName, Func<NodeValueValidator<TEnum>, NodeValidator> validator) where TEnum : Enum
        {
            try
            {
                validator.Invoke(new NodeValueValidator<TEnum>(this, propertyName));
            }
            catch (Exception ex)
            {
                Exceptions.Add(new MtconnectValidationException(
                    ValidationSeverity.FATAL,
                    $"Exception prevented further validation of {Node.SourceNode.LocalName}",
                    Node.SourceNode) {
                    // TODO: Add ExceptionCodeEnum
                    SourceContext = Standard.Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY,
                    SourceContextScope = propertyName
                });
            }
            return this;
        }

        public NodeValidationContext ValidateValueProperty<TEnum>(string propertyName, string helpLink, Func<NodeValueValidator<TEnum>, NodeValidator> validator) where TEnum : Enum
        {
            try
            {
                validator.Invoke(new NodeValueValidator<TEnum>(this, propertyName, helpLink));
            }
            catch (Exception ex)
            {
                Exceptions.Add(new MtconnectValidationException(
                    ValidationSeverity.FATAL,
                    $"Exception prevented further validation of {Node.SourceNode.LocalName}",
                    Node.SourceNode) {
                    // TODO: Add ExceptionCodeEnum
                    SourceContext = Standard.Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY,
                    SourceContextScope = propertyName
                });
            }
            return this;
        }

        /// <summary>
        /// Adds a <see cref="Exception.HelpLink" /> to each <see cref="MtconnectValidationException"/> in <see cref="Exceptions"/>.
        /// </summary>
        /// <param name="url">URL to help documentation. Ideally this would be a link to the MTConnect Model Browser.</param>
        /// <returns>The current <see cref="NodeValidationContext"/>.</returns>
        public NodeValidationContext UpdateHelpLinks(string url)
        {
            foreach (var exception in Exceptions)
            {
                exception.HelpLink = url;
            }
            return this;
        }
    }
}
