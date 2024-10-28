#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums
{
	/// <summary>
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Enumeration__EAID_8FEC81E4_8E1F_4f45_820B_F9F25DD83F9A">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.5.0.0")]
	public enum UnitEnum
	{
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />electric current in ampere.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		AMPERE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />temperature in degree Celsius.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		CELSIUS,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />count of something.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		COUNT,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />angle in degree.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		DEGREE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />angular velocity in degree per second.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		DEGREE_PER_SECOND,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />angular acceleration in degree per second squared.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		DEGREE_PER_SECOND_SQUARED,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />frequency in cycles per second.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		HERTZ,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />mass in kilogram.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		KILOGRAM,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />volume in liter.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		LITER,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />length in millimeter.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		MILLIMETER,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />speed in millimeter per second.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		MILLIMETER_PER_SECOND,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />acceleration in millimeter per second squared.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		MILLIMETER_PER_SECOND_SQUARED,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />force in newton.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		NEWTON,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />torque in newton-meter.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		NEWTON_METER,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />pressure or stress in pascal.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		PASCAL,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />amount in or for every hundred.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		PERCENT,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />rotational velocity in revolution per minute.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		REVOLUTION_PER_MINUTE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />time in second.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		SECOND,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />electric potential, electric potential difference or electromotive force in volt.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		VOLT,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />power in watt.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		WATT,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />energy in joule.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		JOULE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />point in space identified by X, Y, and Z positions and represented by a space-delimited set of numbers each expressed in millimeters.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		MILLIMETER_3D,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />acidity or alkalinity of a solution in pH.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		PH,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />rotational velocity in revolution per second.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		REVOLUTION_PER_SECOND,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />sound level in decibel.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		DECIBEL,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />mass in gram.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		GRAM,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />volumetric flow in liter per second.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		LITER_PER_SECOND,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />tilt in micro radian.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		MICRO_RADIAN,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />electrical resistance in ohm.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		OHM,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />viscosity in pascal-second.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		PASCAL_SECOND,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />electrical conductivity in siemens per meter.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		SIEMENS_PER_METER,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />apparent power in an electrical circuit, equal to the product of root-mean-square (RMS) voltage and RMS current (commonly referred to as VA) in volt-ampere.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		VOLT_AMPERE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />reactive power in an AC electrical circuit (commonly referred to as VAR) in volt-ampere-reactive.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		VOLT_AMPERE_REACTIVE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />electrical energy in watt-second<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		WATT_SECOND,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />geometric volume in millimeter.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		CUBIC_MILLIMETER,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />change of geometric volume per second.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		CUBIC_MILLIMETER_PER_SECOND,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />change in geometric volume per second squared.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		CUBIC_MILLIMETER_PER_SECOND_SQUARED,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />mass in milligram.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		MILLIGRAM,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />density in milligram per cubic millimeter.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		MILLIGRAM_PER_CUBIC_MILLIMETER,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />volume in milliliter.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		MILLILITER,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />feedrate per revolution in millimeter per revolution.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		MILLIMETER_PER_REVOLUTION,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />space-delimited, floating-point representation of the angular rotation in degrees around the X, Y, and Z axes relative to a cartesian coordinate system respectively in order as A, B, and C. <br /><br /><br /><br />If any of the rotations is not known, it <b>MUST</b> be zero (0).<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		DEGREE_3D,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />density in gram per cubic meter.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		GRAM_PER_CUBIC_METER,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />rotational acceleration in revolution per second squared.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		REVOLUTION_PER_SECOND_SQUARED,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />frequency in count per second.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		COUNT_PER_SECOND,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />pressurization rate in pascal per second.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		PASCAL_PER_SECOND,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />3D Unit Vector.<br /><br /><br /><br />Space delimited list of three floating point numbers.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		UNIT_VECTOR_3D,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />electric charge in coulomb.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.1">v2.1</see></item>
		/// </list>
		/// </remarks>
		COULOMB,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />acceleration in meter per second squared.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.1">v2.1</see></item>
		/// </list>
		/// </remarks>
		METER_PER_SECOND_SQUARED,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />geometric volume in meter.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.4">v2.4</see></item>
		/// </list>
		/// </remarks>
		CUBIC_METER,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />geometric area in millimeter.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.4">v2.4</see></item>
		/// </list>
		/// </remarks>
		SQUARE_MILLIMETER,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />resistivity in ohm-meter.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.5">v2.5</see></item>
		/// </list>
		/// </remarks>
		OHM_METER,
	}
}