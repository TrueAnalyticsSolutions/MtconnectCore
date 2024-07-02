namespace MtconnectCore.Standard.Contracts.Enums
{
    /// <summary>
    /// Options for how the Version number is compared agains the current version.
    /// </summary>
    public enum VersionComparisonTypes
    {
        /// <summary>
        /// Validation Method is executed when the document version is equal to the specified version.
        /// </summary>
        Implemented,
        /// <summary>
        /// Validation Method is executed when the document version is equal to or less than the specified version.
        /// </summary>
        NotImplemented,
        /// <summary>
        /// Validation Method is executed when the document version is equal to or greater than the specified version.
        /// </summary>
        Deprecated
    }
}
