namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    /// <summary>
    /// Channel represents each sensing element connected to a sensor unit.
    /// </summary>
    /// <remarks>See Part 2 Section 9.1.3.1.1 of the MTConnect specification.</remarks>
    public enum ChannelAttributes {
        /// <summary>
        /// A unique identifier that will only refer to a specific sensing element.
        /// </summary>
        NUMBER,
        /// <summary>
        /// The name of the sensing element.
        /// </summary>
        NAME
    }
}
