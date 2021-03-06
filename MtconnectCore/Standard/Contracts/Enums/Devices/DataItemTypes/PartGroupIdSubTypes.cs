using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of EVENT <c>type</c> <see cref="EventTypes.PART_GROUP_ID"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
    public enum PartGroupIdSubTypes
    {
        /// <summary>
        /// The globally unique identifier as specified in ISO 11578 or RFC 4122.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        UUID,
        /// <summary>
        /// An identifier that references a group of parts tracked as a lot.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        LOT,
        /// <summary>
        /// An identifier that references a group of parts produced in a batch.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        BATCH,
        /// <summary>
        /// The unique identifier for a singular piece of material that is used to make multiple parts.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        RAW_MATERIAL,
        /// <summary>
        /// An identifier used to reference a material heat number.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        HEAT_TREAT
    }
}
