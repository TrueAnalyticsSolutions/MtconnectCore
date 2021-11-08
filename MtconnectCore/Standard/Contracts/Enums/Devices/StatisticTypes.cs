using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Documents.Devices;

namespace MtconnectCore.Standard.Contracts.Enums.Devices
{
    /// <summary>
    /// Available options for a <c>statistic</c> attribute on a <see cref="DataItem.Statistic"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.7")]
    public enum StatisticTypes {
        /// <summary>
        /// Mathematical Average value calculated for the DataItem during the calculation period
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.7")]
        AVERAGE,
        /// <summary>
        /// Mathematical Average value calculated for the DataItem during the calculation period
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.7")]
        KURTOSIS,
        /// <summary>
        /// Maximum or peak value recorded for the DataItem during the calculation period
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.7")]
        MAXIMUM,
        /// <summary>
        /// The middle number of a series of numbers
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.7")]
        MEDIAN,
        /// <summary>
        /// Minimum value recorded for the DataItem during the calculation period
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.7")]
        MINIMUM,
        /// <summary>
        /// The number in a series of numbers that occurs most often
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.7")]
        MODE,
        /// <summary>
        /// The number in a series of numbers that occurs most often
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.7")]
        RANGE,
        /// <summary>
        /// Mathematical Root Mean Value (RMS) value calculated for the DataItem during the calculation period
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.7")]
        ROOT_MEAN_SQUARE,
        /// <summary>
        /// Statistical Standard Deviation value calculated for the DataItem during the calculation period
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.7")]
        STANDARD_DEVIATION
    }
}
