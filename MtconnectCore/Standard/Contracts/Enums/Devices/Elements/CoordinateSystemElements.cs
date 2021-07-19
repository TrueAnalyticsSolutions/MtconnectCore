namespace MtconnectCore.Standard.Contracts.Enums.Devices.Elements
{
    /// <summary>
    /// Elements for the CoordinateSystem element in the MTConnect Response Document.
    /// </summary>
    /// <remarks>See Part 2 Section 9.4.1.2 of the MTConnect specification</remarks>
    public enum CoordinateSystemElements {
        /// <summary>
        /// The coordinates of the origin position of a coordinate system. The coordinate MUST be in MILLIMETER_3D.
        /// </summary>
        ORIGIN,
        /// <summary>
        /// The process of transforming to the origin position of the coordinate system from a parent coordinate system using Translation and Rotation.
        /// </summary>
        TRANSFORMATION
    }
}
