namespace MtconnectCore.Standard.Contracts.Enums
{
    /// <summary>
    /// Representation of available value types for MTConnectException Severity.
    /// </summary>
    public enum ValidationSeverity
    {
        /// <summary>
        /// Missing information of a constrained element that is dedicated for the developer.
        /// </summary>
        INFO,
        /// <summary>
        /// For incorrect situations that can cause errors. It is used for less severe situations than the error.
        /// </summary>
        WARNING,
        /// <summary>
        /// For incorrect situations that must be solved.
        /// </summary>
        ERROR,
        /// <summary>
        /// Syntactical and/or grammatical error where validation can no longer continue.
        /// </summary>
        FATAL
    }
}
