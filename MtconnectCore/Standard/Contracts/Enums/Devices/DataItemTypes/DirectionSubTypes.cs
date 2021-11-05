using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of EVENT <c>type</c> <see cref="EventTypes.DIRECTION"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.11")]
    public enum DirectionSubTypes
    {
        /// <summary>
        /// The rotational direction of a rotary device using the right hand rule convention as defined  in Appendix B. CLOCKWISE or COUNTER_CLOCKWISE
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.11")]
        ROTARY,
        /// <summary>
        /// The direction of motion of a linear device. POSTIVE or NEGATIVE
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.11")]
        LINEAR
    }
}
