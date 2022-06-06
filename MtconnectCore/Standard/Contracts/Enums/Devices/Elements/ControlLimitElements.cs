using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Elements
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.2.2")]
    public enum ControlLimitElements
    {
        /// <summary>
        /// The upper conformance boundary for a variable.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.2.2")]
        UPPER_LIMIT,
        /// <summary>
        /// The upper boundary indicating increased concern and supervision may be required.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.2.2")]
        UPPER_WARNING,
        /// <summary>
        /// The ideal or desired value for a variable.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.2.2")]
        NOMINAL,
        /// <summary>
        /// The lower boundary indicating increased concern and supervision may be required.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.2.2")]
        LOWER_WARNING,
        /// <summary>
        /// The lower conformance boundary for a variable.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.2.2")]
        LOWER_LIMIT
    }
}
