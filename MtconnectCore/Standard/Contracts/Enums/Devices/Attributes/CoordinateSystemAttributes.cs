namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    /// <summary>
    /// Attributes of the CoordinateSystem element
    /// </summary>
    /// <remarks>See Part 2 Section 9.4.1.1 of the MTConnect specification.</remarks>
    public enum CoordinateSystemAttributes
    {
        /// <summary>
        /// The unique identifier for this element.
        /// </summary>
        ID,
        /// <summary>
        /// The name of the coordinate system.
        /// </summary>
        NAME,
        /// <summary>
        /// The manufacturer’s name or users name for the coordinate system.
        /// </summary>
        NATIVE_NAME,
        /// <summary>
        /// A pointer to the id attribute of the parent CoordinateSystem.
        /// </summary>
        PARENT_ID_REF,
        /// <summary>
        /// The type of coordinate system. See <see cref="CoordinateSystemTypes"/>.
        /// </summary>
        TYPE
    }
}
