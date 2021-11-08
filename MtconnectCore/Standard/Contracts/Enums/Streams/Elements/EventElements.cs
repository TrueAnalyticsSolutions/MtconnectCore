using MtconnectCore.Standard.Contracts.Attributes;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Streams.Elements
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
    public enum EventElements
    {
        /// <summary>
        /// The set of axes being controlled by a Path. The value MUST be a space delimited set of axes names. For example: &lt;ActiveAxes …&gt;X Y Z C&lt;/ActiveAxes&gt; If this is not provided, it MUST assumed the Path is controlling all the axes.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
        ACTIVE_AXES,
        /// <summary>
        /// An actuator state represents a device for moving or controlling a mechanism or system.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.10.2")]
        ACTUATOR_STATE,
        /// <summary>
        /// An indicator of the current axis homed position and motion.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        AXIS_STATE,
        /// <summary>
        /// Represents the components ability to communicate its availability. This MUST be provided for the device and MAY be provided for all other components.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
        AVAILABILITY,
        /// <summary>
        /// Describes the way the axes will be associated to each other. This is used in conjunction with COUPLED_AXES to indicate the way the are interacting.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
        AXIS_COUPLING,
        /// <summary>
        /// The value of a signal or calculation issued to adjust the feedrate of an individual linear type axis.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        AXIS_FEEDRATE_OVERRIDE,
        /// <summary>
        /// An indicator of the state of the axis lockout functio when power has been removed and the axis is allowed to move freely.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        AXIS_INTERLOCK,
        /// <summary>
        /// A Block of code is a command being executed by the Controller. The Block MUST include the entire command with all the parameters.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
        BLOCK,
        /// <summary>
        /// The total count of the number of blocks of program  code that have been executed since execution started.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        BLOCK_COUNT,
        /// <summary>
        /// An interlock that prevents the chuck from being operated. The subType specifies the operation that is currently blocked.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        CHUCK_INTERLOCK,
        /// <summary>
        /// The open closed state of the chuck.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        CHUCK_STATE,
        /// <summary>
        /// The code is just the G, M, or NC code being executed. The Code MUST only contain the simplest form of the executing command.
        /// </summary>
        [Obsolete("Deprecated in version 1.1.0. See BLOCK instead.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1", MtconnectVersions.V_1_0_1)]
        CODE,
        /// <summary>
        /// An indication of the operating condition of a mechanism represented by a Composition type element.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        COMPOSITION_STATE,
        /// <summary>
        /// The Mode of the Controller.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
        CONTROLLER_MODE,
        /// <summary>
        /// A setting or operator selection that changes the  behavior of a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        CONTROLLER_MODE_OVERRIDE,
        /// <summary>
        /// As a Linear or Rotary axis data item, refers to the set of associated axes to be used in conjunction with AxisCoupling. The value will be a space delimited set of axes names. For example: &lt;CoupledAxes …&gt;Y2&lt;/CoupledAxes&gt;
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
        COUPLED_AXES,
        /// <summary>
        /// A Direction indicates the direction of rotation. The CDATA MUST be either CLOCKWISE or COUNTER_CLOCKWISE.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
        DIRECTION,
        /// <summary>
        /// A door state represents an opening that can be opened or closed.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
        DOOR_STATE,
        /// <summary>
        /// A YES/NO value indicating that the end of bar has been reached.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        END_OF_BAR,
        /// <summary>
        /// The emergency stop state of the machine.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
        EMERGENCY_STOP,
        /// <summary>
        /// An indication that a piece of equipment, or a subpart of a piece of equipment, is performing specific  types of activities.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        EQUIPMENT_MODE,
        /// <summary>
        /// The Execution state of the Controller.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
        EXECUTION,
        /// <summary>
        /// The overall status of the device or component for production.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        FUNCTIONAL_MODE,
        /// <summary>
        /// The measurement of the hardness of a material.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        HARDNESS,
        /// <summary>
        /// The connection state of the interface.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        INTERFACE_STATE,
        /// <summary>
        /// This event refers to the optional program line number. For example in RS274/NGC the line number begins with an N and is followed by 1 to 5 digits (0 – 99999). If there is not an assigned line number in the programming systems as in RS274, the line number will refer to the position in the executing program. The line number MUST be any positive integer from 0 to 2^32 -1.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
        LINE,
        /// <summary>
        /// An optional identifier for a BLOCK of code in a  PROGRAM.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        LINE_LABEL,
        /// <summary>
        /// A reference to the position of a block of program  code within a control program.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        LINE_NUMBER,
        /// <summary>
        /// The identifier of a material used or consumed in the  manufacturing process.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        MATERIAL,
        /// <summary>
        /// A text notification. Format MAY be any valid text string.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.10.2")]
        MESSAGE,
        /// <summary>
        /// An identifier of the person operating the device. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        OPERATOR_ID,
        /// <summary>
        /// This is a reference to an identifier for the current pallet available at the device.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.10.2")]
        PALLET_ID,
        /// <summary>
        /// The number of parts produced. This will not be counted by the agent and MUST only be supplied if the controller provides the count.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
        PART_COUNT,
        /// <summary>
        /// This is a reference to an identifier for the current part being machined. It is a placeholder for now and can be used at the discretion of the implementation.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
        PART_ID,
        /// <summary>
        /// The Path mode is provided for devices that are controlling multiple sets of axes using one program.When PathMode is not provided it MUST be assumed to be INDEPENDENT.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
        PATH_MODE,
        /// <summary>
        /// A percentage override to adjust the feed rate of this path. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        PATH_FEEDRATE_OVERRIDE,
        /// <summary>
        /// Power status MUST be either ON or OFF.
        /// </summary>
        [Obsolete("Deprecated in version 1.1.0 of the MTConnect Standard.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1", MtconnectVersions.V_1_0_1)]
        POWER_STATUS,
        /// <summary>
        /// Power state MUST be either ON or OFF. DEPRECATION WARNING: MAY be deprecated in the future.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
        POWER_STATE,
        /// <summary>
        /// The name of the program executing in the controller. This is usually the name of the file containing the program instructions.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
        PROGRAM,
        /// <summary>
        /// This refers to the controls program editing states.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        PROGRAM_EDIT,
        /// <summary>
        /// The name of the program being edited.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        PROGRAM_EDIT_NAME,
        /// <summary>
        /// The latest active comment in the executing program.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        PROGRAM_COMMENT,
        /// <summary>
        /// The header section of the current executing program. The content SHOULD be limited to 512 bytes.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        PROGRAM_HEADER,
        /// <summary>
        /// The mode the rotary axis is currently operating.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
        ROTARY_MODE,
        /// <summary>
        /// The percentage override to adjust the programmed spin speed.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        ROTARY_VELOCITY_OVERRIDE,
        /// <summary>
        /// The serial number associated with a Component,  Asset, or Device.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        SERIAL_NUMBER,
        /// <summary>
        /// An indicator of the spindle lockout when power has been removed and it is free to rotate.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        SPINDLE_INTERLOCK,
        /// <summary>
        /// This is a reference to an identifier for the current tool in use by the Path. It is a placeholder for now and can be used at the discretion of the implementation. Once mobile assets have been defined, this will refer to the corresponding asset.
        /// </summary>
        [Obsolete("Deprecated in version 1.2.0. See ToolAssetId")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1", MtconnectVersions.V_1_1_0)]
        TOOL_ID,
        /// <summary>
        /// This is a reference to an identifier for the current tool in use by the Path.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.10.2")]
        TOOL_ASSET_ID,
        /// <summary>
        /// The identifier assigned by the Controller component to a cutting tool when in use by a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        TOOL_NUMBER,
        /// <summary>
        /// A reference to the tool offset variables applied to t active cutting tool associated with a Path in a Controller type component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        TOOL_OFFSET,
        /// <summary>
        /// The identifier of the person currently responsible fo operating the piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        USER,
        /// <summary>
        /// The identifier for the type of wire used as the cutti mechanism in Electrical Discharge Machining or similar processes.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        WIRE,
        /// <summary>
        /// This is a reference to an identifier for the current workholding. It is a placeholder for now and can be used at the discretion of the implementation. Once mobile assets have been defined, this will refer to the corresponding asset.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
        WORKHOLDING_ID,
        /// <summary>
        /// A reference to the offset variables for a work piece  or part associated with a Path in a Controller type component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        WORK_OFFSET
    }
}
