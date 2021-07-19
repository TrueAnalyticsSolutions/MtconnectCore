using MtconnectCore.Standard.Contracts.Enums;
using System;

namespace MtconnectCore.Standard.Contracts.Errors
{
    /// <summary>
    /// An exception that represents any validation error on XML nodes within a MTConnect Response Document.
    /// </summary>
    public class MtconnectValidationException : Exception
    {
        /// <summary>
        /// Severity of the validation error that occurred.
        /// </summary>
        public ValidationSeverity Severity { get; set; }

        /// <summary>
        /// Initializes a MTConnect validation exception with a specific severity and message.
        /// </summary>
        /// <param name="severity">Sets the severity level of the error.</param>
        /// <param name="message">Sets the message of the validation error.</param>
        public MtconnectValidationException(ValidationSeverity severity, string message) : base(message)
        {
            Severity = severity;
        }
    }
}
