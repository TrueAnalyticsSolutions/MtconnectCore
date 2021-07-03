using System;

namespace MtconnectCore.Standard.Contracts.Errors
{
    public partial class MtconnectProbeFailure : Exception
    {
        const string FAILURE_MESSAGE = "Failed to fetch MTConnect Probe.";

        public MtconnectProbeFailure() : base(FAILURE_MESSAGE) { }

        public MtconnectProbeFailure(string message) : base($"{FAILURE_MESSAGE}: {message}") { }
    }
}
