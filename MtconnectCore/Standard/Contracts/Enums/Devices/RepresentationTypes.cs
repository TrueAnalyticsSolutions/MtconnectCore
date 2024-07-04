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
        /// The reported value(s) are represented as a set of key-value pairs. Each reported value in the Data Set MUST have a unique key.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 7.2.2.12")]
        DATA_SET,
        /// <summary>
        /// The measured value of a sample. If no representation is specified for a DataItem, the representation MUST be determined to be VALUE.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.8")]
        VALUE,
        /// <summary>
        /// A Table is a two dimensional set of key-value pairs where the Entry represents a row, and the value is a set of key-value pair Cell elements. The Table follows the same behavior as the Data Set for change tracking, clearing, and history. When an Entry changes, all Cell elements update as a single unit following the behavior of a Data Set.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 7.2.2.12")]
        TABLE,
        /// <summary>
        /// A series of sampled data. The data is collected for a specified number of samples and each sample is collected with a fixed period
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.8")]
        TIME_SERIES,
        /// <summary>
        /// A data type where each discrete occurrence of the data  may have the same value as the previous occurrence of the data. There is no reported state change between occurrences of the data.
        /// </summary>
        [Obsolete("Deprecated in version 1.5.0. See discrete attribute for DataItem instead.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 6.2.2.6", MtconnectVersions.V_1_5_0)]
        DISCRETE
    }
}
