using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Elements
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.2.4")]
    public enum AlarmLimitElements
    {
        /// <summary>
        /// The upper conformance boundary for a variable.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.2.4.1")]
        UPPER_LIMIT,
        /// <summary>
        /// The upper boundary indicating increased concern and supervision may be required.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.2.4.1")]
        UPPER_WARNING,
        /// <summary>
        /// The lower boundary indicating increased concern and supervision may be required.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.2.4.1")]
        LOWER_WARNING,
        /// <summary>
        /// The lower conformance boundary for a variable.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.2.4.1")]
        LOWER_LIMIT
    }
}
