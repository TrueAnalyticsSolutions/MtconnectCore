namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    /// <summary>
    /// Attributes for the CompositionDescription element in the MTConnect specification.
    /// </summary>
    public enum CompositionDescriptionAttributes {
        /// <summary>
        /// The name of the manufacturer of the physical part of a piece of equipment represented by the Composition element.
        /// </summary>
        MANUFACTURER,
        /// <summary>
        /// The model description of the physical part of a piece of equipment represented by the Composition element.
        /// </summary>
        MODEL,
        /// <summary>
        /// The serial number associated with the physical part of a piece of equipment represented by the Composition element.
        /// </summary>
        SERIAL_NUMBER,
        /// <summary>
        /// The station where the physical part of a piece of equipment represented by the Composition element is located when it is part of a manufacturing unit or cell with multiple stations.
        /// </summary>
        STATION
    }
}
