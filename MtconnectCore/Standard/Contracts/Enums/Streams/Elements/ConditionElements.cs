using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams.Elements
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
    public enum ConditionElements
    {
        /// <summary>
        /// The item being monitored is operating normally and no action is required. Normal also  420 indicates a Fault has been cleared if the item was previously identified with Fault.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        Normal,
        /// <summary>
        /// The item being monitored is moving into the abnormal range and should be observed. No  423 action is required at this time.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        Warning,
        /// <summary>
        /// The item has failed and intervention is required to return to a normal condition.  426 Transition to a normal condition indicates that the Fault has been cleared. A fault is 427 something that always needs to be acknowledged before operation can continue. Faults 428 are sometimes noted as an alarm.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        Fault,
        /// <summary>
        /// The condition is in an indeterminate state since the data source is no longer providing  431 data. This will also be the initial state of the condition before a connection is established 432 with the data source. The condition MUST be Unavailable when the value is 433 unknown.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        Unavailable
    }
}
