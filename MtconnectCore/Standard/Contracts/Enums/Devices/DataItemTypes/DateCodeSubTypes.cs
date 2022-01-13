using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of EVENT <c>type</c> <see cref="EventTypes.DATE_CODE"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.2")]
    public enum DateCodeSubTypes
    {
        /// <summary>
        /// The time and date code relating to the production of a material or other physical item.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.2")]
        MANUFACTURE,
        /// <summary>
        /// The time and date code relating to the expiration or end of useful life for a material or other physical item.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.2")]
        EXPIRATION,
        /// <summary>
        /// The time and date code relating the first use of a material or other physical item.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.2")]
        FIRST_USE
    }
}
