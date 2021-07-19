namespace MtconnectCore.Standard.Contracts.Enums.Devices.Elements
{
    /// <summary>
    /// Elements for a Transformation element in the MTConnect Response Document.
    /// </summary>
    /// <remarks>See Part 2 Section 9.4.1.2.1 of the MTConnect specification</remarks>
    public enum TransformationElements {
        /// <summary>
        /// Translations along X, Y, and Z axes are expressed as x, y, and z respectively within a 3-dimensional vector.
        /// The values MUST be given in MILLIMETER_3D.
        /// </summary>
        TRANSLATION,
        /// <summary>
        /// Rotations about X, Y, and Z axes are expressed in A, B, and C respectively within a 3-dimensional vector. The values MUST be given in DEGREE_3D. Positive A, B, and C are in the directions to advance right-hand screws in the positive X, Y, and Z directions, respectively. Ref:ISO 9787:2013
        /// </summary>
        ROTATION
    }
}
