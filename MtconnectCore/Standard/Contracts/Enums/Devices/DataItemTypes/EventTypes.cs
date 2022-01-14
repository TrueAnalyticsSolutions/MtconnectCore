using MtconnectCore.Standard.Contracts.Attributes;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.2")]
    public enum EventTypes {
        /// <summary>
        /// The state of the Actuator - ACTIVE or INACTIVE.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.11")]
        ACTUATOR_STATE,
        [Obsolete("Deprecated in Rel. 1.1. Replaced with CONDITION.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.2", MtconnectVersions.V_1_0_1)]
        ALARM,
        /// <summary>
        /// The set of axes associated with a Path that the Controller is controlling. If  DataItem is not provided, it will be assumed the Controller is controlling all axes.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2")]
        ACTIVE_AXES,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 4.1")]
        ASSET_CHANGED,
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
        /// The block of code being executed. Block contains the entire expression for a line of  program code.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.2")]
        BLOCK,
        [Obsolete("Deprecated in Rel 1.1.0")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.2", MtconnectVersions.V_1_0_1)]
        CODE,
        /// <summary>
        /// The current mode of the Controller. AUTOMATIC, MANUAL,  MANUAL_DATA_INPUT, or SEMI_AUTOMATIC.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.2")]
        CONTROLLER_MODE,
        /// <summary>
        /// Refers to the set of associated axes. The value will be a space delimited set of axes names.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2")]
        COUPLED_AXES,
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
        /// The current state of the emergency stop actuator. ARMED (the circuit is complete and the  device is operating) or TRIGGERED (the circuit is open and the device MUST cease operation).
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2")]
        EMERGENCY_STOP,
        /// <summary>
        /// The execution status of the Controller. READY, ACTIVE, INTERRUPTED,  FEED_HOLD, or STOPPED
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.2")]
        EXECUTION,
        /// <summary>
        /// The current line of code being executed. See <c>subType</c>s: <seealso cref="LineSubTypes"/>
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.2")]
        LINE,
        /// <summary>
        /// An uninterpreted textual notification. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2")]
        MESSAGE,
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
        /// An identifier of the current part in the device 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2")]
        PART_ID,
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
        /// The name of the program being executed 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2")]
        PROGRAM,
        /// <summary>
        /// The mode for the Rotary axis. SPINDLE, INDEX, or CONTOUR.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2")]
        ROTARY_MODE,
        [Obsolete("Deprecated in Rel. 1.2. See TOOL_ASSET_ID.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2", MtconnectVersions.V_1_1_0)]
        TOOL_ID,
        /// <summary>
        /// The identifier of an individual tool asset. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.11")]
        TOOL_ASSET_ID,
        /// <summary>
        /// The identifier of a tool provided by the device controller.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.11")]
        TOOL_NUMBER,
        /// <summary>
        /// The identifier for the workholding currently in use for a given Path
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2")]
        WORKHOLDING_ID,
    }
}
