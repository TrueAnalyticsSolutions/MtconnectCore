using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Documents.Devices;

namespace MtconnectCore.Standard.Contracts.Enums.Devices
{
    /// <summary>
    /// Available options for a <c>representation</c> attribute on a <see cref="DataItem.Representation"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.8")]
    public enum RepresentationTypes {
        /// <summary>
        /// The measured value of a sample. If no representation is specified for a DataItem, the representation MUST be determined to be VALUE.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.8")]
        VALUE,
        /// <summary>
        /// A series of sampled data. The data is collected for a specified number of samples and each sample is collected with a fixed period
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.8")]
        TIME_SERIES,
        /// <summary>
        /// A data type where each discrete occurrence of the data  may have the same value as the previous occurrence of the data. There is no reported state change between occurrences of the data.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 6.2.2.6")]
        DISCRETE
    }
}
