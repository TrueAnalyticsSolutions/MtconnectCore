using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of EVENT <c>type</c> <see cref="EventTypes.PROCESS_TIME"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.2")]
    public enum ProcessTimeSubTypes
    {
        /// <summary>
        /// The time and date associated with the beginning of an activity or event.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.2")]
        START,
        /// <summary>
        /// The time and date associated with the completion of an activity or event.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.2")]
        COMPLETE,
        /// <summary>
        /// The projected time and date associated with the end or completion of an activity or event.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.2")]
        TARGET_COMPLETION
    }
}
