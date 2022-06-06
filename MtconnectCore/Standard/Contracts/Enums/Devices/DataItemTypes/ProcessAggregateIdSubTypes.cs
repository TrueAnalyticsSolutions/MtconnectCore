using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of EVENT <c>type</c> <see cref="EventTypes.PROCESS_AGGREGATE_ID"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
    public enum ProcessAggregateIdSubTypes
    {
        /// <summary>
        /// Identifier of the step in the process plan that this occurrence corresponds to. Synonyms include "operation id".
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        PROCESS_STEP,
        /// <summary>
        /// Identifier of the process plan that this occurrence belongs to. Synonyms include "routing id", "job id".
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        PROCESS_PLAN,
        /// <summary>
        /// Identifier of the authorization of the process occurrence. Synonyms include "job id", "work order".
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        ORDER_NUMBER
    }
}
