using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of EVENT <c>type</c> <see cref="EventTypes.EQUIPMENT_MODE"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
    public enum EquipmentModeSubTypes
    {
        /// <summary>
        /// An indication that the sub-parts of a piece of equipment are under load.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        LOADED,
        /// <summary>
        /// An indication that a piece of equipment is performing any activity – the  equipment is active and performing a function under load or not.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        WORKING,
        /// <summary>
        /// An indication that the major sub-parts of a piece of equipment are  powered or performing any activity whether producing a part or product or not.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        OPERATING,
        /// <summary>
        /// An indication that primary power is applied to the piece of equipment  and, as a minimum, the controller or logic portion of the piece of equipment is powered and functioning or components that are required to remain on are powered.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        POWERED,
        /// <summary>
        /// An indication that a piece of equipment is waiting for an event or an  action to occur.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        DELAY
    }
}
