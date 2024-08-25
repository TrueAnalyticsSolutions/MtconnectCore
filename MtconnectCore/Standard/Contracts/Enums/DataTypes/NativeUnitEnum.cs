#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums
{
	/// <summary>
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Enumeration__EAID_678122A4_E8FD_4243_8427_6B7E0E78D5F5">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.4.0.0")]
	public enum NativeUnitEnum
	{
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />rotational velocity in degrees per minute.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		DEGREE_PER_MINUTE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />temperature in Fahrenheit.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		FAHRENHEIT,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />feet.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		FOOT,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />point in space identified by X, Y, and Z positions and represented by a space-delimited set of numbers each expressed in feet.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		FOOT_3D,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />feet per minute.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		FOOT_PER_MINUTE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />feet per second.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		FOOT_PER_SECOND,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />acceleration in feet per second squared.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		FOOT_PER_SECOND_SQUARED,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />gallons per minute.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		GALLON_PER_MINUTE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />inches.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		INCH,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />point in space identified by X, Y, and Z positions and represented by a space-delimited set of numbers each expressed in inches.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		INCH_3D,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />measure of torque in inch pounds.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		INCH_POUND,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />inches per minute.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		INCH_PER_MINUTE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />inches per second.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		INCH_PER_SECOND,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />acceleration in inches per second squared.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		INCH_PER_SECOND_SQUARED,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />measurement in kilowatt.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		KILOWATT,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />kilowatt hours which is 3.6 mega joules.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		KILOWATT_HOUR,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />velocity in millimeters per minute.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		MILLIMETER_PER_MINUTE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />unsupported unit.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		OTHER,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />US pounds.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		POUND,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />pressure in pounds per square inch (PSI).<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		POUND_PER_INCH_SQUARED,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />angle in radians.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		RADIAN,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />velocity in radians per minute.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		RADIAN_PER_MINUTE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />rotational acceleration in radian per second squared.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		RADIAN_PER_SECOND,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />rotational acceleration in radian per second squared.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		RADIAN_PER_SECOND_SQUARED,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />measure of viscosity.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		CENTIPOISE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />measurement of rate of flow of a fluid.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		LITER_PER_MINUTE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />measurement of temperature.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		KELVIN,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />measurement of time in hours.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		HOUR,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />measurement of time in minutes.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		MINUTE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />pressure in Bar.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		BAR,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />pressure in Millimeter of Mercury (mmHg).<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		MILLIMETER_MERCURY,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />pascal per minute.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		PASCAL_PER_MINUTE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />pressure in Torr.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		TORR,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />electric charge in ampere hour.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.1">v2.1</see></item>
		/// </list>
		/// </remarks>
		AMPERE_HOUR,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />acceleration relative to earth's gravity given in <c>METER/SECOND^2</c>.<br /><br /><br /><br />&gt; Note 1 to entry: At different points on Earth's surface, the free-fall acceleration ranges from 9.764 to 9.834 m/s2 (Wikipedia: Gravitational Acceleration). The constant can be customized depending on the location in the universe.<br /><br /><br /><br />&gt; Note 2 to entry: In the standard, it is assumed that Earth's average value of gravitational acceleration is 9.90665 m/s2.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.1">v2.1</see></item>
		/// </list>
		/// </remarks>
		GRAVITATIONAL_ACCELERATION,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><i>MASS\\times GRAVITATIONAL_ACCELERATION</i> (g) given in <c>METER/SECOND^2</c>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.1">v2.1</see></item>
		/// </list>
		/// </remarks>
		GRAVITATIONAL_FORCE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />change of geometric volume in cubic foot per hour.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.3">v2.3</see></item>
		/// </list>
		/// </remarks>
		CUBIC_FOOT_PER_HOUR,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />change of geometric volume in cubic foot per minute.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.3">v2.3</see></item>
		/// </list>
		/// </remarks>
		CUBIC_FOOT_PER_MINUTE,
	}
}