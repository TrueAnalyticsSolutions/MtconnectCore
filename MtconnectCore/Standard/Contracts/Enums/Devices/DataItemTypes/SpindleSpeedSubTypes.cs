namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.SPINDLE_SPEED"/>
    /// </summary>
    public enum SpindleSpeedSubTypes {
        /// <summary>
        /// The rotational speed of a rotary axis.  ROTARY_MODE MUST be SPINDLE.
        /// </summary>
        ACTUAL,
        /// <summary>
        /// The rotational speed the as specified in the program. 
        /// </summary>
        COMMANDED,
        /// <summary>
        /// The operator’s overridden value. Percent of commanded.
        /// </summary>
        OVERRIDE
    }
}
