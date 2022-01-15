using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="EventTypes.AXIS_INTERLOCK"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
    public enum AxisInterlockValues
    {
        /// <summary>
        /// The axis lockout function is activated power has been removed from the axis, and the axis is allowed to move freely.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        ACTIVE,
        /// <summary>
        /// The axis lockout function has not  been activated, the axis may be powered, and the axis is capable of being controlled by another component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        INACTIVE
    }
}
