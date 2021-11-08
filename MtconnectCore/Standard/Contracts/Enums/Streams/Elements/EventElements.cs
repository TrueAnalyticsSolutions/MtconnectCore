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
        /// A Block of code is a command being executed by the Controller. The Block MUST include the entire command with all the parameters.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
        BLOCK,
        /// <summary>
        /// The code is just the G, M, or NC code being executed. The Code MUST only contain the simplest form of the executing command.
        /// </summary>
        [Obsolete("Deprecated in version 1.1.0. See BLOCK instead.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1", MtconnectVersions.V_1_0_1)]
        CODE,
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
        /// The Mode of the Controller.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
        CONTROLLER_MODE,
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
        /// The Execution state of the Controller.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
        EXECUTION,
        /// <summary>
        /// The emergency stop state of the machine.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
        EMERGENCY_STOP,
        /// <summary>
        /// The overall status of the device or component for production.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        FUNCTIONAL_MODE,
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
        /// This is a reference to an identifier for the current workholding. It is a placeholder for now and can be used at the discretion of the implementation. Once mobile assets have been defined, this will refer to the corresponding asset.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
        WORKHOLDING_ID
    }
}
