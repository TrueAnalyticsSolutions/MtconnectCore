using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="EventElements.POWER_STATUS"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
    public enum PowerStatusValues
    {
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
        ON,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
        OFF
    }
}
