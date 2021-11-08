using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="EventElements.AXIS_STATE"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
    public enum AxisStateValues
    {
        /// <summary>
        /// The axis is in its home position.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        HOME,
        /// <summary>
        /// The axis is in motion
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        TRAVEL,
        /// <summary>
        /// The axis has been moved to a fixed  position and is being maintained in that position either electrically or mechanically. Action is required to release the axis from this position.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        PARKED,
        /// <summary>
        /// The axis is stopped
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        STOPPED
    }
}
