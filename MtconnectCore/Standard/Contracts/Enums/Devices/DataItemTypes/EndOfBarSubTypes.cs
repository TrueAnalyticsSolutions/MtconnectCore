using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of EVENT <c>type</c> <see cref="EventTypes.END_OF_BAR"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
    public enum EndOfBarSubTypes
    {
        /// <summary>
        /// Specific applications MAY reference one or more locations  on a piece of bar stock as the indication for the End_of_Bar. The main or most important location MUST be designated as the PRIMARY indication for the End_of_Bar. If no sub-type is specified, PRIMARY MUST be the default End_of_Bar indication.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        PRIMARY,
        /// <summary>
        /// When multiple locations on a piece of bar stock are  referenced as the indication for the End_of_Bar, the additional location(s) MUST be designated as AUXILIARY indication(s) for the End_of_Bar.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        AUXILIARY
    }
}
