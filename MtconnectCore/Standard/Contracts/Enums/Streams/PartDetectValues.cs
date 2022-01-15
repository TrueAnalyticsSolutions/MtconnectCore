using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="EventTypes.PART_DETECT"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 3 Section 6.2")]
    public enum PartDetectValues
    {
        /// <summary>
        /// If a part or work piece has been detected or is present.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 3 Section 6.2")]
        PRESENT,
        /// <summary>
        /// If a part or work piece is not detected or is not present.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 3 Section 6.2")]
        NOT_PRESENT
    }
}
