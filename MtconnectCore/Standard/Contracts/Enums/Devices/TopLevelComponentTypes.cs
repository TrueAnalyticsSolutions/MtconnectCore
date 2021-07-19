using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices
{
    /// <summary>
    /// Top Level Component elements are used to group the Structural Elements representing the most significant physical or logical functions of a piece of equipment. The Top Level Component elements provided in an MTConnectDevices document SHOULD be restricted to those defined in Table 16. However, these Top Level Component elements MAY also be used as Lower Level Component elements; as required.
    /// </summary>
    /// <remarks>See Part 2 Section 5 of the MTConnect specification.</remarks>
    public enum TopLevelComponentTypes {
        /// <seealso cref="AxesLowerLevelComponentTypes" />
        AXES,
        /// <seealso cref="ControllerLowerLevelComponentTypes" />
        CONTROLLER,
        /// <seealso cref="SystemsLowerLevelComponentTypes" />
        SYSTEMS,
        /// <seealso cref="AuxiliariesLowerLevelComponentTypes" />
        AUXILIARIES,
        /// <seealso cref="ResourcesLowerLevelComponentTypes" />
        RESOURCES,
        /// <seealso cref="InterfacesLowerLevelComponentTypes" />
        INTERFACES,
        [Obsolete("Deprecated in MTConnect Version 1.1 and was replaced by the Data Entity called AVAILABILITY.")]
        POWER,
        [Obsolete("Door has been redefined as a Lower Level component type of a parent Component element or as a Composition element.")]
        DOOR,
        [Obsolete("Actuator, due to its uniqueness, has been redefined as a piece of equipment with the ability to be represented as a Lower Level component of a parent Component element or as a Composition element.")]
        ACTUATOR,
        [Obsolete("Sensor, due to its uniqueness, has been redefined as a piece of equipment with the ability to be represented as  Lower Level component of a parent Component element.")]
        SENSOR,
        [Obsolete("Stock as been redefined as a Lower Level component of the Resources Top Level Component element.")]
        /// <seealso cref="ResourcesLowerLevelComponentTypes.STOCK" />
        STOCK
    }
}
