using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Assets
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.26.1.2")]
    public enum ItemLifeCountDirectionTypes
    {
        /// <summary>
        /// The tool life counts down from the maximum to zero.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.26.1.2")]
        DOWN,
        /// <summary>
        /// The tool life counts up from zero to the maximum. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.26.1.2")]
        UP
    }
}
