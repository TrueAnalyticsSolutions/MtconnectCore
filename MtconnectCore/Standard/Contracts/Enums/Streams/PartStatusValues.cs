using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="EventTypes.PART_STATUS"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 3 Section 6.2")]
    public enum PartStatusValues
    {
        /// <summary>
        /// The part does conform to given requirements.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 3 Section 6.2")]
        PASS,
        /// <summary>
        /// The part does not conform to some given requirements.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 3 Section 6.2")]
        FAIL
    }
}
