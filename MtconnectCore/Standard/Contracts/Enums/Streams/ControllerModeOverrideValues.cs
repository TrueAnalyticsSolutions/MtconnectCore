using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="EventTypes.CONTROLLER_MODE_OVERRIDE"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
    public enum ControllerModeOverrideValues
    {
        /// <summary>
        /// The indicator of the  ControllerModeOverride is in the ON state and the mode override is active.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        ON,
        /// <summary>
        /// The indicator of the  ControllerModeOverride is in the OFF state and the mode override is inactive
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        OFF
    }
}
