using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.ComponentTypes
{
    /// <summary>
    /// Sub-components of <see cref="ComponentTypes.SYSTEMS"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 5.3.12")]
    public enum SystemsSubComponentTypes {
        /// <summary>
        /// A component representing the hydraulics and hydraulic distribution system of a device.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 5.3.13")]
        HYDRAULIC,
        /// <summary>
        /// A component representing the pneumatics and compressed air distribution system of a device.
        /// </summary>
        PNEUMATIC,
        /// <summary>
        /// A Component representing the coolant and coolant distribution system of a device.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 5.3.14")]
        COOLANT,
        /// <summary>
        /// A Component representing the lubricant and lubrication distribution system of a device. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 5.3.15")]
        LUBRICATION,
        /// <summary>
        /// A Component representing the electrical supply for a device. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 5.3.16")]
        ELECTRIC
    }
}
