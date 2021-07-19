namespace MtconnectCore.Standard.Contracts.Enums.Devices.Elements
{
    /// <summary>
    /// Configuration contains technical information about a component describing its physical layout, functional characteristics, and relationships with other components within a piece of equipment.
    /// </summary>
    /// <remarks>See Part 2 Section 9 of the MTConnect specification</remarks>
    public enum ComponentConfigurationElements {
        /// <summary>
        /// CoordinateSystems aggregates CoordinateSystem configurations for a Component.
        /// </summary>
        /// <remarks>See Part 2 Section 9.4 of the MTConnect specification</remarks>
        COORDINATE_SYSTEMS,
        /// <summary>
        /// A CoordinateSystem is a reference system that associates a unique set of n parameters with each point in an n-dimensional space. Ref: ISO 10303-218:2004
        /// </summary>
        /// <remarks>See Part 2 Section 9.4.1 of the MTConnect specification</remarks>
        COORDINATE_SYSTEM,
        /// <summary>
        /// Relationships is an XML container that organizes information defining the associ ation between pieces of equipment that function independently but together perform a manufacturing operation. Relationships may also define the association between components within a piece of equipment.
        /// </summary>
        /// <remarks>See Part 2 Section 9.2 of the MTConnect specification</remarks>
        RELATIONSHIPS,
        /// <summary>
        /// DeviceRelationship describes the association between two pieces of equipment that function independently but together perform a manufacturing operation.
        /// </summary>
        /// <remarks>See Part 2 Section 9.2.1.1 of the MTConnect specification</remarks>
        DEVICE_RELATIONSHIP,
        /// <summary>
        /// ComponentRelationship describes the association between two components within a piece of equipment that function independently but together perform a capability or service within a piece of equipment.
        /// </summary>
        /// <remarks>See Part 2 Section 9.2.1.2 of the MTConnect specification</remarks>
        COMPONENT_RELATIONSHIP,
        /// <summary>
        /// An element that can contain descriptive content defining the configuration information for Sensor.
        /// </summary>
        /// <remarks>See Part 2 Section 9.1.3 of the MTConnect specification</remarks>
        SENSOR_CONFIGURATION,
        /// <summary>
        /// Specifications is an XML container in the Configuration of a Component that contains one or more Specification elements describing the design characteristics for a piece of equipment.
        /// </summary>
        /// <remarks>See Part 2 Section 9.3 of the MTConnect specification</remarks>
        SPECIFICATIONS,
        /// <summary>
        /// Specification elements define information describing the design characteristics for a piece of equipment.
        /// </summary>
        /// <remarks>See Part 2 Section 9.3.1 of the MTConnect specification</remarks>
        SPECIFICATION
    }
}
