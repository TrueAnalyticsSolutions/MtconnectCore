using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="DirectionSubTypes.LINEAR"/>
    /// </summary>
    public enum DirectionLinearValues
    {
        /// <summary>
        /// A linear component moving in the direction of increasing  position value
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.10.2")]
        POSITIVE,
        /// <summary>
        /// A linear component moving in the direction of decreasing  position value
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.10.2")]
        NEGATIVE
    }
}
