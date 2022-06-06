using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams.Attributes
{
    public enum ResetTriggers
    {
        /// <summary>
        /// The value of the Data Entity that is measuring an action or operation was reset upon completion of that action or operation.
        /// </summary>
        ACTION_COMPLETE,
        /// <summary>
        /// The value of the Data Entity was reset at the end of a 12-month period.
        /// </summary>
        ANNUAL,
        /// <summary>
        /// The value of the Data Entity was reset at the end of a 24-hour period.
        /// </summary>
        DAY,
        /// <summary>
        /// The value of the Data Entity was reset upon completion of a maintenance event.
        /// </summary>
        MAINTENANCE,
        /// <summary>
        /// The value of the Data Entity was reset based on a physical reset action.
        /// </summary>
        MANUAL,
        /// <summary>
        /// The value of the Data Entity was reset at the end of a monthly period.
        /// </summary>
        MONTH,
        /// <summary>
        /// The value of the Data Entity was reset when power was applied to the piece of equipment after a planned or unplanned interruption of power has occurred.
        /// </summary>
        POWER_ON,
        /// <summary>
        /// The value of the Data Entity was reset at the end of a work shift.
        /// </summary>
        SHIFT,
        /// <summary>
        /// The value of the Data Entity was reset at the end of a 7-day period.
        /// </summary>
        WEEK
    }
}
