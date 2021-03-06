using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of EVENT <c>type</c> <see cref="EventTypes.PART_COUNT"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.2")]
    public enum PartCountSubTypes {
        /// <summary>
        /// The count of all the parts produced. If the subtype is not given, this is the default. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.2")]
        ALL,
        /// <summary>
        /// Indicates the count of correct parts made. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.2")]
        GOOD,
        /// <summary>
        /// Indicates the count of incorrect parts produced.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.2")]
        BAD,
        /// <summary>
        /// Indicates the number of parts that are projected or planned to  be produced
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        TARGET,
        /// <summary>
        /// The number of parts remaining in stock or to be produced.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        REMAINING
    }
}
