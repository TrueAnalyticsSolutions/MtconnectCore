using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Elements
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.2.1")]
    public enum ProcessSpecificationElements
    {
        /// <summary>
        /// A set of limits used to indicate whether a process variable is stable and in control.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.2.1")]
        CONTROL_LIMITS,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.2.1")]
        CONTROL_LIMIT,
        /// <summary>
        /// A set of limits defining a range of values designating acceptable performance for a variable.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.2.1")]
        SPECIFICATION_LIMITS,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.2.1")]
        SPECIFICATION_LIMIT,
        /// <summary>
        /// A set of limits used to trigger warning or alarm indicators.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.2.1")]
        ALARM_LIMITS,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.2.1")]
        ALARM_LIMIT
    }
}
