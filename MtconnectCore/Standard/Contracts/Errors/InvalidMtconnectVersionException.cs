using System;

namespace MtconnectCore.Standard.Contracts.Errors
{
    /// <summary>
    /// An exception raised when the MTConnect version is unrecognized from a Response Document.
    /// </summary>
    public partial class InvalidMtconnectVersionException : Exception
    {
        const string INVALID_MESSAGE = "Invalid MTConnect Version.";

        /// <inheritdoc/>
        public InvalidMtconnectVersionException() : base(INVALID_MESSAGE) { }

        /// <inheritdoc/>
        public InvalidMtconnectVersionException(string message) : base($"{INVALID_MESSAGE} {message}") { }
    }
}
