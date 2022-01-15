using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Assets
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.26.1.1")]
    public enum ItemLifeTypes
    {
        /// <summary>
        /// The tool life measured in minutes. All units for minimum, maximum,  and warningLevel MUST be provided in minutes. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.26.1.1")]
        MINUTES,
        /// <summary>
        /// The tool life measured in parts. All units for minimum, maximum, and warningLevel MUST be provided supplied as the number of parts.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.26.1.1")]
        PART_COUNT,
        /// <summary>
        /// The tool life measured in tool wear. Wear MUST be provided in millimeters as an offset to nominal. All units for minimum, maximum, and warningLevel MUST be given as millimeter offsets as well. The standard will only consider dimensional wear at this time.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.26.1.1")]
        WEAR
    }
}
