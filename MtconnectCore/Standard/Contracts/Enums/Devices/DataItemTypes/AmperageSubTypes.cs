using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.AMPERAGE"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
    public enum AmperageSubTypes {
        /// <summary>
        /// The measurement of alternating current. If not  specified further in statistic, defaults to RMS Current
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        ALTERNATING,
        /// <summary>
        /// The measurement of DC current
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        DIRECT
    }
}
