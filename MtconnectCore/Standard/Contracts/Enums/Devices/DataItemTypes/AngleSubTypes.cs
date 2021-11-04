namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.ANGLE"/>
    /// </summary>
    public enum AngleSubTypes {
        /// <summary>
        /// The angular position as read from the physical  component.
        /// </summary>
        ACTUAL,
        /// <summary>
        /// The angular position computed by the Controller.
        /// </summary>
        COMMANDED
    }
}
