using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.SOUND_LEVEL"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
    public enum SoundLeveSubTypes {
        /// <summary>
        /// No weighting factor on the frequency scale 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        NO_SCALE,
        /// <summary>
        /// A Scale weighting factor. This is the default  weighting factor if no factor is specified
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        A_SCALE,
        /// <summary>
        /// B Scale weighting factor
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        B_SCALE,
        /// <summary>
        /// C Scale weighting factor 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        C_SCALE,
        /// <summary>
        /// D Scale weighting factor
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        D_SCALE
    }
}
