namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.AMPERAGE"/>
    /// </summary>
    public enum AmperageSubTypes {
        /// <summary>
        /// The measurement of alternating current. If not  specified further in statistic, defaults to RMS Current
        /// </summary>
        ALTERNATING,
        /// <summary>
        /// The measurement of DC current
        /// </summary>
        DIRECT
    }
}
