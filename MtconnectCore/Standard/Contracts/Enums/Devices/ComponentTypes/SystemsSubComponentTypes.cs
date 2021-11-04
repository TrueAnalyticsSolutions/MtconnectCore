namespace MtconnectCore.Standard.Contracts.Enums.Devices.ComponentTypes
{
    /// <summary>
    /// Sub-components of <see cref="ComponentTypes.SYSTEMS"/>
    /// </summary>
    public enum SystemsSubComponentTypes {
        /// <summary>
        /// A component representing the hydraulics and hydraulic distribution system of a device.
        /// </summary>
        HYDRAULIC,
        /// <summary>
        /// A component representing the pneumatics and compressed air distribution system of a device.
        /// </summary>
        PNEUMATIC,
        /// <summary>
        /// A Component representing the coolant and coolant distribution system of a device.
        /// </summary>
        COOLANT,
        /// <summary>
        /// A Component representing the lubricant and lubrication distribution system of a device. 
        /// </summary>
        LUBRICATION,
        /// <summary>
        /// A Component representing the electrical supply for a device. 
        /// </summary>
        ELECTRIC
    }
}
