using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of EVENT <c>type</c> <see cref="EventTypes.CONTROLLER_MODE_OVERRIDE"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
    public enum ControllerModeOverrideSubTypes
    {
        /// <summary>
        /// A setting or operator selection used to execute a test mode to confirm the  execution of machine functions.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        DRY_RUN,
        /// <summary>
        /// A setting or operator selection that changes the behavior of the controller  on a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        SINGLE_BLOCK,
        /// <summary>
        /// A setting or operator selection that changes the behavior of the controller  on a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        MACHINE_AXIS_LOCK,
        /// <summary>
        /// A setting or operator selection that changes the behavior of the controller on a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        OPTIONAL_STOP,
        /// <summary>
        /// A setting or operator selection that changes the behavior of the controller on a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        TOOL_CHANGE_STOP
    }
}
