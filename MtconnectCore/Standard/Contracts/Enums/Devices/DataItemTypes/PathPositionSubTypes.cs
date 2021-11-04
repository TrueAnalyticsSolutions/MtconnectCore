namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.PATH_POSITION"/>
    /// </summary>
    public enum PathPositionSubTypes {
        /// <summary>
        /// The position of the Component as read from the  device.
        /// </summary>
        ACTUAL,
        /// <summary>
        /// The position computed by the Controller.
        /// </summary>
        COMMANDED,
        /// <summary>
        /// The target position for the movement.
        /// </summary>
        TARGET,
        /// <summary>
        /// The position provided by a probe
        /// </summary>
        PROBE
    }
}
