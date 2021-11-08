using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Assets
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.11.2")]
    public enum LocationTypes {
        /// <summary>
        /// The number of the pot in the tool handling system.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.11.2")]
        POT,
        /// <summary>
        /// The tool location in a horizontal turning machine.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.11.2")]
        STATION,
        /// <summary>
        /// The location with regard to a tool crib. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.11.2")]
        CRIB
    }
}
