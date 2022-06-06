using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Elements
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.2.3")]
    public enum SpecificationLimitElements
    {
        /// <summary>
        /// The upper conformance boundary for a variable.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.2.3.1")]
        UPPER_LIMIT,
        /// <summary>
        /// The ideal or desired value for a variable.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.2.3.1")]
        NOMINAL,
        /// <summary>
        /// The lower conformance boundary for a variable.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.2.3.1")]
        LOWER_LIMIT
    }
}
