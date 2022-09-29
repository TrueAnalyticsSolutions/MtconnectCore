using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MtconnectCore.Validation
{
    /// <summary>
    /// Provides a context for logging multiple validation exceptions to a single MTConnect node.
    /// </summary>
    public class ValidationContext : IDisposable
    {
        private ValidationReport Report;
        private MtconnectNode Node;
        private List<MtconnectValidationException> _exceptions = new List<MtconnectValidationException>();

        public ValidationContext(ValidationReport report, MtconnectNode node)
        {
            Report = report;
            Node = node;
        }

        /// <summary>
        /// Adds one or more validation exceptions.
        /// </summary>
        /// <param name="exceptions"></param>
        public void AddExceptions(params MtconnectValidationException[] exceptions)
        {
            if (exceptions.Length > 0)
            {
                _exceptions.AddRange(exceptions);
            }
        }

        /// <summary>
        /// Determines if there are any exceptions that are of the severity level ERROR.
        /// </summary>
        /// <returns>Flag if any exception has the severity level of ERROR.</returns>
        public bool HasErrors() => _exceptions.Any(o => o.Severity == ValidationSeverity.ERROR);

        /// <summary>
        /// Disposes of the validation context and logs any exceptions gathered during the context to the underlying Report.
        /// </summary>
        public void Dispose()
        {
            if (_exceptions.Count > 0)
            {
                Report?.AddExceptions(Node, _exceptions.ToArray());
            }
            _exceptions.Clear();
        }
    }
}
