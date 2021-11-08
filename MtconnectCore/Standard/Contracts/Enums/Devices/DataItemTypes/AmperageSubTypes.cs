using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.AMPERAGE"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
    public enum AmperageSubTypes
    {
        /// <summary>
        /// The measured amperage being delivered  from a power source.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.1")]
        ACTUAL,
        /// <summary>
        /// The measurement of alternating current. If not  specified further in statistic, defaults to RMS Current
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        ALTERNATING,
        /// <summary>
        /// The measurement of DC current
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        DIRECT,
        /// <summary>
        /// The desired or preset amperage to be  delivered from a power source.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.1")]
        TARGET
    }
}
