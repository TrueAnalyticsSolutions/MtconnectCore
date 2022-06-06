using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Elements
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section  9.6.2")]
    public enum SolidModelElements
    {
        /// <summary>
        /// The translation of the origin to the position and orientation.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section  9.6.2")]
        TRANSFORMATION,
        /// <summary>
        /// The SolidModel Scale is either a single multiplier applied to all three dimensions or a three space multiplier given in the X, Y, and Z dimensions in the coordinate system used for the SolidModel.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section  9.6.2")]
        SCALE
    }
}
