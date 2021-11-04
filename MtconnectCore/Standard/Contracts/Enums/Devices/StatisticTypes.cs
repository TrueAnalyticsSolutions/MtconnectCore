using MtconnectCore.Standard.Documents.Devices;

namespace MtconnectCore.Standard.Contracts.Enums.Devices
{
    /// <summary>
    /// Available options for a <c>statistic</c> attribute on a <see cref="DataItem.Statistic"/>
    /// </summary>
    public enum StatisticTypes {
        /// <summary>
        /// Mathematical Average value calculated for the DataItem during the calculation period
        /// </summary>
        AVERAGE,
        /// <summary>
        /// Mathematical Average value calculated for the DataItem during the calculation period
        /// </summary>
        KURTOSIS,
        /// <summary>
        /// Maximum or peak value recorded for the DataItem during the calculation period
        /// </summary>
        MAXIMUM,
        /// <summary>
        /// The middle number of a series of numbers
        /// </summary>
        MEDIAN,
        /// <summary>
        /// Minimum value recorded for the DataItem during the calculation period
        /// </summary>
        MINIMUM,
        /// <summary>
        /// The number in a series of numbers that occurs most often
        /// </summary>
        MODE,
        /// <summary>
        /// The number in a series of numbers that occurs most often
        /// </summary>
        RANGE,
        /// <summary>
        /// Mathematical Root Mean Value (RMS) value calculated for the DataItem during the calculation period
        /// </summary>
        ROOT_MEAN_SQUARE,
        /// <summary>
        /// Statistical Standard Deviation value calculated for the DataItem during the calculation period
        /// </summary>
        STANDARD_DEVIATION
    }
}
