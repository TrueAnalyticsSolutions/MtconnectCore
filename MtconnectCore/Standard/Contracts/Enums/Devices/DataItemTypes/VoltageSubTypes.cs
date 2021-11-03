namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.VOLTAGE"/>
    /// </summary>
    public enum VoltageSubTypes {
        /// <summary>
        /// The measurement of alternating voltage. If not  specified further in statistic, defaults to RMS voltage
        /// </summary>
        ALTERNATING,
        /// <summary>
        /// The measurement of DC voltage 
        /// </summary>
        DIRECT
    }
}
