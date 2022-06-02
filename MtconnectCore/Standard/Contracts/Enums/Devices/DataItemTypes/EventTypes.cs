using MtconnectCore.Standard.Contracts.Attributes;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.2")]
    public enum EventTypes {
        /// <summary>
        /// The set of axes associated with a Path that the Controller is controlling. If  DataItem is not provided, it will be assumed the Controller is controlling all axes.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2")]
        ACTIVE_AXES,
        /// <summary>
        /// The state of the Actuator - ACTIVE or INACTIVE.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.11")]
        ACTUATOR_STATE,
        /// <summary>
        /// The originator’s software version of the Adapter.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        ADAPTER_SOFTWARE_VERSION,
        /// <summary>
        /// The URI of the Adapter.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        ADAPTER_URI,
        [Obsolete("Deprecated in Rel. 1.1. Replaced with CONDITION.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.2", MtconnectVersions.V_1_0_1)]
        ALARM,
        /// <summary>
        /// A set of limits used to trigger warning or alarm indicators.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        ALARM_LIMIT,
        /// <summary>
        /// The application on a component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 8.2")]
        APPLICATION,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 4.1")]
        ASSET_CHANGED,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 4.1")]
        ASSET_REMOVED,
        /// <summary>
        /// Represents the ability of a Component to communicate. This MUST be provided fo Device and MAY be provided for any other Component. AVAILABLE or UNAVAILABLE.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2")]
        AVAILABILITY,
        /// <summary>
        /// Describes the way the axes will be associated to each other. This is used in conjunction  with COUPLED_AXES to indicate the way they are interacting. The possible values are: TANDEM, SYNCHRONOUS, MASTER, and SLAVE. The coupling MUST be viewed from the perspective of the axis, therefore a MASTER coupling indicates that this axis is the master of the COUPLED_AXES.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2")]
        AXIS_COUPLING,
        /// <summary>
        /// The value of a signal or calculation issued to adjust the  feedrate of an individual linear type axis.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        AXIS_FEEDRATE_OVERRIDE,
        /// <summary>
        /// An indicator of the state of the axis lockout function when  power has been removed and the axis is allowed to move freely.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        AXIS_INTERLOCK,
        /// <summary>
        /// An indicator of the controlled state of an Axis Subcomponent.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        AXIS_STATE,
        /// <summary>
        /// The block of code being executed. Block contains the entire expression for a line of  program code.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.2")]
        BLOCK,
        /// <summary>
        /// The total count of the number of blocks of program code that have been  executed since execution started.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        BLOCK_COUNT,
        /// <summary>
        /// An indication of the state of an interlock function or control  logic state intended to prevent the associated CHUCK component from being operated.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        CHUCK_INTERLOCK,
        /// <summary>
        /// An indication of the operating state of a mechanism t holds a part or stock material during a manufacturing process. It may also represent a mechanism that holds any other mechanism in place within a device.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        CHUCK_STATE,
        [Obsolete("Deprecated in Rel 1.1.0")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.2", MtconnectVersions.V_1_0_1)]
        CODE,
        /// <summary>
        /// An indication of the operating condition of a mechanism represented by a  Composition type element.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        COMPOSITION_STATE,
        /// <summary>
        /// The status of the connection between an Adapter and an Agent.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        CONNECTION_STATUS,
        /// <summary>
        /// A set of limits used to indicate whether a process variable is stable and in control.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        CONTROL_LIMIT,
        /// <summary>
        /// The current mode of the Controller. AUTOMATIC, MANUAL,  MANUAL_DATA_INPUT, or SEMI_AUTOMATIC.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.2")]
        CONTROLLER_MODE,
        /// <summary>
        /// A setting or operator selection that changes the behavior of a piece of  equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        CONTROLLER_MODE_OVERRIDE,
        /// <summary>
        /// Refers to the set of associated axes. The value will be a space delimited set of axes names.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2")]
        COUPLED_AXES,
        /// <summary>
        /// The time and date code associated with material or other physical item. DATE_CODE MUST be reported in ISO 8601 format.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.2")]
        DATE_CODE,
        /// <summary>
        /// DEVICE_ADDED is an Event that provides the UUID of a new device added to an MTConnect Agent.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        DEVICE_ADDED,
        /// <summary>
        /// DEVICE_CHANGED is an Event that provides the UUID of the device whose Metadata has changed.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        DEVICE_CHANGED,
        /// <summary>
        /// DEVICE_REMOVED is an Event that provides the UUID of a device removed from an MTConnect Agent.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        DEVICE_REMOVED,
        /// <summary>
        /// The identifier of another piece of equipment that is temporarily associated with a component of this piece of equipment to perform a particular function.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.2")]
        DEVICE_UUID,
        /// <summary>
        /// The direction of motion. CLOCKWISE or COUNTER_CLOCKWISE. See <c>subType</c>s: <seealso cref="DirectionSubTypes"/>
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.2")]
        DIRECTION,
        /// <summary>
        /// The direction of motion of a linear device. POSTIVE or NEGATIVE
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2")]
        DOOR_STATE,
        /// <summary>
        /// An indication of whether the end of a piece of bar st being feed by a bar feeder has been reached.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        END_OF_BAR,
        /// <summary>
        /// The current state of the emergency stop actuator. ARMED (the circuit is complete and the  device is operating) or TRIGGERED (the circuit is open and the device MUST cease operation).
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2")]
        EMERGENCY_STOP,
        /// <summary>
        /// An indication that a piece of equipment, or a sub-part of a piece of  equipment, is performing specific types of activities.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        EQUIPMENT_MODE,
        /// <summary>
        /// The execution status of the Controller. READY, ACTIVE, INTERRUPTED,  FEED_HOLD, or STOPPED
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.2")]
        EXECUTION,
        /// <summary>
        /// The embedded software of a component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 8.2")]
        FIRMWARE,
        /// <summary>
        /// The current intended production status of the device  component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        FUNCTIONAL_MODE,
        /// <summary>
        /// The measurement of the hardness of a material.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        HARDNESS,
        /// <summary>
        /// The hardware of a component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 8.2")]
        HARDWARE,
        /// <summary>
        /// The current functional or operational state of an  Interface type element indicating whether the interface is active or not currently functioning.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        INTERFACE_STATE,
        /// <summary>
        /// The software library on a component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 8.2")]
        LIBRARY,
        /// <summary>
        /// The current line of code being executed. See <c>subType</c>s: <seealso cref="LineSubTypes"/>
        /// </summary>
        [Obsolete("Deprecated in version 1.4.0.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.2", MtconnectVersions.V_1_3_1)]
        LINE,
        /// <summary>
        /// An optional identifier for a BLOCK of code in a PROGRAM.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        LINE_LABEL,
        /// <summary>
        /// A reference to the position of a block of program code within a control  program. The line number MAY represent either an absolute position starting with the first line of the program or an incremental position relative to the occurrence of the last LINE_LABEL.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        LINE_NUMBER,
        /// <summary>
        /// The identifier of a material used or consumed in the manufacturing process.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        MATERIAL,
        /// <summary>
        /// Identifies the layers of material applied to a part or product as part of an additive manufacturing process.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.2")]
        MATERIAL_LAYER,
        /// <summary>
        /// An uninterpreted textual notification. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2")]
        MESSAGE,
        /// <summary>
        /// The reference version of the MTConnect Standard supported by the Adapter.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        MTCONNECT_VERSION,
        /// <summary>
        /// Network details of a component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 8.2")]
        NETWORK,
        /// <summary>
        /// The Operating System of a component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 8.2")]
        OPERATING_SYSTEM,
        /// <summary>
        /// The identifier of the person currently responsible fo operating the device.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        OPERATOR_ID,
        /// <summary>
        /// The identifier for the pallet currently in use for a given Path
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.11")]
        PALLET_ID,
        /// <summary>
        /// The current count of parts produced as represented by the Controller. MUST be  integer value. See <c>subType</c>s: <seealso cref="PartCountSubTypes"/>
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.2")]
        PART_COUNT,
        /// <summary>
        /// An indication designating whether a part or work piece has been detected or is present.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.2")]
        PART_DETECT,
        /// <summary>
        /// Identifier given to a collection of individual parts. If no subType is specified, UUID is default.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        PART_GROUP_ID,
        /// <summary>
        /// An identifier of the current part in the device 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2")]
        PART_ID,
        /// <summary>
        /// Identifier given to link the individual occurrence to a class of parts, typically distinguished by a particular part design.If no subType is specified, UUID is default.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        PART_KIND_ID,
        /// <summary>
        /// An identifier of a part or product moving through the manufacturing  process.
        /// </summary>
        [Obsolete("Deprecated in Version 1.7 PART_NUMBER is now a subType of PART_KIND_ID.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2", MtconnectVersions.V_1_6_1)]
        PART_NUMBER,
        /// <summary>
        /// State or condition of a part.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        PART_STATUS,
        /// <summary>
        /// Identifier given to a distinguishable, individual part. If no subType is specified, UUID is default.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        PART_UNIQUE_ID,
        /// <summary>
        /// The value of a signal or calculation issued to adjust the  feedrate for the axes associated with a Path component - may represent a single axis or the coordinated movement of multiple axes.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        PATH_FEEDRATE_OVERRIDE,
        /// <summary>
        /// The operational mode for this Path. SYNCHRONOUS, MIRROR, or INDEPENDENT.  Default value is INDEPENDENT if not specified.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2")]
        PATH_MODE,
        /// <summary>
        /// The ON or OFF status of the Component. DEPRECATION WARNING: MAY be  deprecated in the future. See <c>subType</c>s: <seealso cref="PowerStateSubTypes"/>
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2")]
        POWER_STATE,
        [Obsolete("Deprecated in Rel. 1.1")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.2", MtconnectVersions.V_1_0_1)]
        POWER_STATUS,
        /// <summary>
        /// Identifier given to link the individual occurrence to a group of related occurrences, such as a process step in a process plan.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        PROCESS_AGGREGATE_ID,
        /// <summary>
        /// Identifier given to link the individual occurrence to a class of processes or process definition.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        PROCESS_KIND_ID,
        /// <summary>
        /// An identifier of a process being executed by the device.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        PROCESS_OCCURRENCE_ID,
        /// <summary>
        /// The time and date associated with an activity or event.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.2")]
        PROCESS_TIME,
        /// <summary>
        /// The name of the program being executed 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2")]
        PROGRAM,
        /// <summary>
        /// A comment or non-executable statement in the control  program.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        PROGRAM_COMMENT,
        /// <summary>
        /// An indication of the Controller component’s program editing  mode.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        PROGRAM_EDIT,
        /// <summary>
        /// The name of the program being edited. This is used in conjunction with PROGRAM_EDIT when in ACTIVE state.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        PROGRAM_EDIT_NAME,
        /// <summary>
        /// The non-executable header section of the control program.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        PROGRAM_HEADER,
        /// <summary>
        /// The Uniform Resource Identifier (URI) for the source file associated with PROGRAM.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.2")]
        PROGRAM_LOCATION,
        /// <summary>
        /// Defines whether the logic or motion program defined by PROGRAM is being executed from the local memory of the controller or from an outside source.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.2")]
        PROGRAM_LOCATION_TYPE,
        /// <summary>
        /// An indication of the nesting level within a control program that is associated with the code or instructions that is currently being executed.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.2")]
        PROGRAM_NEST_LEVEL,
        /// <summary>
        /// The mode for the Rotary axis. SPINDLE, INDEX, or CONTOUR.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2")]
        ROTARY_MODE,
        /// <summary>
        /// A command issued to adjust the programmed velocity fo Rotary type axis
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        ROTARY_VELOCITY_OVERRIDE,
        /// <summary>
        /// A three space angular rotation relative to a coordinate system.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 8.2")]
        ROTATION,
        /// <summary>
        /// The serial number associated with a Component, Asset, or Device. The valid data value MUST be a text string.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        SERIAL_NUMBER,
        /// <summary>
        /// A set of limits defining a range of values designating acceptable performance for a variable.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        SPECIFICATION_LIMIT,
        /// <summary>
        /// An indication of the status of the spindle for a piece of equipment when  power has been removed and it is free to rotate.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        SPINDLE_INTERLOCK,
        [Obsolete("Deprecated in Rel. 1.2. See TOOL_ASSET_ID.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2", MtconnectVersions.V_1_1_0)]
        TOOL_ID,
        /// <summary>
        /// The identifier of an individual tool asset. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.11")]
        TOOL_ASSET_ID,
        /// <summary>
        /// An identifier for the tool group associated with a specific tool. Commonly used to designate spare tools.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.2")]
        TOOL_GROUP,
        /// <summary>
        /// The identifier of a tool provided by the device controller.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.11")]
        TOOL_NUMBER,
        /// <summary>
        /// A reference to the tool offset variables applied to the active cutting tool  associated with a Path in a Controller type component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        TOOL_OFFSET,
        /// <summary>
        /// A three space linear translation relative to a coordinate system.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 8.2")]
        TRANSLATION,
        /// <summary>
        /// The identifier of the person currently responsible for operating the piece  of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        USER,
        /// <summary>
        /// A data value whose meaning may change over time due to changes in the operation of a piece of equipment or the process being executed on that piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.2")]
        VARIABLE,
        /// <summary>
        /// An indication of the reason that EXECUTION is reporting a value of WAIT
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.2")]
        WAIT_STATE,
        /// <summary>
        /// The identifier for the type of wire used as the cutting mechanism in  Electrical Discharge Machining or similar processes.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        WIRE,
        /// <summary>
        /// The identifier for the workholding currently in use for a given Path
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2")]
        WORKHOLDING_ID,
        /// <summary>
        /// A reference to the offset variables for a work piece or part associated with  a Path in a Controller type component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        WORK_OFFSET
    }
}
