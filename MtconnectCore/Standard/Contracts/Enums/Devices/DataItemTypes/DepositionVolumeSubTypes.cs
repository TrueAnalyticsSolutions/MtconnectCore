using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.DEPOSITION_VOLUME"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
    public enum DepositionVolumeSubTypes
    {
        /// <summary>
        /// The measured spatial volume of material deposited.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
        ACTUAL,
        /// <summary>
        /// The target spatial volume of material to be deposited.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
        COMMANDED
    }
}
