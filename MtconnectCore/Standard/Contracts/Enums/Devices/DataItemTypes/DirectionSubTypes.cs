namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of EVENT <c>type</c> <see cref="EventTypes.DIRECTION"/>
    /// </summary>
    public enum DirectionSubTypes
    {
        /// <summary>
        /// The rotational direction of a rotary device using the right hand rule convention as defined  in Appendix B. CLOCKWISE or COUNTER_CLOCKWISE
        /// </summary>
        ROTARY,
        /// <summary>
        /// The direction of motion of a linear device. POSTIVE or NEGATIVE
        /// </summary>
        LINEAR
    }
}
