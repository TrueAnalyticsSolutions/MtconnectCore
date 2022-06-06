using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.VOLTAGE_DC"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 4.2")]
    public enum VoltageDcSubTypes
    {
        /// <summary>
        /// The measured voltage within an electrical circuit.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 4.2")]
        ACTUAL,
        /// <summary>
        /// The value for a voltage as specified by a Controller component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 4.2")]
        COMMANDED,
        /// <summary>
        /// The value for a voltage as specified by a logic or motion program or set by a switch.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 4.2")]
        PROGRAMMED
    }
}
