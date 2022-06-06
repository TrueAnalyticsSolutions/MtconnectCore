using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of EVENT <c>type</c> <see cref="EventTypes.USER"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
    public enum UserSubTypes
    {
        /// <summary>
        /// The identifier of the person currently responsible for operating the piece  of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        OPERATOR,
        /// <summary>
        /// The identifier of the person currently responsible for performing  maintenance on the piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        MAINTENANCE,
        /// <summary>
        /// The identifier of the person currently responsible for preparing a piece of  equipment for production or restoring the piece of equipment to a neutral state after production.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        SET_UP
    }
}
