using System;

namespace MtconnectCore.Standard.Contracts.Errors
{
    /// <summary>
    /// Represents errors received during a MTConnect probe request.
    /// </summary>
    public partial class MtconnectProbeFailure : Exception
    {
        const string FAILURE_MESSAGE = "Failed to fetch MTConnect Probe.";

        /// <inheritdoc/>
        public MtconnectProbeFailure() : base(FAILURE_MESSAGE) { }

        /// <inheritdoc/>
        public MtconnectProbeFailure(string message) : base($"{FAILURE_MESSAGE}: {message}") { }
    }
}
