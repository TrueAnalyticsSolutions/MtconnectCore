using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.SPINDLE_SPEED"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1", MtconnectVersions.V_1_1_0)]
    public enum SpindleSpeedSubTypes {
        /// <summary>
        /// The rotational speed of a rotary axis.  ROTARY_MODE MUST be SPINDLE.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1", MtconnectVersions.V_1_1_0)]
        ACTUAL,
        /// <summary>
        /// The rotational speed the as specified in the program. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1", MtconnectVersions.V_1_1_0)]
        COMMANDED,
        /// <summary>
        /// The operator’s overridden value. Percent of commanded.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1", MtconnectVersions.V_1_1_0)]
        OVERRIDE
    }
}
