namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.AXIS_FEEDRATE"/>
    /// </summary>
    public enum AxisFeedrateSubTypes {
        /// <summary>
        /// The actual federate of a linear axis. 
        /// </summary>
        ACTUAL,
        /// <summary>
        /// The feedrate as specified in the program. 
        /// </summary>
        COMMANDED,
        /// <summary>
        /// The operator’s overridden value. Percent of commanded.
        /// </summary>
        OVERRIDE
    }
}
