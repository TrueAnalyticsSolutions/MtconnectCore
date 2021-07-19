using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;

namespace MtconnectCore.Standard.Contracts
{
    internal static partial class ExceptionHelper
    {
        internal static string ToString(this ICollection<MtconnectValidationException> validationErrors) {
            string[] errors = validationErrors.Select(o => $" - [{o.Severity}] {o.Message}").ToArray();
            return string.Join("\r\n", errors);
        }
    }
}
