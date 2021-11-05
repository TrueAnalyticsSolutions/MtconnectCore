using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="EventElements.DIRECTION"/>
    /// </summary>
    public enum DirectionValues
    {
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
        CLOCKWISE,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
        COUNTER_CLOCKWISE
    }
}
