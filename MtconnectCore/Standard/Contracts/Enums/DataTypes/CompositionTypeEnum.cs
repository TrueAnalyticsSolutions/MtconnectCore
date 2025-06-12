#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums
{
	/// <summary>
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Enumeration___19_0_3_45f01b9_1580312281115_595828_44604">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.5.0.0")]
	public enum CompositionTypeEnum
	{
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a mechanism that moves or controls a mechanical part of a piece of equipment.<br /><br /><br /><br />It takes energy usually provided by air, electric current, or liquid and converts the energy into some kind of motion. <br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		ACTUATOR,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of an electronic component or circuit that amplifies power, electric current, or voltage.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		AMPLIFIER,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a mechanical structure that transforms rotary motion into linear motion.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		BALLSCREW,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of an endless flexible band that transmits motion for a piece of equipment or conveys materials and objects.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		BELT,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a mechanism that slows down or stops a moving object by the absorption or transfer of the energy of momentum, usually by means of friction, electrical force, or magnetic force.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		BRAKE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of an interconnected series of objects that band together and transmit motion for a piece of equipment or to convey materials and objects.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		CHAIN,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a mechanism that breaks material into smaller pieces.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		CHOPPER,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a mechanism that holds a part, stock material, or any other item in place.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		CHUCK,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of an inclined channel that conveys material.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		CHUTE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a mechanism that interrupts an electric circuit.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		CIRCUIT_BREAKER,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a mechanism that strengthens, supports, or fastens objects in place.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		CLAMP,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a pump or other mechanism that reduces volume and increases pressure of gases in order to condense the gases to drive pneumatically powered pieces of equipment.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		COMPRESSOR,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a mechanical mechanism or closure that covers a physical access portal into a piece of equipment allowing or restricting access to other parts of the equipment.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		DOOR,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a mechanism that allows material to flow for the purpose of drainage from, for example, a vessel or tank.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		DRAIN,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a mechanism that measures rotary position.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		ENCODER,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a mechanism that produces a current of air.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		FAN,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a substance or structure that allows liquids or gases to pass through to remove suspended impurities or to recover solids.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		FILTER,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a mechanism that holds a part, stock material, or any other item in place.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		GRIPPER,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a chamber or bin that stores materials temporarily, typically being filled through the top and dispensed through the bottom.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		HOPPER,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a mechanism that measures linear motion or position.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		LINEAR_POSITION_FEEDBACK,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a mechanism that converts electrical, pneumatic, or hydraulic energy into mechanical energy.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		MOTOR,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a viscous liquid.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		OIL,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a unit that provides power to electric mechanisms.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		POWER_SUPPLY,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a mechanism or wheel that turns in a frame or block and serves to change the direction of or to transmit force.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		PULLEY,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of an apparatus that raises, drives, exhausts, or compresses fluids or gases by means of a piston, plunger, or set of rotating vanes.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		PUMP,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a mechanism that provides a signal or measured value.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		SENSING_ELEMENT,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of one or more cells that converts chemical energy to electricity and serves as a source of power. <br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		STORAGE_BATTERY,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a mechanism that turns on or off an electric current or makes or breaks a circuit.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		SWITCH,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a receptacle or container that holds material.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		TANK,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a mechanism that provides or applies a stretch or strain to another mechanism.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		TENSIONER,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a mechanism that halts or controls the flow of a liquid, gas, or other material through a passage, pipe, inlet, or outlet.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		VALVE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a fluid.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		WATER,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a string like piece or filament of relatively rigid or flexible material provided in a variety of diameters.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		WIRE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a mechanism that emits a type of radiation.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		EXPOSURE_UNIT,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a mechanism that dispenses liquid or powered materials.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		EXTRUSION_UNIT,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of an electromechanical actuator that produces deflection of a beam of light or energy in response to electric current through its coil in a magnetic field.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		GALVANOMOTOR,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a rotary storage unit for material.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		REEL,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a mechanism that flattens or spreads materials.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		SPREADER,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a surface that holds an object or material.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		TABLE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a mechanism that transforms electric energy from a source to a secondary circuit.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		TRANSFORMER,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a container for liquid or powdered materials.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		VAT,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of an object or material on which a form of work is performed.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		
		WORKPIECE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a heat exchange system that uses a fluid to transfer heat to the atmosphere.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		COOLING_TOWER,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Pot">Pot</see> for a tool that is no longer usable for removal from a <see cref="ToolMagazine">ToolMagazine</see> or <see cref="Turret">Turret</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		EXPIRED_POT,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a tool storage location associated with a <see cref="ToolMagazine">ToolMagazine</see> or <see cref="AutomaticToolChanger">AutomaticToolChanger</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		POT,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Pot">Pot</see> for a tool to be removed from a <see cref="ToolMagazine">ToolMagazine</see> or <see cref="Turret">Turret</see> to a location outside of the piece of equipment.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		REMOVAL_POT,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Pot">Pot</see> for a tool removed from <i>spindle</i> or <see cref="Turret">Turret</see> and awaiting for return to a <see cref="ToolMagazine">ToolMagazine</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		RETURN_POT,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Pot">Pot</see> for a tool awaiting transfer to a <see cref="ToolMagazine">ToolMagazine</see> or <see cref="Turret">Turret</see> from outside of the piece of equipment.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		STAGING_POT,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a storage or mounting location for a tool associated with a <see cref="Turret">Turret</see>, <see cref="GangToolBar">GangToolBar</see>, or <see cref="ToolRack">ToolRack</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		STATION,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Composition">Composition</see> composed of a mechanism that physically moves a tool from one location to another.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		TRANSFER_ARM,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Pot">Pot</see> for a tool awaiting transfer from a <see cref="ToolMagazine">ToolMagazine</see> to <i>spindle</i> or <see cref="Turret">Turret</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		TRANSFER_POT,
	}
}