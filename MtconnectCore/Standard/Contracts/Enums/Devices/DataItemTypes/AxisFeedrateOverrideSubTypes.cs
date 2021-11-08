using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of EVENT <c>type</c> <see cref="EventTypes.AXIS_FEEDRATE_OVERRIDE"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
    public enum AxisFeedrateOverrideSubTypes
    {
        /// <summary>
        /// The value of a signal or calculation issued to adjust feedrate of an individual linear type axis when that axis is being operated in a manual state or method (jogging).
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        JOG,
        /// <summary>
        /// The value of a signal or calculation issued to adjust the  feedrate of an individual linear type axis that has been specified by a logic or motion program or set by a switch.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        PROGRAMMED,
        /// <summary>
        /// The value of a signal or calculation issued to adjust the  feedrate of an individual linear type axis that is operating in a rapid positioning mode.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        RAPID
    }
}
