#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums
{
	/// <summary>
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Enumeration___19_0_3_45f01b9_1579107560604_392738_163543">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.4.0.0")]
	public enum CoordinateSystemTypeEnum
	{
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />coordinate system referenced to the base mounting surface. <seealso href="https://www.google.com/search?q=ISO 9787:2013&amp;btnI=I">ISO 9787:2013</seealso><br /><br /><br /><br />A base mounting surface is a connection surface between the arm and its supporting structure.<seealso href="https://www.google.com/search?q=ISO 9787:2013&amp;btnI=I">ISO 9787:2013</seealso><br /><br /><br /><br />For non-robotic devices, it is the connection surface between the device and its supporting structure.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		BASE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />coordinate system referenced to the sensor which monitors the site of the task. <seealso href="https://www.google.com/search?q=ISO 9787:2013&amp;btnI=I">ISO 9787:2013</seealso><br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		CAMERA,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />coordinate system referenced to the home position and orientation of the primary axes of a piece of equipment.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		MACHINE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />coordinate system referenced to the mechanical interface. <seealso href="https://www.google.com/search?q=ISO 9787:2013&amp;btnI=I">ISO 9787:2013</seealso><br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		MECHANICAL_INTERFACE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />coordinate system referenced to one of the components of a mobile platform. <seealso href="https://www.google.com/search?q=ISO 8373:2012&amp;btnI=I">ISO 8373:2012</seealso><br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		MOBILE_PLATFORM,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />coordinate system referenced to the object. <seealso href="https://www.google.com/search?q=ISO 9787:2013&amp;btnI=I">ISO 9787:2013</seealso><br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		OBJECT,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />coordinate system referenced to the site of the task. <seealso href="https://www.google.com/search?q=ISO 9787:2013&amp;btnI=I">ISO 9787:2013</seealso><br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		TASK,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />coordinate system referenced to the tool or to the end effector attached to the mechanical interface. <seealso href="https://www.google.com/search?q=ISO 9787:2013&amp;btnI=I">ISO 9787:2013</seealso><br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		TOOL,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />stationary coordinate system referenced to earth, which is independent of the robot motion. <seealso href="https://www.google.com/search?q=ISO 9787:2013&amp;btnI=I">ISO 9787:2013</seealso><br /><br /><br /><br />For non-robotic devices, stationary coordinate system referenced to earth, which is independent of the motion of a piece of equipment.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		WORLD,
	}
}