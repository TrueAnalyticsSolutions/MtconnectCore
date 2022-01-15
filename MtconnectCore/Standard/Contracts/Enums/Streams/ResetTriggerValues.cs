using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Documents.Streams;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for a <see cref="Sample.ResetTriggered"/> element.
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 7.2.3.5")]
    public enum ResetTriggerValues
    {
        /// <summary>
        /// The value of the Data Entity that is measuring an action or  operation is to be reset upon completion of that action or operation.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 7.2.3.5")]
        ACTION_COMPLETE,
        /// <summary>
        /// The value of the Data Entity is to be reset at the end of a 12- month period.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 7.2.3.5")]
        ANNUAL,
        /// <summary>
        /// The value of the Data Entity is to be reset at the end of a 24-hour  period.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 7.2.3.5")]
        DAY,
        /// <summary>
        /// The value of the data item is not reset and accumulates for the  entire life of the piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 7.2.3.5")]
        LIFE,
        /// <summary>
        /// The value of the data item is to be reset upon completion of a  maintenance event.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 7.2.3.5")]
        MAINTENANCE,
        /// <summary>
        /// The value of the Data Entity is to be reset at the end of a monthly  period.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 7.2.3.5")]
        MONTH,
        /// <summary>
        /// The value of the Data Entity is to be reset when power was  applied to the piece of equipment after a planned or unplanned interruption of power has occurred.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 7.2.3.5")]
        POWER_ON,
        /// <summary>
        /// The value of the Data Entity is to be reset at the end of a work  shift.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 7.2.3.5")]
        SHIFT,
        /// <summary>
        /// The value of the Data Entity is to be reset at the end of a 7-day  period.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 7.2.3.5")]
        WEEK
    }
}
