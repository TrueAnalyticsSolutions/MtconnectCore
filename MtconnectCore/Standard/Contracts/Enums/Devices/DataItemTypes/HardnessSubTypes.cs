using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of EVENT <c>type</c> <see cref="EventTypes.HARDNESS"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
    public enum HardnessSubTypes
    {
        /// <summary>
        /// A scale to measure the resistance to deformation of a surface.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        ROCKWELL,
        /// <summary>
        /// A scale to measure the resistance to deformation of a surface.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        VICKERS,
        /// <summary>
        /// A scale to measure the resistance to deformation of a surface.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        SHORE,
        /// <summary>
        /// A scale to measure the resistance to deformation of a surface.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        BRINELL,
        /// <summary>
        /// A scale to measure the elasticity of a surface.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        LEEB,
        /// <summary>
        /// A scale to measure the resistance to scratching of a surface.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        MOHS
    }
}
