using System;

namespace MtconnectCore.Standard.Contracts.Errors
{
    public partial class MtconnectStreamFailure : Exception
    {
        const string FAILURE_MESSAGE = "Failed to fetch MTConnect Stream.";

        public MtconnectStreamFailure() : base(FAILURE_MESSAGE) { }

        public MtconnectStreamFailure(string message) : base($"{FAILURE_MESSAGE}: {message}") { }
    }
}
