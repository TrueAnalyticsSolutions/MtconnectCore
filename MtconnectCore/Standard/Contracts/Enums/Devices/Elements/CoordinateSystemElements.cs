using MtconnectCore.Standard.Contracts.Attributes;

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
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.COORDINATE_SYSTEM)]
        ORIGIN,
        /// <summary>
        /// The process of transforming to the origin position of the coordinate system from a parent coordinate system using Translation and Rotation.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.COORDINATE_SYSTEM)]
        TRANSFORMATION,
        /// <summary>
        /// natural language description of the  CoordinateSystem.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, Constants.ModelBrowserLinks.COORDINATE_SYSTEM)]
        DESCRIPTION
    }
}
