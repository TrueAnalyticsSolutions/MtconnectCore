using System;

namespace MtconnectCore.Standard.Contracts.Errors
{
    public partial class InvalidMtconnectVersion : Exception
    {
        const string INVALID_MESSAGE = "Invalid MTConnect Version.";

        public InvalidMtconnectVersion() : base(INVALID_MESSAGE) { }

        public InvalidMtconnectVersion(string message) : base($"{INVALID_MESSAGE}: {message}") { }
    }
}
