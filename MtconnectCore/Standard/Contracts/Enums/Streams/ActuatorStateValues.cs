using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="EventTypes.ACTUATOR_STATE"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.10.2")]
    public enum ActuatorStateValues
    {
        /// <summary>
        /// The actuator is operating or active
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.8.4")]
        ACTIVE,
        /// <summary>
        /// The actuator is not operating or inactive
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.8.4")]
        INACTIVE
    }
}
