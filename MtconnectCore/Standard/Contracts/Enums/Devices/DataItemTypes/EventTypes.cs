#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_">v</see></item>
	/// <item><b>Deprecated</b>: <see href="https://model.mtconnect.org/#_Version_">v</see></item>
	/// </list>
	/// </remarks>
	[Obsolete("Deprecated in v according to https://model.mtconnect.org/#_Version_")]
	
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.4.0.0")]
	public enum EventTypes
	{
		/// <summary>
		﻿/// set of axes currently associated with a <see cref="Path">Path</see> or <see cref="Controller">Controller</see>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1")]
		
		
		ACTIVE_AXES,
		/// <summary>
		﻿/// operational state of an apparatus for moving or controlling a mechanism or system.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		
		
		ACTUATOR_STATE,
		/// <summary>
		﻿/// <b>DEPRECATED:</b> Replaced with <c>CONDITION</c> category data items in Version 1.1.0.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// <item><b>Deprecated</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[Obsolete("Deprecated in v1.1 according to https://model.mtconnect.org/#_Version_1.1")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0", MtconnectVersions.V_1_1_0)]
		
		
		ALARM,
		/// <summary>
		﻿/// <see cref="assetId">assetId</see> of the <i>Asset</i> that has been added or changed.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		
		
		ASSET_CHANGED,
		/// <summary>
		﻿/// <see cref="assetId">assetId</see> of the <i>Asset</i> that has been removed.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#_Version_1.3")]
		
		
		ASSET_REMOVED,
		/// <summary>
		﻿/// <i>agent</i>'s ability to communicate with the data source.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1")]
		
		
		AVAILABILITY,
		/// <summary>
		﻿/// describes the way the axes will be associated to each other. <br />  <br />This is used in conjunction with <c>COUPLED_AXES</c> to indicate the way they are interacting.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1")]
		
		
		AXIS_COUPLING,
		/// <summary>
		﻿/// value of a signal or calculation issued to adjust the feedrate of an individual linear type axis.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#_Version_1.3")]
		[ObservationalSubType(typeof(AxisFeedrateOverrideSubTypes))]
		
		AXIS_FEEDRATE_OVERRIDE,
		/// <summary>
		﻿/// state of the axis lockout function when power has been removed and the axis is allowed to move freely.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#_Version_1.3")]
		
		
		AXIS_INTERLOCK,
		/// <summary>
		﻿/// state of a <see cref="Linear">Linear</see> or <see cref="Rotary">Rotary</see> component representing an axis.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#_Version_1.3")]
		
		
		AXIS_STATE,
		/// <summary>
		﻿/// line of code or command being executed by a <see cref="Controller">Controller</see> entity.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
		
		
		BLOCK,
		/// <summary>
		﻿/// total count of the number of blocks of program code that have been executed since execution started.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		
		BLOCK_COUNT,
		/// <summary>
		﻿/// state of an interlock function or control logic state intended to prevent the associated <see cref="Chuck">Chuck</see> component from being operated.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#_Version_1.3")]
		
		
		CHUCK_INTERLOCK,
		/// <summary>
		﻿/// operating state of a mechanism that holds a part or stock material during a manufacturing process. <br /><br />It may also represent a mechanism that holds any other mechanism in place within a piece of equipment.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#_Version_1.3")]
		
		
		CHUCK_STATE,
		/// <summary>
		﻿/// programmatic code being executed.<br /><br /><b>DEPRECATED</b> in <i>Version 1.1</i>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// <item><b>Deprecated</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[Obsolete("Deprecated in v1.1 according to https://model.mtconnect.org/#_Version_1.1")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0", MtconnectVersions.V_1_1_0)]
		
		
		CODE,
		/// <summary>
		﻿/// operating state of a mechanism represented by a <see cref="Composition">Composition</see> entity.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		[ObservationalSubType(typeof(CompositionStateSubTypes))]
		
		COMPOSITION_STATE,
		/// <summary>
		﻿/// current mode of the <see cref="Controller">Controller</see> component.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
		
		
		CONTROLLER_MODE,
		/// <summary>
		﻿/// setting or operator selection that changes the behavior of a piece of equipment.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		
		CONTROLLER_MODE_OVERRIDE,
		/// <summary>
		﻿/// set of associated axes.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		
		
		COUPLED_AXES,
		/// <summary>
		﻿/// time and date code associated with a material or other physical item.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		[ObservationalSubType(typeof(DateCodeSubTypes))]
		
		DATE_CODE,
		/// <summary>
		﻿/// identifier of another piece of equipment that is temporarily associated with a component of this piece of equipment to perform a particular function.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		
		DEVICE_UUID,
		/// <summary>
		﻿/// direction of motion.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
		
		
		DIRECTION,
		/// <summary>
		﻿/// operational state of a <see cref="Door">Door</see> component or composition element.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1")]
		
		
		DOOR_STATE,
		/// <summary>
		﻿/// state of the emergency stop signal for a piece of equipment, controller path, or any other component or subsystem of a piece of equipment.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1")]
		
		
		EMERGENCY_STOP,
		/// <summary>
		﻿/// indication of whether the end of a piece of bar stock being feed by a bar feeder has been reached.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#_Version_1.3")]
		
		
		END_OF_BAR,
		/// <summary>
		﻿/// indication that a piece of equipment, or a sub-part of a piece of equipment, is performing specific types of activities.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		
		EQUIPMENT_MODE,
		/// <summary>
		﻿/// operating state of a <see cref="Component">Component</see>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
		
		
		EXECUTION,
		/// <summary>
		﻿/// current intended production status of the <see cref="Component">Component</see>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#_Version_1.3")]
		
		
		FUNCTIONAL_MODE,
		/// <summary>
		﻿/// hardness of a material.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		[ObservationalSubType(typeof(HardnessSubTypes))]
		
		HARDNESS,
		/// <summary>
		﻿/// current line of code being executed.<br /><br /><b>DEPRECATED</b> in <i>Version 1.4.0</i>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// <item><b>Deprecated</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[Obsolete("Deprecated in v1.4 according to https://model.mtconnect.org/#_Version_1.4")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0", MtconnectVersions.V_1_4_0)]
		[ObservationalSubType(typeof(LineSubTypes))]
		
		LINE,
		/// <summary>
		﻿/// identifier for a <see cref="Block">Block</see> of code in a <see cref="Program">Program</see>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		
		LINE_LABEL,
		/// <summary>
		﻿/// position of a block of program code within a control program.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		[ObservationalSubType(typeof(LineNumberSubTypes))]
		
		LINE_NUMBER,
		/// <summary>
		﻿/// identifier of a material used or consumed in the manufacturing process.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		
		MATERIAL,
		/// <summary>
		﻿/// identifies the layers of material applied to a part or product as part of an additive manufacturing process.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		[ObservationalSubType(typeof(MaterialLayerSubTypes))]
		
		MATERIAL_LAYER,
		/// <summary>
		﻿/// information to be transferred from a piece of equipment to a client software application.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1")]
		
		
		MESSAGE,
		/// <summary>
		﻿/// identifier of the person currently responsible for operating the piece of equipment.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#_Version_1.3")]
		
		
		OPERATOR_ID,
		/// <summary>
		﻿/// identifier for a pallet.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		
		
		PALLET_ID,
		/// <summary>
		﻿/// aggregate count of parts.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
		[ObservationalSubType(typeof(PartCountSubTypes))]
		
		PART_COUNT,
		/// <summary>
		﻿/// indication designating whether a part or work piece has been detected or is present.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		
		PART_DETECT,
		/// <summary>
		﻿/// identifier of a part in a manufacturing operation.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1")]
		
		
		PART_ID,
		/// <summary>
		﻿/// identifier of a part or product moving through the manufacturing process.<br /><br /><b>DEPRECATED</b> in <i>Version 1.7</i>. <c>PART_NUMBER</c> is now a <c>subType</c> of <c>PART_KIND_ID</c>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// <item><b>Deprecated</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[Obsolete("Deprecated in v1.7 according to https://model.mtconnect.org/#_Version_1.7")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4", MtconnectVersions.V_1_7_0)]
		
		
		PART_NUMBER,
		/// <summary>
		﻿/// value of a signal or calculation issued to adjust the feedrate for the axes associated with a <see cref="Path">Path</see> component that may represent a single axis or the coordinated movement of multiple axes.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#_Version_1.3")]
		[ObservationalSubType(typeof(PathFeedrateOverrideSubTypes))]
		
		PATH_FEEDRATE_OVERRIDE,
		/// <summary>
		﻿/// describes the operational relationship between a <see cref="Path">Path</see> entity and another <see cref="Path">Path</see> entity for pieces of equipment comprised of multiple logical groupings of controlled axes or other logical operations.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1")]
		
		
		PATH_MODE,
		/// <summary>
		﻿/// indication of the status of the source of energy for an entity to allow it to perform its intended function or the state of an enabling signal providing permission for the entity to perform its functions.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1")]
		
		
		POWER_STATE,
		/// <summary>
		﻿/// status of the <see cref="Component">Component</see>.<br /><br /><b>DEPRECATED</b> in <i>Version 1.1.0</i>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// <item><b>Deprecated</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[Obsolete("Deprecated in v1.1 according to https://model.mtconnect.org/#_Version_1.1")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0", MtconnectVersions.V_1_1_0)]
		
		
		POWER_STATUS,
		/// <summary>
		﻿/// time and date associated with an activity or event.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		[ObservationalSubType(typeof(ProcessTimeSubTypes))]
		
		PROCESS_TIME,
		/// <summary>
		﻿/// name of the logic or motion program being executed by the <see cref="Controller">Controller</see> component.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
		[ObservationalSubType(typeof(ProgramSubTypes))]
		
		PROGRAM,
		/// <summary>
		﻿/// comment or non-executable statement in the control program.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#_Version_1.3")]
		[ObservationalSubType(typeof(ProgramCommentSubTypes))]
		
		PROGRAM_COMMENT,
		/// <summary>
		﻿/// indication of the status of the <see cref="Controller">Controller</see> components program editing mode.<br /><br />A program may be edited while another is executed.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#_Version_1.3")]
		
		
		PROGRAM_EDIT,
		/// <summary>
		﻿/// name of the program being edited. <br /><br />This is used in conjunction with <see cref="ProgramEdit">ProgramEdit</see> when in <c>ACTIVE</c> state. 
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#_Version_1.3")]
		
		
		PROGRAM_EDIT_NAME,
		/// <summary>
		﻿/// non-executable header section of the control program.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#_Version_1.3")]
		[ObservationalSubType(typeof(ProgramHeaderSubTypes))]
		
		PROGRAM_HEADER,
		/// <summary>
		﻿/// <i>URI</i> for the source file associated with <see cref="Program">Program</see>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		[ObservationalSubType(typeof(ProgramLocationSubTypes))]
		
		PROGRAM_LOCATION,
		/// <summary>
		﻿/// defines whether the logic or motion program defined by <see cref="Program">Program</see> is being executed from the local memory of the controller or from an outside source.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		
		PROGRAM_LOCATION_TYPE,
		/// <summary>
		﻿/// indication of the nesting level within a control program that is associated with the code or instructions that is currently being executed.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		
		PROGRAM_NEST_LEVEL,
		/// <summary>
		﻿/// current operating mode for a <see cref="Rotary">Rotary</see> type axis.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1")]
		
		
		ROTARY_MODE,
		/// <summary>
		﻿/// percentage change to the velocity of the programmed velocity for a <see cref="Rotary">Rotary</see> axis.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#_Version_1.3")]
		
		
		ROTARY_VELOCITY_OVERRIDE,
		/// <summary>
		﻿/// serial number associated with a <see cref="Component">Component</see>, <see cref="Asset">Asset</see>, or <see cref="Device">Device</see>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		
		SERIAL_NUMBER,
		/// <summary>
		﻿/// indication of the status of the spindle for a piece of equipment when power has been removed and it is free to rotate.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#_Version_1.3")]
		
		
		SPINDLE_INTERLOCK,
		/// <summary>
		﻿/// identifier of an individual tool asset.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		
		
		TOOL_ASSET_ID,
		/// <summary>
		﻿/// identifier for the tool group associated with a specific tool. Commonly used to designate spare tools.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		
		TOOL_GROUP,
		/// <summary>
		﻿/// identifier of the tool currently in use for a given <c>Path</c>.<br /><br /><b>DEPRECATED</b> in <i>Version 1.2.0</i>.   See <c>TOOL_ASSET_ID</c>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// <item><b>Deprecated</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[Obsolete("Deprecated in v1.2 according to https://model.mtconnect.org/#_Version_1.2")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1", MtconnectVersions.V_1_2_0)]
		
		
		TOOL_ID,
		/// <summary>
		﻿/// identifier assigned by the <see cref="Controller">Controller</see> component to a cutting tool when in use by a piece of equipment.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		
		
		TOOL_NUMBER,
		/// <summary>
		﻿/// reference to the tool offset variables applied to the active cutting tool.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		[ObservationalSubType(typeof(ToolOffsetSubTypes))]
		
		TOOL_OFFSET,
		/// <summary>
		﻿/// identifier of the person currently responsible for operating the piece of equipment.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		[ObservationalSubType(typeof(UserSubTypes))]
		
		USER,
		/// <summary>
		﻿/// data whose meaning may change over time due to changes in the operation of a piece of equipment or the process being executed on that piece of equipment.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		
		VARIABLE,
		/// <summary>
		﻿/// indication of the reason that <see cref="Execution">Execution</see> is reporting a value of <c>WAIT</c>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		
		WAIT_STATE,
		/// <summary>
		﻿/// identifier for the type of wire used as the cutting mechanism in Electrical Discharge Machining or similar processes.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		
		WIRE,
		/// <summary>
		﻿/// identifier for the current workholding or part clamp in use by a piece of equipment.<br /><br /><b>DEPRECATION WARNING</b>: Recommend using <c>FIXTURE_ID</c> instead.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1")]
		
		
		WORKHOLDING_ID,
		/// <summary>
		﻿/// reference to offset variables for a work piece or part.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		
		WORK_OFFSET,
		/// <summary>
		﻿/// Operating System (OS) of a <see cref="Component">Component</see>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		[ObservationalSubType(typeof(OperatingSystemSubTypes))]
		
		OPERATING_SYSTEM,
		/// <summary>
		﻿/// embedded software of a <see cref="Component">Component</see><br />.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		[ObservationalSubType(typeof(FirmwareSubTypes))]
		
		FIRMWARE,
		/// <summary>
		﻿/// application on a <see cref="Component">Component</see>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		[ObservationalSubType(typeof(ApplicationSubTypes))]
		
		APPLICATION,
		/// <summary>
		﻿/// software library on a <see cref="Component">Component</see>
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		[ObservationalSubType(typeof(LibrarySubTypes))]
		
		LIBRARY,
		/// <summary>
		﻿/// hardware of a <see cref="Component">Component</see>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		[ObservationalSubType(typeof(HardwareSubTypes))]
		
		HARDWARE,
		/// <summary>
		﻿/// network details of a <see cref="Component">Component</see>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		[ObservationalSubType(typeof(NetworkSubTypes))]
		
		NETWORK,
		/// <summary>
		﻿/// three space angular displacement of an object or coordinate system relative to a <i>cartesian coordinate system</i>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		
		
		ROTATION,
		/// <summary>
		﻿/// three space linear displacement of an object or coordinate system relative to a <i>cartesian coordinate system</i>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		
		
		TRANSLATION,
		/// <summary>
		﻿/// identifier given to link the individual occurrence to a class of processes or process definition.<br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		[ObservationalSubType(typeof(ProcessKindIdSubTypes))]
		
		PROCESS_KIND_ID,
		/// <summary>
		﻿/// state or condition of a part.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		
		PART_STATUS,
		/// <summary>
		﻿/// set of limits used to trigger warning or alarm indicators.<br /><br /><b>DEPRECATION WARNING</b>. Recommend using <c>ALARM_LIMITS</c>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		
		ALARM_LIMIT,
		/// <summary>
		﻿/// identifier given to link the individual occurrence to a group of related occurrences, such as a process step in a process plan.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		[ObservationalSubType(typeof(ProcessAggregateIdSubTypes))]
		
		PROCESS_AGGREGATE_ID,
		/// <summary>
		﻿/// identifier given to link the individual occurrence to a class of parts, typically distinguished by a particular part design.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		[ObservationalSubType(typeof(PartKindIdSubTypes))]
		
		PART_KIND_ID,
		/// <summary>
		﻿/// <i>URI</i> of the <i>adapter</i>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		
		ADAPTER_URI,
		/// <summary>
		﻿/// <i>UUID</i> of a device removed from an <i>MTConnect Agent</i>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		
		DEVICE_REMOVED,
		/// <summary>
		﻿/// <i>UUID</i> of the device whose <i>metadata</i> has changed.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		
		DEVICE_CHANGED,
		/// <summary>
		﻿/// set of limits defining a range of values designating acceptable performance for a variable.<br /><br /><b>DEPRECATION WARNING</b>. Recommend using <c>SPECIFICATION_LIMITS</c>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		
		SPECIFICATION_LIMIT,
		/// <summary>
		﻿/// status of the connection between an <i>adapter</i> and an <i>agent</i>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		
		CONNECTION_STATUS,
		/// <summary>
		﻿/// originator’s software version of the <i>adapter</i>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		
		ADAPTER_SOFTWARE_VERSION,
		/// <summary>
		﻿/// <i>attachment</i> between a sensor and an entity.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		
		SENSOR_ATTACHMENT,
		/// <summary>
		﻿/// set of limits used to indicate whether a process variable is stable and in control.<br /><br /><b>DEPRECATION WARNING</b>. Recommend using <c>CONTROL_LIMITS</c>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		
		CONTROL_LIMIT,
		/// <summary>
		﻿/// <i>UUID</i> of new device added to an <i>MTConnect Agent</i>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		
		DEVICE_ADDED,
		/// <summary>
		﻿/// reference version of the MTConnect Standard supported by the <i>adapter</i>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		
		MTCONNECT_VERSION,
		/// <summary>
		﻿/// identifier of a process being executed by the device.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		[ObservationalSubType(typeof(ProcessOccurrenceIdSubTypes))]
		
		PROCESS_OCCURRENCE_ID,
		/// <summary>
		﻿/// identifier given to a collection of individual parts. 
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		[ObservationalSubType(typeof(PartGroupIdSubTypes))]
		
		PART_GROUP_ID,
		/// <summary>
		﻿/// identifier given to a distinguishable, individual part. 
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		[ObservationalSubType(typeof(PartUniqueIdSubTypes))]
		
		PART_UNIQUE_ID,
		/// <summary>
		﻿/// accumulation of the number of times a function has attempted to, or is planned to attempt to, activate or be performed.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.8">v1.8</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/#_Version_1.8")]
		[ObservationalSubType(typeof(ActivationCountSubTypes))]
		
		ACTIVATION_COUNT,
		/// <summary>
		﻿/// accumulation of the number of times a function has attempted to, or is planned to attempt to, deactivate or cease.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.8">v1.8</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/#_Version_1.8")]
		[ObservationalSubType(typeof(DeactivationCountSubTypes))]
		
		DEACTIVATION_COUNT,
		/// <summary>
		﻿/// accumulation of the number of times an operation has attempted to, or is planned to attempt to, transfer materials, parts, or other items from one location to another.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.8">v1.8</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/#_Version_1.8")]
		[ObservationalSubType(typeof(TransferCountSubTypes))]
		
		TRANSFER_COUNT,
		/// <summary>
		﻿/// accumulation of the number of times an operation has attempted to, or is planned to attempt to, load materials, parts, or other items.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.8">v1.8</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/#_Version_1.8")]
		[ObservationalSubType(typeof(LoadCountSubTypes))]
		
		LOAD_COUNT,
		/// <summary>
		﻿/// particular condition of the part occurrence at a specific time.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.8">v1.8</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/#_Version_1.8")]
		
		
		PART_PROCESSING_STATE,
		/// <summary>
		﻿/// particular condition of the process occurrence at a specific time.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.8">v1.8</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/#_Version_1.8")]
		
		
		PROCESS_STATE,
		/// <summary>
		﻿/// state of a valve is one of open, closed, or transitioning between the states.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.8">v1.8</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/#_Version_1.8")]
		
		
		VALVE_STATE,
		/// <summary>
		﻿/// state or operating mode of a <see cref="Lock">Lock</see>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.8">v1.8</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/#_Version_1.8")]
		
		
		LOCK_STATE,
		/// <summary>
		﻿/// accumulation of the number of times an operation has attempted to, or is planned to attempt to, unload materials, parts, or other items.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.8">v1.8</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/#_Version_1.8")]
		[ObservationalSubType(typeof(UnloadCountSubTypes))]
		
		UNLOAD_COUNT,
		/// <summary>
		﻿/// accumulation of the number of times a cyclic function has attempted to, or is planned to attempt to execute.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.8">v1.8</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/#_Version_1.8")]
		[ObservationalSubType(typeof(CycleCountSubTypes))]
		
		CYCLE_COUNT,
		/// <summary>
		﻿/// state of <see cref="Component">Component</see> or <see cref="Composition">Composition</see> that describes the automatic or manual operation of the entity.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.0">v2.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/#_Version_2.0")]
		
		
		OPERATING_MODE,
		/// <summary>
		﻿/// <i>data set</i> of the number of <i>Asset</i>s of a given type for a <i>Device</i>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.0">v2.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/#_Version_2.0")]
		
		
		ASSET_COUNT,
		/// <summary>
		﻿/// actions or activities to be performed in support of a piece of equipment.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.0">v2.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/#_Version_2.0")]
		
		
		MAINTENANCE_LIST,
		/// <summary>
		﻿/// identifier for the current workholding or part clamp in use by a piece of equipment.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.0">v2.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/#_Version_2.0")]
		
		
		FIXTURE_ID,
		/// <summary>
		﻿/// interpretation of <c>PART_COUNT</c>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.0">v2.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/#_Version_2.0")]
		
		
		PART_COUNT_TYPE,
		/// <summary>
		﻿/// time provided by a timing device at a specific point in time.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		
		
		CLOCK_TIME,
		/// <summary>
		﻿/// number of the TCP/IP or UDP/IP port for the connection endpoint.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.1">v2.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/#_Version_2.1")]
		
		
		NETWORK_PORT,
		/// <summary>
		﻿/// name of the host computer supplying data.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.1">v2.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/#_Version_2.1")]
		
		
		HOST_NAME,
		/// <summary>
		﻿/// indication designating whether a leak has been detected.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.1">v2.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/#_Version_2.1")]
		
		
		LEAK_DETECT,
		/// <summary>
		﻿/// present status of the battery.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.1">v2.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/#_Version_2.1")]
		
		
		BATTERY_STATE,
		/// <summary>
		﻿/// <see cref="EventEnum.FEATURE_PERSISTENT_ID">EventEnum.FEATURE_PERSISTENT_ID</see>
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		
		
		FEATURE_PERSISITENT_ID,
		/// <summary>
		﻿/// detection result of a sensor.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		[ObservationalSubType(typeof(SensorStateSubTypes))]
		
		SENSOR_STATE,
		/// <summary>
		﻿/// <see cref="Event">Event</see> that represents a <see cref="Component">Component</see> where the <see cref="EntryDefinition">EntryDefinition</see> identifies the <see cref="Component">Component</see> and the <see cref="CellDefinition">CellDefinition</see>s define the <see cref="Component">Component</see>'s observed <see cref="DataItem">DataItem</see>s.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		
		
		COMPONENT_DATA,
		/// <summary>
		﻿/// properties of each addressable work offset.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		
		
		WORK_OFFSETS,
		/// <summary>
		﻿/// properties of each addressable tool offset.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		
		
		TOOL_OFFSETS,
		/// <summary>
		﻿/// assessing elements of a <i>feature</i>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		
		
		FEATURE_MEASUREMENT,
		/// <summary>
		﻿/// <i>UUID</i> of the <i>characteristic</i>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		
		
		CHARACTERISTIC_PERSISTENT_ID,
		/// <summary>
		﻿/// class of measurement being performed. <seealso href="https://www.google.com/search?q=QIF 3:2018 Section 6.3&amp;btnI=I">QIF 3:2018 Section 6.3</seealso>
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		
		
		MEASUREMENT_TYPE,
		/// <summary>
		﻿/// measurement based on the measurement type.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		
		
		MEASUREMENT_VALUE,
		/// <summary>
		﻿/// engineering units of the measurement.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		
		
		MEASUREMENT_UNITS,
		/// <summary>
		﻿/// pass/fail result of the measurement.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		
		
		CHARACTERISTIC_STATUS,
		/// <summary>
		﻿/// method used to compute <i>standard uncertainty</i>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		
		
		UNCERTAINTY_TYPE,
		/// <summary>
		﻿/// <i>uncertainty</i> specified by <see cref="UncertaintyType">UncertaintyType</see>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		
		
		UNCERTAINTY,
		/// <summary>
		﻿/// set of limits used to trigger warning or alarm indicators.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.3">v2.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_3_0, "https://model.mtconnect.org/#_Version_2.3")]
		
		
		ALARM_LIMITS,
		/// <summary>
		﻿/// set of limits used to indicate whether a process variable is stable and in control.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.3">v2.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_3_0, "https://model.mtconnect.org/#_Version_2.3")]
		
		
		CONTROL_LIMITS,
		/// <summary>
		﻿/// set of limits defining a range of values designating acceptable performance for a variable.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.3">v2.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_3_0, "https://model.mtconnect.org/#_Version_2.3")]
		
		
		SPECIFICATION_LIMITS,
		/// <summary>
		﻿/// references the <see cref="CuttingToolLifeCycle">CuttingToolLifeCycle</see> <see cref="CuttingItem">CuttingItem</see> index related to the <see cref="CuttingItem.indices">indices in CuttingItem</see> of the currently active cutting tool edge.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.3">v2.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_3_0, "https://model.mtconnect.org/#_Version_2.3")]
		
		
		TOOL_CUTTING_ITEM,
		/// <summary>
		﻿/// structured information that allows the unambiguous determination of an object for purposes of identification and location. <seealso href="https://www.google.com/search?q=ISO 19160-4:2017&amp;btnI=I">ISO 19160-4:2017</seealso>
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.3">v2.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_3_0, "https://model.mtconnect.org/#_Version_2.3")]
		
		
		LOCATION_ADDRESS,
		/// <summary>
		﻿/// active energy source for the <see cref="Component">Component</see>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.3">v2.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_3_0, "https://model.mtconnect.org/#_Version_2.3")]
		[ObservationalSubType(typeof(PowerSourceSubTypes))]
		
		POWER_SOURCE,
	}
}