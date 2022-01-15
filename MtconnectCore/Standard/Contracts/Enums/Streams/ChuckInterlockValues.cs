using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="EventTypes.CHUCK_INTERLOCK"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
    public enum ChuckInterlockValues
    {
        /// <summary>
        /// The chuck cannot be operated.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        ACTIVE,
        /// <summary>
        /// The chuck can be operated.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        INACTIVE,
    }
}
