namespace MtconnectCore.Standard.Contracts.Enums.ExceptionsReport
{
    /// <summary>
    /// Representation for the context of the exception as it relates to the source.
    /// </summary>
    public enum ExceptionContextEnum
    {
        /// <summary>
        /// Indicates the context is directly upon the source itself.
        /// </summary>
        ENTITY,
        /// <summary>
        /// Indicates the context is upon a value property of the source.
        /// </summary>
        VALUE_PROPERTY,
        /// <summary>
        /// Indicates the context is upon a part of the source.
        /// </summary>
        PART
    }
}
