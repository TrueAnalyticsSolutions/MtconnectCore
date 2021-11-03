namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of EVENT <c>type</c> <see cref="EventTypes.POWER_STATE"/>
    /// </summary>
    public enum PowerStateSubTypes {
        /// <summary>
        /// The state of the high voltage line. 
        /// </summary>
        LINE,
        /// <summary>
        /// The state of the low power line. 
        /// </summary>
        CONTROL
    }
}
