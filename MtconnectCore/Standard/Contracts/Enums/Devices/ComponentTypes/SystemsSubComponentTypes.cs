using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.ComponentTypes
{
    /// <summary>
    /// Sub-components of <see cref="ComponentTypes.SYSTEMS"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 5.3.12")]
    public enum SystemsSubComponentTypes {
        /// <summary>
        /// A Component representing the coolant and coolant distribution system of a device.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 5.3.14")]
        COOLANT,
        /// <summary>
        /// Cooling is a system used to to extract controlled amounts of heat to achieve a target temperature at a specified cooling rate.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 5.3.14")]
        COOLING,
        /// <summary>
        /// Dielectric is an XML container that represents the information for a system that manages a chemical mixture used in a manufacturing process being performed at that piece of equipment. For example, this could describe the dielectric system for an EDM process or the chemical bath used in a plating process.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 5.3.10")]
        DIELECTRIC,
        /// <summary>
        /// A Component representing the electrical supply for a device. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 5.3.16")]
        ELECTRIC,
        /// <summary>
        /// Enclosure is an XML container that represents the information for a structure used to contain or isolate a piece of equipment or area. The Enclosure system may provide information regarding access to the internal components of a piece of equipment or the conditions within the enclosure.For example, Door may be defined as a Lower Level Component or Composition element of the Enclosure system.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 5.3.6")]
        ENCLOSURE,
        /// <summary>
        /// EndEffector is an XML container that represents the information for those functions that form the last link segment of a piece of equipment. It is the part of a piece of equipment that interacts with the manufacturing process.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 5.3.11")]
        END_EFFECTOR,
        /// <summary>
        /// Feeder is an XML container that represents the information for a system that manages the delivery of materials within a piece of equipment. For example, this could describe the wire delivery system for an EDM or welding process; conveying system or pump and valve system distributing material to a blending station; or a fuel delivery system feeding a furnace.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 5.3.9")]
        FEEDER,
        /// <summary>
        /// Heating is a system used to deliver controlled amounts of heat to achieve a target temperature at a specified heating rate.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 5.3.13")]
        HEATING,
        /// <summary>
        /// A component representing the hydraulics and hydraulic distribution system of a device.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 5.3.13")]
        HYDRAULIC,
        /// <summary>
        /// A Component representing the lubricant and lubrication distribution system of a device. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 5.3.15")]
        LUBRICATION,
        /// <summary>
        /// A component representing the pneumatics and compressed air distribution system of a device.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 3.4.7.2")]
        PNEUMATIC,
        /// <summary>
        /// Pressure is a system that delivers compressed gas or fluid and controls the pressure and rate of pressure change to a desired target set-point.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Par 2 Section 5.3.15")]
        PRESSURE,
        /// <summary>
        /// ProcessPower is an XML container that represents the information for a power source associated with a piece of equipment that supplies energy to the manufacturing process separate from the Electric system. For example, this could be the power source for an EDM machining process, an electroplating line, or a welding system.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 5.3.8")]
        PROCESS_POWER,
        /// <summary>
        /// Protective is an XML container that represents the information for those functions that detect or prevent harm or damage to equipment or personnel. Protective does not include the information relating to the Enclosure system.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 5.3.7")]
        PROTECTIVE,
        /// <summary>
        /// Vacuum is a system that evacuates gases and liquids from an enclosed and sealed space to a controlled negative pressure or a molecular density below the prevailing atmospheric level.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 5.3.16")]
        VACUUM,
        /// <summary>
        /// WorkEnvelope organizes information about the physical process execution space within a piece of equipment. The WorkEnvelope MAY provide information regarding the physical workspace and the conditions within that workspace.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 5.3.12")]
        WORK_ENVELOPE
    }
}
