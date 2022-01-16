using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.AMPERAGE_AC"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 4.2")]
    public enum AmperageAcSubTypes
    {
        /// <summary>
        /// The measured amperage within an electrical circuit.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 4.2")]
        ACTUAL,
        /// <summary>
        /// The value for a current as specified by a component. The COMMANDED current is a calculated value that includes adjustments and overrides.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 4.2")]
        COMMANDED,
        /// <summary>
        /// The value for a current as specified by a logic or motion program or set by a switch.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 4.2")]
        PROGRAMMED
    }
}
