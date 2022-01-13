using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.DEPOSITION_ACCELERATION_VOLUMETRIC"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
    public enum DepositionAccelerationVolumetricSubTypes
    {
        /// <summary>
        /// The measured rate of change in spatial volume of material deposited in an additive manufacturing process.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
        ACTUAL,
        /// <summary>
        /// The commanded rate of change in spatial volume of material to be deposited in an additive manufacturing process.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
        COMMANDED
    }
}
