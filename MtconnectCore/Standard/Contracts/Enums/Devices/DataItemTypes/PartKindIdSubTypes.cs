using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of EVENT <c>type</c> <see cref="EventTypes.PART_KIND_ID"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
    public enum PartKindIdSubTypes
    {
        /// <summary>
        /// The globally unique identifier as specified in ISO 11578 or RFC 4122.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        UUID,
        /// <summary>
        /// Identifier of a particular part design or model.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        PART_NUMBER,
        /// <summary>
        /// An identifier given to a group of parts having similarities in geometry, manufacturing process, and/or functions.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        PART_FAMILY,
        /// <summary>
        /// A word or set of words by which a part is known, addressed, or referred to.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        PART_NAME
    }
}
