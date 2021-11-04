namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.ROTARY_VELOCITY"/>
    /// </summary>
    public enum RotaryVelocitySubTypes {
        /// <summary>
        /// The rotational speed the rotary axis is spinning at.  ROTARY_MODE MUST be SPINDLE.
        /// </summary>
        ACTUAL,
        /// <summary>
        /// The rotational speed as specified in the program. 
        /// </summary>
        COMMANDED,
        /// <summary>
        /// The operator’s overridden value. Percent of commanded.
        /// </summary>
        OVERRIDE
    }
}
