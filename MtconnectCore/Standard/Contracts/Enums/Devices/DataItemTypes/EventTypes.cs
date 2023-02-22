using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum EventTypes
	{
		/// <summary>
		﻿/// {{def(EventEnum:ACTIVE_AXES)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		ACTIVE_AXES,
		/// <summary>
		﻿/// {{def(EventEnum:ACTUATOR_STATE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(ActuatorStateValues))]
		ACTUATOR_STATE,
		/// <summary>
		﻿/// {{def(EventEnum:ALARM)}}
		/// </summary>
		[Obsolete("Deprecated according to https://model.mtconnect.org/")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/", MtconnectVersions.V_1_1_0)]
		ALARM,
		/// <summary>
		﻿/// {{def(EventEnum:ASSET_CHANGED)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		ASSET_CHANGED,
		/// <summary>
		﻿/// {{def(EventEnum:ASSET_REMOVED)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		ASSET_REMOVED,
		/// <summary>
		﻿/// {{def(EventEnum:AVAILABILITY)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(AvailabilityValues))]
		AVAILABILITY,
		/// <summary>
		﻿/// {{def(EventEnum:AXIS_COUPLING)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(AxisCouplingValues))]
		AXIS_COUPLING,
		/// <summary>
		﻿/// {{def(EventEnum:AXIS_FEEDRATE_OVERRIDE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(AxisFeedrateOverrideSubTypes))]
		AXIS_FEEDRATE_OVERRIDE,
		/// <summary>
		﻿/// {{def(EventEnum:AXIS_INTERLOCK)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(AxisInterlockValues))]
		AXIS_INTERLOCK,
		/// <summary>
		﻿/// {{def(EventEnum:AXIS_STATE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(AxisStateValues))]
		AXIS_STATE,
		/// <summary>
		﻿/// {{def(EventEnum:BLOCK)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		BLOCK,
		/// <summary>
		﻿/// {{def(EventEnum:BLOCK_COUNT)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		BLOCK_COUNT,
		/// <summary>
		﻿/// {{def(EventEnum:CHUCK_INTERLOCK)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(ChuckInterlockSubTypes))]
		[ObservationalValue(typeof(ChuckInterlockValues))]
		CHUCK_INTERLOCK,
		/// <summary>
		﻿/// {{def(EventEnum:CHUCK_STATE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(ChuckStateValues))]
		CHUCK_STATE,
		/// <summary>
		﻿/// {{def(EventEnum:CODE)}}
		/// </summary>
		[Obsolete("Deprecated according to https://model.mtconnect.org/")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/", MtconnectVersions.V_1_1_0)]
		CODE,
		/// <summary>
		﻿/// {{def(EventEnum:COMPOSITION_STATE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(CompositionStateSubTypes))]
		COMPOSITION_STATE,
		/// <summary>
		﻿/// {{def(EventEnum:CONTROLLER_MODE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(ControllerModeValues))]
		CONTROLLER_MODE,
		/// <summary>
		﻿/// {{def(EventEnum:CONTROLLER_MODE_OVERRIDE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(ControllerModeOverrideSubTypes))]
		[ObservationalValue(typeof(ControllerModeOverrideValues))]
		CONTROLLER_MODE_OVERRIDE,
		/// <summary>
		﻿/// {{def(EventEnum:COUPLED_AXES)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		COUPLED_AXES,
		/// <summary>
		﻿/// {{def(EventEnum:DATE_CODE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(DateCodeSubTypes))]
		DATE_CODE,
		/// <summary>
		﻿/// {{def(EventEnum:DEVICE_UUID)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		DEVICE_UUID,
		/// <summary>
		﻿/// {{def(EventEnum:DIRECTION)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(DirectionSubTypes))]
		[ObservationalValue(typeof(DirectionValues))]
		DIRECTION,
		/// <summary>
		﻿/// {{def(EventEnum:DOOR_STATE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(DoorStateValues))]
		DOOR_STATE,
		/// <summary>
		﻿/// {{def(EventEnum:EMERGENCY_STOP)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(EmergencyStopValues))]
		EMERGENCY_STOP,
		/// <summary>
		﻿/// {{def(EventEnum:END_OF_BAR)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(EndOfBarSubTypes))]
		[ObservationalValue(typeof(EndOfBarValues))]
		END_OF_BAR,
		/// <summary>
		﻿/// {{def(EventEnum:EQUIPMENT_MODE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(EquipmentModeSubTypes))]
		[ObservationalValue(typeof(EquipmentModeValues))]
		EQUIPMENT_MODE,
		/// <summary>
		﻿/// {{def(EventEnum:EXECUTION)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(ExecutionValues))]
		EXECUTION,
		/// <summary>
		﻿/// {{def(EventEnum:FUNCTIONAL_MODE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(FunctionalModeValues))]
		FUNCTIONAL_MODE,
		/// <summary>
		﻿/// {{def(EventEnum:HARDNESS)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(HardnessSubTypes))]
		HARDNESS,
		/// <summary>
		﻿/// {{def(EventEnum:LINE)}}
		/// </summary>
		[Obsolete("Deprecated according to https://model.mtconnect.org/")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/", MtconnectVersions.V_1_4_0)]
		[ObservationalSubType(typeof(LineSubTypes))]
		LINE,
		/// <summary>
		﻿/// {{def(EventEnum:LINE_LABEL)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		LINE_LABEL,
		/// <summary>
		﻿/// {{def(EventEnum:LINE_NUMBER)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(LineNumberSubTypes))]
		LINE_NUMBER,
		/// <summary>
		﻿/// {{def(EventEnum:MATERIAL)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		MATERIAL,
		/// <summary>
		﻿/// {{def(EventEnum:MATERIAL_LAYER)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(MaterialLayerSubTypes))]
		MATERIAL_LAYER,
		/// <summary>
		﻿/// {{def(EventEnum:MESSAGE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		MESSAGE,
		/// <summary>
		﻿/// {{def(EventEnum:OPERATOR_ID)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		OPERATOR_ID,
		/// <summary>
		﻿/// {{def(EventEnum:PALLET_ID)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		PALLET_ID,
		/// <summary>
		﻿/// {{def(EventEnum:PART_COUNT)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(PartCountSubTypes))]
		PART_COUNT,
		/// <summary>
		﻿/// {{def(EventEnum:PART_DETECT)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(PartDetectValues))]
		PART_DETECT,
		/// <summary>
		﻿/// {{def(EventEnum:PART_ID)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		PART_ID,
		/// <summary>
		﻿/// {{def(EventEnum:PART_NUMBER)}}
		/// </summary>
		[Obsolete("Deprecated according to https://model.mtconnect.org/")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/", MtconnectVersions.V_1_7_0)]
		PART_NUMBER,
		/// <summary>
		﻿/// {{def(EventEnum:PATH_FEEDRATE_OVERRIDE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(PathFeedrateOverrideSubTypes))]
		PATH_FEEDRATE_OVERRIDE,
		/// <summary>
		﻿/// {{def(EventEnum:PATH_MODE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(PathModeValues))]
		PATH_MODE,
		/// <summary>
		﻿/// {{def(EventEnum:POWER_STATE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(PowerStateSubTypes))]
		[ObservationalValue(typeof(PowerStateValues))]
		POWER_STATE,
		/// <summary>
		﻿/// {{def(EventEnum:POWER_STATUS)}}
		/// </summary>
		[Obsolete("Deprecated according to https://model.mtconnect.org/")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/", MtconnectVersions.V_1_1_0)]
		[ObservationalValue(typeof(PowerStatusValues))]
		POWER_STATUS,
		/// <summary>
		﻿/// {{def(EventEnum:PROCESS_TIME)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(ProcessTimeSubTypes))]
		PROCESS_TIME,
		/// <summary>
		﻿/// {{def(EventEnum:PROGRAM)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(ProgramSubTypes))]
		PROGRAM,
		/// <summary>
		﻿/// {{def(EventEnum:PROGRAM_COMMENT)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(ProgramCommentSubTypes))]
		PROGRAM_COMMENT,
		/// <summary>
		﻿/// {{def(EventEnum:PROGRAM_EDIT)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(ProgramEditValues))]
		PROGRAM_EDIT,
		/// <summary>
		﻿/// {{def(EventEnum:PROGRAM_EDIT_NAME)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		PROGRAM_EDIT_NAME,
		/// <summary>
		﻿/// {{def(EventEnum:PROGRAM_HEADER)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(ProgramHeaderSubTypes))]
		PROGRAM_HEADER,
		/// <summary>
		﻿/// {{def(EventEnum:PROGRAM_LOCATION)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(ProgramLocationSubTypes))]
		PROGRAM_LOCATION,
		/// <summary>
		﻿/// {{def(EventEnum:PROGRAM_LOCATION_TYPE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(ProgramLocationTypeSubTypes))]
		[ObservationalValue(typeof(ProgramLocationTypeValues))]
		PROGRAM_LOCATION_TYPE,
		/// <summary>
		﻿/// {{def(EventEnum:PROGRAM_NEST_LEVEL)}}  If an initial value is not defined, the nesting level associated with the highest or initial nesting level of the program <b>MUST</b> default to zero (0). 
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		PROGRAM_NEST_LEVEL,
		/// <summary>
		﻿/// {{def(EventEnum:ROTARY_MODE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(RotaryModeValues))]
		ROTARY_MODE,
		/// <summary>
		﻿/// {{def(EventEnum:ROTARY_VELOCITY_OVERRIDE)}}  This command represents a percentage change to the velocity calculated by a logic or motion program or set by a switch for a <see cref="Rotary">Rotary</see> type axis.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		ROTARY_VELOCITY_OVERRIDE,
		/// <summary>
		﻿/// {{def(EventEnum:SERIAL_NUMBER)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		SERIAL_NUMBER,
		/// <summary>
		﻿/// {{def(EventEnum:SPINDLE_INTERLOCK)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(SpindleInterlockValues))]
		SPINDLE_INTERLOCK,
		/// <summary>
		﻿/// {{def(EventEnum:TOOL_ASSET_ID)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		TOOL_ASSET_ID,
		/// <summary>
		﻿/// {{def(EventEnum:TOOL_GROUP)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		TOOL_GROUP,
		/// <summary>
		﻿/// {{def(EventEnum:TOOL_ID)}}
		/// </summary>
		[Obsolete("Deprecated according to https://model.mtconnect.org/")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/", MtconnectVersions.V_1_2_0)]
		TOOL_ID,
		/// <summary>
		﻿/// {{def(EventEnum:TOOL_NUMBER)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		TOOL_NUMBER,
		/// <summary>
		﻿/// {{def(EventEnum:TOOL_OFFSET)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(ToolOffsetSubTypes))]
		TOOL_OFFSET,
		/// <summary>
		﻿/// {{def(EventEnum:USER)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(UserSubTypes))]
		USER,
		/// <summary>
		﻿/// {{def(EventEnum:VARIABLE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		VARIABLE,
		/// <summary>
		﻿/// {{def(EventEnum:WAIT_STATE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(WaitStateValues))]
		WAIT_STATE,
		/// <summary>
		﻿/// {{def(EventEnum:WIRE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		WIRE,
		/// <summary>
		﻿/// {{def(EventEnum:WORKHOLDING_ID)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		WORKHOLDING_ID,
		/// <summary>
		﻿/// {{def(EventEnum:WORK_OFFSET)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		WORK_OFFSET,
		/// <summary>
		﻿/// {{def(EventEnum:OPERATING_SYSTEM)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(OperatingSystemSubTypes))]
		OPERATING_SYSTEM,
		/// <summary>
		﻿/// {{def(EventEnum:FIRMWARE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(FirmwareSubTypes))]
		FIRMWARE,
		/// <summary>
		﻿/// {{def(EventEnum:APPLICATION)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(ApplicationSubTypes))]
		APPLICATION,
		/// <summary>
		﻿/// {{def(EventEnum:LIBRARY)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(LibrarySubTypes))]
		LIBRARY,
		/// <summary>
		﻿/// {{def(EventEnum:HARDWARE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(HardwareSubTypes))]
		HARDWARE,
		/// <summary>
		﻿/// {{def(EventEnum:NETWORK)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(NetworkSubTypes))]
		NETWORK,
		/// <summary>
		﻿/// {{def(EventEnum:ROTATION)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		ROTATION,
		/// <summary>
		﻿/// {{def(EventEnum:TRANSLATION)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		TRANSLATION,
		/// <summary>
		﻿/// {{def(EventEnum:PROCESS_KIND_ID)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(ProcessKindIdSubTypes))]
		PROCESS_KIND_ID,
		/// <summary>
		﻿/// {{def(EventEnum:PART_STATUS)}}  If unique identifier is given, part status is for that individual. If group identifier is given without a unique identifier, then the status is assumed to be for the whole group.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(PartStatusValues))]
		PART_STATUS,
		/// <summary>
		﻿/// {{def(EventEnum:ALARM_LIMIT)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		ALARM_LIMIT,
		/// <summary>
		﻿/// {{def(EventEnum:PROCESS_AGGREGATE_ID)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(ProcessAggregateIdSubTypes))]
		PROCESS_AGGREGATE_ID,
		/// <summary>
		﻿/// {{def(EventEnum:PART_KIND_ID)}}  If no {{property(subType)}} is specified, <c>UUID</c> is default. 
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(PartKindIdSubTypes))]
		PART_KIND_ID,
		/// <summary>
		﻿/// {{def(EventEnum:ADAPTER_URI)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		ADAPTER_U_R_I,
		/// <summary>
		﻿/// {{def(EventEnum:DEVICE_REMOVED)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		DEVICE_REMOVED,
		/// <summary>
		﻿/// {{def(EventEnum:DEVICE_CHANGED)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		DEVICE_CHANGED,
		/// <summary>
		﻿/// {{def(EventEnum:SPECIFICATION_LIMIT)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		SPECIFICATION_LIMIT,
		/// <summary>
		﻿/// {{def(EventEnum:CONNECTION_STATUS)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(ConnectionStatusValues))]
		CONNECTION_STATUS,
		/// <summary>
		﻿/// {{def(EventEnum:ADAPTER_SOFTWARE_VERSION)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		ADAPTER_SOFTWARE_VERSION,
		/// <summary>
		﻿/// {{def(EventEnum:SENSOR_ATTACHMENT)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		SENSOR_ATTACHMENT,
		/// <summary>
		﻿/// {{def(EventEnum:CONTROL_LIMIT)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		CONTROL_LIMIT,
		/// <summary>
		﻿/// {{def(EventEnum:DEVICE_ADDED)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		DEVICE_ADDED,
		/// <summary>
		﻿/// {{def(EventEnum:MTCONNECT_VERSION)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		M_T_CONNECT_VERSION,
		/// <summary>
		﻿/// {{def(EventEnum:PROCESS_OCCURRENCE_ID)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(ProcessOccurrenceIdSubTypes))]
		PROCESS_OCCURRENCE_ID,
		/// <summary>
		﻿/// {{def(EventEnum:PART_GROUP_ID)}}  If no {{property(subType)}} is specified, <c>UUID</c> is default.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(PartGroupIdSubTypes))]
		PART_GROUP_ID,
		/// <summary>
		﻿/// {{def(EventEnum:PART_UNIQUE_ID)}}  If no {{property(subType)}} is specified, <c>UUID</c> is default. 
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(PartUniqueIdSubTypes))]
		PART_UNIQUE_ID,
		/// <summary>
		﻿/// {{def(EventEnum:ACTIVATION_COUNT)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(ActivationCountSubTypes))]
		ACTIVATION_COUNT,
		/// <summary>
		﻿/// {{def(EventEnum:DEACTIVATION_COUNT)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(DeactivationCountSubTypes))]
		DEACTIVATION_COUNT,
		/// <summary>
		﻿/// {{def(EventEnum:TRANSFER_COUNT)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(TransferCountSubTypes))]
		TRANSFER_COUNT,
		/// <summary>
		﻿/// {{def(EventEnum:LOAD_COUNT)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(LoadCountSubTypes))]
		LOAD_COUNT,
		/// <summary>
		﻿/// {{def(EventEnum:PART_PROCESSING_STATE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(PartProcessingStateValues))]
		PART_PROCESSING_STATE,
		/// <summary>
		﻿/// {{def(EventEnum:PROCESS_STATE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(ProcessStateValues))]
		PROCESS_STATE,
		/// <summary>
		﻿/// {{def(EventEnum:VALVE_STATE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(ValveStateSubTypes))]
		[ObservationalValue(typeof(ValveStateValues))]
		VALVE_STATE,
		/// <summary>
		﻿/// {{def(EventEnum:LOCK_STATE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(LockStateValues))]
		LOCK_STATE,
		/// <summary>
		﻿/// {{def(EventEnum:UNLOAD_COUNT)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(UnloadCountSubTypes))]
		UNLOAD_COUNT,
		/// <summary>
		﻿/// {{def(EventEnum:CYCLE_COUNT)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		[ObservationalSubType(typeof(CycleCountSubTypes))]
		CYCLE_COUNT,
		/// <summary>
		﻿/// {{def(EventEnum:OPERATING_MODE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(OperatingModeValues))]
		OPERATING_MODE,
		/// <summary>
		﻿/// {{def(EventEnum:ASSET_COUNT)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/")]
		ASSET_COUNT,
		/// <summary>
		﻿/// {{def(EventEnum:MAINTENANCE_LIST)}}  If the {{property(INTERVAL)}} {{property(key)}} is not provided, it is assumed <c>ABSOLUTE</c>.  If the {{property(DIRECTION)}} {{property(key)}} is not provided, it is assumed <c>UP</c>.  If the {{property(UNITS)}} {{property(key)}} is not provided, it is assumed to be <c>COUNT</c>.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/")]
		MAINTENANCE_LIST,
		/// <summary>
		﻿/// {{def(EventEnum:FIXTURE_ID)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/")]
		FIXTURE_ID,
		/// <summary>
		﻿/// {{def(EventEnum:PART_COUNT_TYPE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(PartCountTypeValues))]
		PART_COUNT_TYPE,
		/// <summary>
		﻿/// {{def(EventEnum:CLOCK_TIME)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		CLOCK_TIME,
		/// <summary>
		﻿/// {{def(EventEnum:NETWORK_PORT)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		NETWORK_PORT,
		/// <summary>
		﻿/// {{def(EventEnum:HOST_NAME)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		HOST_NAME,
		/// <summary>
		﻿/// {{def(EventEnum:LEAK_DETECT)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(LeakDetectValues))]
		LEAK_DETECT,
		/// <summary>
		﻿/// {{def(EventEnum:BATTERY_STATE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		[ObservationalValue(typeof(BatteryStateValues))]
		BATTERY_STATE,
	}
}