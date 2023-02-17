﻿using MtconnectCore.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums;
using System;

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
		[MTConnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		ACTIVE_AXES,
		/// <summary>
		﻿/// {{def(EventEnum:ACTUATOR_STATE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		ACTUATOR_STATE,
		/// <summary>
		﻿/// {{def(EventEnum:ALARM)}}
		/// </summary>
		[Obsolete("Deprecated according to https://model.mtconnect.org/")]
		[MTConnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/", MtconnectVersions.V_1_1_0)]
		ALARM,
		/// <summary>
		﻿/// {{def(EventEnum:ASSET_CHANGED)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		ASSET_CHANGED,
		/// <summary>
		﻿/// {{def(EventEnum:ASSET_REMOVED)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		ASSET_REMOVED,
		/// <summary>
		﻿/// {{def(EventEnum:AVAILABILITY)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		AVAILABILITY,
		/// <summary>
		﻿/// {{def(EventEnum:AXIS_COUPLING)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		AXIS_COUPLING,
		/// <summary>
		﻿/// {{def(EventEnum:AXIS_FEEDRATE_OVERRIDE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		AXIS_FEEDRATE_OVERRIDE,
		/// <summary>
		﻿/// {{def(EventEnum:AXIS_INTERLOCK)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		AXIS_INTERLOCK,
		/// <summary>
		﻿/// {{def(EventEnum:AXIS_STATE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		AXIS_STATE,
		/// <summary>
		﻿/// {{def(EventEnum:BLOCK)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		BLOCK,
		/// <summary>
		﻿/// {{def(EventEnum:BLOCK_COUNT)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		BLOCK_COUNT,
		/// <summary>
		﻿/// {{def(EventEnum:CHUCK_INTERLOCK)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		CHUCK_INTERLOCK,
		/// <summary>
		﻿/// {{def(EventEnum:CHUCK_STATE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		CHUCK_STATE,
		/// <summary>
		﻿/// {{def(EventEnum:CODE)}}
		/// </summary>
		[Obsolete("Deprecated according to https://model.mtconnect.org/")]
		[MTConnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/", MtconnectVersions.V_1_1_0)]
		CODE,
		/// <summary>
		﻿/// {{def(EventEnum:COMPOSITION_STATE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		COMPOSITION_STATE,
		/// <summary>
		﻿/// {{def(EventEnum:CONTROLLER_MODE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		CONTROLLER_MODE,
		/// <summary>
		﻿/// {{def(EventEnum:CONTROLLER_MODE_OVERRIDE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		CONTROLLER_MODE_OVERRIDE,
		/// <summary>
		﻿/// {{def(EventEnum:COUPLED_AXES)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		COUPLED_AXES,
		/// <summary>
		﻿/// {{def(EventEnum:DATE_CODE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		DATE_CODE,
		/// <summary>
		﻿/// {{def(EventEnum:DEVICE_UUID)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		DEVICE_UUID,
		/// <summary>
		﻿/// {{def(EventEnum:DIRECTION)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		DIRECTION,
		/// <summary>
		﻿/// {{def(EventEnum:DOOR_STATE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		DOOR_STATE,
		/// <summary>
		﻿/// {{def(EventEnum:EMERGENCY_STOP)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		EMERGENCY_STOP,
		/// <summary>
		﻿/// {{def(EventEnum:END_OF_BAR)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		END_OF_BAR,
		/// <summary>
		﻿/// {{def(EventEnum:EQUIPMENT_MODE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		EQUIPMENT_MODE,
		/// <summary>
		﻿/// {{def(EventEnum:EXECUTION)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		EXECUTION,
		/// <summary>
		﻿/// {{def(EventEnum:FUNCTIONAL_MODE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		FUNCTIONAL_MODE,
		/// <summary>
		﻿/// {{def(EventEnum:HARDNESS)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		HARDNESS,
		/// <summary>
		﻿/// {{def(EventEnum:LINE)}}
		/// </summary>
		[Obsolete("Deprecated according to https://model.mtconnect.org/")]
		[MTConnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/", MtconnectVersions.V_1_4_0)]
		LINE,
		/// <summary>
		﻿/// {{def(EventEnum:LINE_LABEL)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		LINE_LABEL,
		/// <summary>
		﻿/// {{def(EventEnum:LINE_NUMBER)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		LINE_NUMBER,
		/// <summary>
		﻿/// {{def(EventEnum:MATERIAL)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		MATERIAL,
		/// <summary>
		﻿/// {{def(EventEnum:MATERIAL_LAYER)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		MATERIAL_LAYER,
		/// <summary>
		﻿/// {{def(EventEnum:MESSAGE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		MESSAGE,
		/// <summary>
		﻿/// {{def(EventEnum:OPERATOR_ID)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		OPERATOR_ID,
		/// <summary>
		﻿/// {{def(EventEnum:PALLET_ID)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		PALLET_ID,
		/// <summary>
		﻿/// {{def(EventEnum:PART_COUNT)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		PART_COUNT,
		/// <summary>
		﻿/// {{def(EventEnum:PART_DETECT)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		PART_DETECT,
		/// <summary>
		﻿/// {{def(EventEnum:PART_ID)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		PART_ID,
		/// <summary>
		﻿/// {{def(EventEnum:PART_NUMBER)}}
		/// </summary>
		[Obsolete("Deprecated according to https://model.mtconnect.org/")]
		[MTConnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/", MtconnectVersions.V_1_7_0)]
		PART_NUMBER,
		/// <summary>
		﻿/// {{def(EventEnum:PATH_FEEDRATE_OVERRIDE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		PATH_FEEDRATE_OVERRIDE,
		/// <summary>
		﻿/// {{def(EventEnum:PATH_MODE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		PATH_MODE,
		/// <summary>
		﻿/// {{def(EventEnum:POWER_STATE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		POWER_STATE,
		/// <summary>
		﻿/// {{def(EventEnum:POWER_STATUS)}}
		/// </summary>
		[Obsolete("Deprecated according to https://model.mtconnect.org/")]
		[MTConnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/", MtconnectVersions.V_1_1_0)]
		POWER_STATUS,
		/// <summary>
		﻿/// {{def(EventEnum:PROCESS_TIME)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		PROCESS_TIME,
		/// <summary>
		﻿/// {{def(EventEnum:PROGRAM)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		PROGRAM,
		/// <summary>
		﻿/// {{def(EventEnum:PROGRAM_COMMENT)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		PROGRAM_COMMENT,
		/// <summary>
		﻿/// {{def(EventEnum:PROGRAM_EDIT)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		PROGRAM_EDIT,
		/// <summary>
		﻿/// {{def(EventEnum:PROGRAM_EDIT_NAME)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		PROGRAM_EDIT_NAME,
		/// <summary>
		﻿/// {{def(EventEnum:PROGRAM_HEADER)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		PROGRAM_HEADER,
		/// <summary>
		﻿/// {{def(EventEnum:PROGRAM_LOCATION)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		PROGRAM_LOCATION,
		/// <summary>
		﻿/// {{def(EventEnum:PROGRAM_LOCATION_TYPE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		PROGRAM_LOCATION_TYPE,
		/// <summary>
		﻿/// {{def(EventEnum:PROGRAM_NEST_LEVEL)}}  If an initial value is not defined, the nesting level associated with the highest or initial nesting level of the program <b>MUST</b> default to zero (0). 
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		PROGRAM_NEST_LEVEL,
		/// <summary>
		﻿/// {{def(EventEnum:ROTARY_MODE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		ROTARY_MODE,
		/// <summary>
		﻿/// {{def(EventEnum:ROTARY_VELOCITY_OVERRIDE)}}  This command represents a percentage change to the velocity calculated by a logic or motion program or set by a switch for a <see cref="Rotary">Rotary</see> type axis.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		ROTARY_VELOCITY_OVERRIDE,
		/// <summary>
		﻿/// {{def(EventEnum:SERIAL_NUMBER)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		SERIAL_NUMBER,
		/// <summary>
		﻿/// {{def(EventEnum:SPINDLE_INTERLOCK)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		SPINDLE_INTERLOCK,
		/// <summary>
		﻿/// {{def(EventEnum:TOOL_ASSET_ID)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		TOOL_ASSET_ID,
		/// <summary>
		﻿/// {{def(EventEnum:TOOL_GROUP)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		TOOL_GROUP,
		/// <summary>
		﻿/// {{def(EventEnum:TOOL_ID)}}
		/// </summary>
		[Obsolete("Deprecated according to https://model.mtconnect.org/")]
		[MTConnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/", MtconnectVersions.V_1_2_0)]
		TOOL_ID,
		/// <summary>
		﻿/// {{def(EventEnum:TOOL_NUMBER)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		TOOL_NUMBER,
		/// <summary>
		﻿/// {{def(EventEnum:TOOL_OFFSET)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		TOOL_OFFSET,
		/// <summary>
		﻿/// {{def(EventEnum:USER)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		USER,
		/// <summary>
		﻿/// {{def(EventEnum:VARIABLE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		VARIABLE,
		/// <summary>
		﻿/// {{def(EventEnum:WAIT_STATE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		WAIT_STATE,
		/// <summary>
		﻿/// {{def(EventEnum:WIRE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		WIRE,
		/// <summary>
		﻿/// {{def(EventEnum:WORKHOLDING_ID)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		WORKHOLDING_ID,
		/// <summary>
		﻿/// {{def(EventEnum:WORK_OFFSET)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		WORK_OFFSET,
		/// <summary>
		﻿/// {{def(EventEnum:OPERATING_SYSTEM)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		OPERATING_SYSTEM,
		/// <summary>
		﻿/// {{def(EventEnum:FIRMWARE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		FIRMWARE,
		/// <summary>
		﻿/// {{def(EventEnum:APPLICATION)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		APPLICATION,
		/// <summary>
		﻿/// {{def(EventEnum:LIBRARY)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		LIBRARY,
		/// <summary>
		﻿/// {{def(EventEnum:HARDWARE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		HARDWARE,
		/// <summary>
		﻿/// {{def(EventEnum:NETWORK)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		NETWORK,
		/// <summary>
		﻿/// {{def(EventEnum:ROTATION)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		ROTATION,
		/// <summary>
		﻿/// {{def(EventEnum:TRANSLATION)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		TRANSLATION,
		/// <summary>
		﻿/// {{def(EventEnum:PROCESS_KIND_ID)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		PROCESS_KIND_ID,
		/// <summary>
		﻿/// {{def(EventEnum:PART_STATUS)}}  If unique identifier is given, part status is for that individual. If group identifier is given without a unique identifier, then the status is assumed to be for the whole group.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		PART_STATUS,
		/// <summary>
		﻿/// {{def(EventEnum:ALARM_LIMIT)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		ALARM_LIMIT,
		/// <summary>
		﻿/// {{def(EventEnum:PROCESS_AGGREGATE_ID)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		PROCESS_AGGREGATE_ID,
		/// <summary>
		﻿/// {{def(EventEnum:PART_KIND_ID)}}  If no {{property(subType)}} is specified, <c>UUID</c> is default. 
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		PART_KIND_ID,
		/// <summary>
		﻿/// {{def(EventEnum:ADAPTER_URI)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		ADAPTER_U_R_I,
		/// <summary>
		﻿/// {{def(EventEnum:DEVICE_REMOVED)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		DEVICE_REMOVED,
		/// <summary>
		﻿/// {{def(EventEnum:DEVICE_CHANGED)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		DEVICE_CHANGED,
		/// <summary>
		﻿/// {{def(EventEnum:SPECIFICATION_LIMIT)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		SPECIFICATION_LIMIT,
		/// <summary>
		﻿/// {{def(EventEnum:CONNECTION_STATUS)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		CONNECTION_STATUS,
		/// <summary>
		﻿/// {{def(EventEnum:ADAPTER_SOFTWARE_VERSION)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		ADAPTER_SOFTWARE_VERSION,
		/// <summary>
		﻿/// {{def(EventEnum:SENSOR_ATTACHMENT)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		SENSOR_ATTACHMENT,
		/// <summary>
		﻿/// {{def(EventEnum:CONTROL_LIMIT)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		CONTROL_LIMIT,
		/// <summary>
		﻿/// {{def(EventEnum:DEVICE_ADDED)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		DEVICE_ADDED,
		/// <summary>
		﻿/// {{def(EventEnum:MTCONNECT_VERSION)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		M_T_CONNECT_VERSION,
		/// <summary>
		﻿/// {{def(EventEnum:PROCESS_OCCURRENCE_ID)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		PROCESS_OCCURRENCE_ID,
		/// <summary>
		﻿/// {{def(EventEnum:PART_GROUP_ID)}}  If no {{property(subType)}} is specified, <c>UUID</c> is default.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		PART_GROUP_ID,
		/// <summary>
		﻿/// {{def(EventEnum:PART_UNIQUE_ID)}}  If no {{property(subType)}} is specified, <c>UUID</c> is default. 
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		PART_UNIQUE_ID,
		/// <summary>
		﻿/// {{def(EventEnum:ACTIVATION_COUNT)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		ACTIVATION_COUNT,
		/// <summary>
		﻿/// {{def(EventEnum:DEACTIVATION_COUNT)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		DEACTIVATION_COUNT,
		/// <summary>
		﻿/// {{def(EventEnum:TRANSFER_COUNT)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		TRANSFER_COUNT,
		/// <summary>
		﻿/// {{def(EventEnum:LOAD_COUNT)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		LOAD_COUNT,
		/// <summary>
		﻿/// {{def(EventEnum:PART_PROCESSING_STATE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		PART_PROCESSING_STATE,
		/// <summary>
		﻿/// {{def(EventEnum:PROCESS_STATE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		PROCESS_STATE,
		/// <summary>
		﻿/// {{def(EventEnum:VALVE_STATE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		VALVE_STATE,
		/// <summary>
		﻿/// {{def(EventEnum:LOCK_STATE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		LOCK_STATE,
		/// <summary>
		﻿/// {{def(EventEnum:UNLOAD_COUNT)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		UNLOAD_COUNT,
		/// <summary>
		﻿/// {{def(EventEnum:CYCLE_COUNT)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		CYCLE_COUNT,
		/// <summary>
		﻿/// {{def(EventEnum:OPERATING_MODE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/")]
		OPERATING_MODE,
		/// <summary>
		﻿/// {{def(EventEnum:ASSET_COUNT)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/")]
		ASSET_COUNT,
		/// <summary>
		﻿/// {{def(EventEnum:MAINTENANCE_LIST)}}  If the {{property(INTERVAL)}} {{property(key)}} is not provided, it is assumed <c>ABSOLUTE</c>.  If the {{property(DIRECTION)}} {{property(key)}} is not provided, it is assumed <c>UP</c>.  If the {{property(UNITS)}} {{property(key)}} is not provided, it is assumed to be <c>COUNT</c>.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/")]
		MAINTENANCE_LIST,
		/// <summary>
		﻿/// {{def(EventEnum:FIXTURE_ID)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/")]
		FIXTURE_ID,
		/// <summary>
		﻿/// {{def(EventEnum:PART_COUNT_TYPE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/")]
		PART_COUNT_TYPE,
		/// <summary>
		﻿/// {{def(EventEnum:CLOCK_TIME)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		CLOCK_TIME,
		/// <summary>
		﻿/// {{def(EventEnum:NETWORK_PORT)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		NETWORK_PORT,
		/// <summary>
		﻿/// {{def(EventEnum:HOST_NAME)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		HOST_NAME,
		/// <summary>
		﻿/// {{def(EventEnum:LEAK_DETECT)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		LEAK_DETECT,
		/// <summary>
		﻿/// {{def(EventEnum:BATTERY_STATE)}}
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		BATTERY_STATE,
	}
}