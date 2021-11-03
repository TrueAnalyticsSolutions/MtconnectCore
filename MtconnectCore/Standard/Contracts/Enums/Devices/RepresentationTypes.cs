using MtconnectCore.Standard.Documents.Devices;

namespace MtconnectCore.Standard.Contracts.Enums.Devices
{
    /// <summary>
    /// Available options for a <c>representation</c> attribute on a <see cref="DataItem.Representation"/>
    /// </summary>
    public enum RepresentationTypes {
        /// <summary>
        /// The measured value of a sample. If no representation is specified for a DataItem, the representation MUST be determined to be VALUE.
        /// </summary>
        VALUE,
        /// <summary>
        /// A series of sampled data. The data is collected for a specified number of samples and each sample is collected with a fixed period
        /// </summary>
        TIME_SERIES
    }
}
