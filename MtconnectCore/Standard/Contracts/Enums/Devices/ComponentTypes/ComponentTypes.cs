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
        /// The Axes component is a container for the actual axes of which there are currently two types:  Linear and Rotary.
        /// </summary>
        AXES,
        /// <summary>
        /// The Controller component is the Component that controls a device, executes a program,  and sends instructions to the other components of the machine. It is the brains of the machine and can be asked for its current execution state and program name.
        /// </summary>
        CONTROLLER,
        [Obsolete("Deprecated in Rel. 1.1")]
        POWER,
        /// <summary>
        /// A opening that can be closed.
        /// </summary>
        DOOR,
        /// <summary>
        /// A mechanical device for moving or controlling a mechanism or system. 
        /// </summary>
        ACTUATOR,
        /// <summary>
        /// Sensor is a component that may or may not be integral to a parent component or device.  When Sensor is not integral to a parent device or component – it can function as a device. Sensor data MUST be associated with its most relevant Component and MUST be represented as a DataItem for that Component.
        /// </summary>
        SENSOR,
        /// <summary>
        /// The Systems component is a place holder for all the system types.
        /// </summary>
        SYSTEMS,
    }
}
