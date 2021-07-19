namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    /// <summary>
    /// Attributes of the DESCRIPTION element of a COMPONENT
    /// </summary>
    /// <remarks>See Part 2 Section 4.4.3.1 of the MTConnect specification.</remarks>
    public enum ComponentDescriptionAttributes
    {
        /// <summary>
        /// The name of the manufacturer of the physical or logical part of a piece of equipment represented by the Component element.
        /// </summary>
        MANUFACTURER,
        /// <summary>
        /// The model description of the physical part or logical function of a piece of equipment represented by the Component element.
        /// </summary>
        MODEL,
        /// <summary>
        /// The serial number associated with the physical part or logical function of a piece of equipment represented by the Component element.
        /// </summary>
        SERIAL_NUMBER,
        /// <summary>
        /// The station where the physical part or logical function of a piece of equipment represented by the Component element is located when it is part of a manufacturing unit or cell with multiple stations.
        /// </summary>
        STATION
    }
}
