using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="DirectionSubTypes.ROTARY"/>
    /// </summary>
    public enum DirectionRotaryValues
    {
        /// <summary>
        /// The rotary component is rotating in a clockwise fashion  using the right hand rule.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
        CLOCKWISE,
        /// <summary>
        /// The rotary component is rotating in a counter clockwise  fashion using the right hand rule.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
        COUNTER_CLOCKWISE,
        /// <summary>
        /// No direction.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 3 Section 6.2")]
        NONE
    }
}
