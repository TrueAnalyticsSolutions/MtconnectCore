using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    public enum EventTypes {
        /// <summary>
        /// The state of the Actuator - ACTIVE or INACTIVE.
        /// </summary>
        ACTUATOR_STATE,
        [Obsolete("Deprecated in Rel. 1.1. Replaced with CONDITION.")]
        ALARM,
        /// <summary>
        /// The set of axes associated with a Path that the Controller is controlling. If  DataItem is not provided, it will be assumed the Controller is controlling all axes.
        /// </summary>
        ACTIVE_AXES,
        /// <summary>
        /// Represents the ability of a Component to communicate. This MUST be provided fo Device and MAY be provided for any other Component. AVAILABLE or UNAVAILABLE.
        /// </summary>
        AVAILABILITY,
        /// <summary>
        /// Describes the way the axes will be associated to each other. This is used in conjunction  with COUPLED_AXES to indicate the way they are interacting. The possible values are: TANDEM, SYNCHRONOUS, MASTER, and SLAVE. The coupling MUST be viewed from the perspective of the axis, therefore a MASTER coupling indicates that this axis is the master of the COUPLED_AXES.
        /// </summary>
        AXIS_COUPLING,
        /// <summary>
        /// The block of code being executed. Block contains the entire expression for a line of  program code.
        /// </summary>
        BLOCK,
        [Obsolete("Deprecated in Rel 1.1.0")]
        CODE,
        /// <summary>
        /// The current mode of the Controller. AUTOMATIC, MANUAL,  MANUAL_DATA_INPUT, or SEMI_AUTOMATIC.
        /// </summary>
        CONTROLLER_MODE,
        /// <summary>
        /// Refers to the set of associated axes. The value will be a space delimited set of axes names.
        /// </summary>
        COUPLED_AXES,
        /// <summary>
        /// The direction of motion. CLOCKWISE or COUNTER_CLOCKWISE. See <c>subType</c>s: <seealso cref="DirectionSubTypes"/>
        /// </summary>
        DIRECTION,
        /// <summary>
        /// The direction of motion of a linear device. POSTIVE or NEGATIVE
        /// </summary>
        DOOR_STATE,
        /// <summary>
        /// The current state of the emergency stop actuator. ARMED (the circuit is complete and the  device is operating) or TRIGGERED (the circuit is open and the device MUST cease operation).
        /// </summary>
        EMERGENCY_STOP,
        /// <summary>
        /// The execution status of the Controller. READY, ACTIVE, INTERRUPTED,  FEED_HOLD, or STOPPED
        /// </summary>
        EXECUTION,
        /// <summary>
        /// The current line of code being executed. See <c>subType</c>s: <seealso cref="LineSubTypes"/>
        /// </summary>
        LINE,
        /// <summary>
        /// An uninterpreted textual notification. 
        /// </summary>
        MESSAGE,
        /// <summary>
        /// The identifier for the pallet currently in use for a given Path
        /// </summary>
        PALLET_ID,
        /// <summary>
        /// The current count of parts produced as represented by the Controller. MUST be  integer value. See <c>subType</c>s: <seealso cref="PartCountSubTypes"/>
        /// </summary>
        PART_COUNT,
        /// <summary>
        /// An identifier of the current part in the device 
        /// </summary>
        PART_ID,
        /// <summary>
        /// The operational mode for this Path. SYNCHRONOUS, MIRROR, or INDEPENDENT.  Default value is INDEPENDENT if not specified.
        /// </summary>
        PATH_MODE,
        /// <summary>
        /// The ON or OFF status of the Component. DEPRECATION WARNING: MAY be  deprecated in the future. See <c>subType</c>s: <seealso cref="PowerStateSubTypes"/>
        /// </summary>
        POWER_STATE,
        [Obsolete("Deprecated in Rel. 1.1")]
        POWER_STATUS,
        /// <summary>
        /// The name of the program being executed 
        /// </summary>
        PROGRAM,
        /// <summary>
        /// The mode for the Rotary axis. SPINDLE, INDEX, or CONTOUR.
        /// </summary>
        ROTARY_MODE,
        [Obsolete("Deprecated in Rel. 1.2. See TOOL_ASSET_ID.")]
        TOOL_ID,
        /// <summary>
        /// The identifier of an individual tool asset. 
        /// </summary>
        TOOL_ASSET_ID,
        /// <summary>
        /// The identifier of a tool provided by the device controller.
        /// </summary>
        TOOL_NUMBER,
        /// <summary>
        /// The identifier for the workholding currently in use for a given Path
        /// </summary>
        WORKHOLDING_ID
    }
}
