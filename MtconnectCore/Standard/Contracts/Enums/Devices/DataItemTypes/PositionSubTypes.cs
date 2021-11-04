namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.POSITION"/>
    /// </summary>
    public enum PositionSubTypes {
        /// <summary>
        /// The position of the Component. 
        /// </summary>
        ACTUAL,
        /// <summary>
        /// The position as given by the Controller.
        /// </summary>
        COMMANDED,
        /// <summary>
        /// The target position for the movement.
        /// </summary>
        TARGET
    }
}
