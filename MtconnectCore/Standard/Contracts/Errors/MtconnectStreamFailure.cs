using System;

namespace MtconnectCore.Standard.Contracts.Errors
{
    /// <summary>
    /// Represents errors received during a MTConnect current or sample request.
    /// </summary>
    public partial class MtconnectStreamFailure : Exception
    {
        const string FAILURE_MESSAGE = "Failed to fetch MTConnect Stream.";

        /// <inheritdoc/>
        public MtconnectStreamFailure() : base(FAILURE_MESSAGE) { }

        /// <inheritdoc/>
        public MtconnectStreamFailure(string message) : base($"{FAILURE_MESSAGE}: {message}") { }
    }
}
