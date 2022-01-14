using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Documents.Devices;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices
{
    /// <summary>
    /// Available options for a <c>representation</c> attribute on a <see cref="DataItem.Representation"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.8")]
    public enum RepresentationTypes
    {
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
    }
}
