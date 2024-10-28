#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums
{
	/// <summary>
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Enumeration__EAID_6B22B6F6_7073_4fa7_961B_B05AD4C7EF81">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
	/// <item><b>Deprecated</b>: <see href="https://model.mtconnect.org/#_Version_2.0">v2.0</see></item>
	/// </list>
	/// </remarks>
	[Obsolete("Deprecated in v2.0 according to https://model.mtconnect.org/#_Version_2.0")]
	[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0", MtconnectVersions.V_2_0_0)]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.5.0.0")]
	public enum CoordinateSystemEnum
	{
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />unchangeable coordinate system that has machine zero as its origin.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// <item><b>Deprecated</b>: <see href="https://model.mtconnect.org/#_Version_2.0">v2.0</see></item>
		/// </list>
		/// </remarks>
		[Obsolete("Deprecated in v2.0 according to https://model.mtconnect.org/#_Version_2.0")]
		MACHINE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />coordinate system that represents the working area for a particular workpiece whose origin is shifted within the <c>MACHINE</c> coordinate system.<br /><br /><br /><br />If the <c>WORK</c> coordinates are not currently defined in the piece of equipment, the <c>MACHINE</c> coordinates will be used.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// <item><b>Deprecated</b>: <see href="https://model.mtconnect.org/#_Version_2.0">v2.0</see></item>
		/// </list>
		/// </remarks>
		[Obsolete("Deprecated in v2.0 according to https://model.mtconnect.org/#_Version_2.0")]
		WORK,
	}
}