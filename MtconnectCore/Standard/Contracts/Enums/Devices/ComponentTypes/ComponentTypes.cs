using MtconnectCore.Standard.Contracts.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.ComponentTypes
{
    /// <summary>
    /// Types of <c>Component</c>s defined in the MTConnect Standard
    /// </summary>
    public enum ComponentTypes
    {
        /// <summary>
        /// A mechanical device for moving or controlling a mechanism or system. 
        /// </summary>
        [Obsolete("Deprecated in version 1.4.0. Due to its uniqueness, has been redefined as a piece of equipment with the ability to be represented as a Lower Level component of a parent Component element.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 5.3.11", MtconnectVersions.V_1_3_1)]
        ACTUATOR,
        /// <summary>
        /// An XML container used to organize information for Lower Leve elements representing functional sub-systems that provide supplementary or extended capabilities for a piece of equipment, but they are not required for the basic operation of the equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 5")]
        AUXILIARIES,
        /// <summary>
        /// The Axes component is a container for the actual axes of which there are currently two types:  Linear and Rotary.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 5.3.1")]
        AXES,
        /// <summary>
        /// The Controller component is the Component that controls a device, executes a program,  and sends instructions to the other components of the machine. It is the brains of the machine and can be asked for its current execution state and program name.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 5.3.4")]
        CONTROLLER,
        /// <summary>
        /// A opening that can be closed.
        /// </summary>
        [Obsolete("Deprecated in version 1.4.0. Due to its uniqueness, has been redefined as a piece of equipment with the ability to be represented as a Lower Level component of a parent Component element.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 5.3.10", MtconnectVersions.V_1_3_1)]
        DOOR,
        /// <summary>
        /// The information used to coordinate actions and activity between devices  or sub-systems and a device.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 5.9")]
        INTERFACES,
        [Obsolete("Deprecated in Rel. 1.1")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 5.3.5", MtconnectVersions.V_1_0_1)]
        POWER,
        /// <summary>
        /// A sensor capable of measuring the pressure.
        /// </summary>
        [Obsolete("Deprecated in version 1.2.0. Replaced with DataItem Pressure.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 5.3.9", MtconnectVersions.V_1_1_0)]
        PRESSURE,
        /// <summary>
        /// A sensor capable of measuring the temperature of a component. The temperature is always given in Celsius.
        /// </summary>
        [Obsolete("Deprecated in version 1.2.0. Replaced with a DataItem called Temperature.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 5.3.6", MtconnectVersions.V_1_1_0)]
        THERMOSTAT,
        /// <summary>
        /// An XML container used to organize information for Lower Leve elements representing types of items, materials, and personnel that support the operation of a piece of equipment or work to be performed at a location. Resources also represents materials or other items consumed or transformed by a piece of equipment for production of parts or other types of goods.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 5")]
        RESOURCES,
        /// <summary>
        /// Sensor is a component that may or may not be integral to a parent component or device.  When Sensor is not integral to a parent device or component – it can function as a device. Sensor data MUST be associated with its most relevant Component and MUST be represented as a DataItem for that Component.
        /// </summary>
        [Obsolete("Deprecated in version 1.4.0. Due to its uniqueness, has been redefined as a piece of equipment with the ability to be represented as a Lower Level component of a parent Component element.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 4.2.7", MtconnectVersions.V_1_3_1)]
        SENSOR,
        /// <summary>
        /// The spindle is a rotational axis that revolves at high speed and has its speed expressed in REVOLUTION/MINUTE. The spindle can also have additional data items. Spindle speed has been specified as a separate data item since it receives special treatment in many applications. Velocity is used for linear axes other than spindle.
        /// </summary>
        [Obsolete("Deprecated in version 1.1.0.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 5.4.1", MtconnectVersions.V_1_0_1)]
        SPINDLE,
        /// <summary>
        /// Stock is a Structural Element that represents the material that is used in a manufacturing process and to which work is applied in a machine or piece of equipment to produce parts.<br/><br/>
        /// Stock may be either a continuous piece of material from which multiple parts may be produced or it may be a discrete piece of material that will produce a part or a set of parts.
        /// </summary>
        [Obsolete("Deprecated in version 1.4.0. Due to its uniqueness, has been redefined as a piece of equipment with the ability to be represented as a Lower Level component of a parent Component element.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 5.8", MtconnectVersions.V_1_3_1)]
        STOCK,
        /// <summary>
        /// The Systems component is a place holder for all the system types.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 5.3.12")]
        SYSTEMS,
        /// <summary>
        /// A sensor capable of measuring the vibration of a component.
        /// </summary>
        [Obsolete("Deprecated in version 1.2.0. Replaced with DataItems to measure vibration (Displacement, Frequency, etc.).")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 5.3.7", MtconnectVersions.V_1_1_0)]
        VIBRATION,
    }
}
