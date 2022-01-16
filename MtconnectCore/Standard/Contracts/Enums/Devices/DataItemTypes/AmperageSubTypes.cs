using MtconnectCore.Standard.Contracts.Attributes;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.AMPERAGE"/>
    /// </summary>
    [Obsolete("Deprecated in v1.6.0")]
    [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10", MtconnectVersions.V_1_5_0)]
    public enum AmperageSubTypes
    {
        /// <summary>
        /// The measured amperage being delivered  from a power source.
        /// </summary>
        [Obsolete("Deprecated in v1.6.0")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.1", MtconnectVersions.V_1_5_0)]
        ACTUAL,
        /// <summary>
        /// The measurement of alternating current. If not  specified further in statistic, defaults to RMS Current
        /// </summary>
        [Obsolete("Deprecated in v1.6.0")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10", MtconnectVersions.V_1_5_0)]
        ALTERNATING,
        /// <summary>
        /// The measurement of DC current
        /// </summary>
        [Obsolete("Deprecated in v1.6.0")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10", MtconnectVersions.V_1_5_0)]
        DIRECT,
        /// <summary>
        /// The desired or preset amperage to be  delivered from a power source.
        /// </summary>
        [Obsolete("Deprecated in v1.6.0")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.1", MtconnectVersions.V_1_5_0)]
        TARGET
    }
}
