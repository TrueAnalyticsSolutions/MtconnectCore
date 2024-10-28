#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums
{
	/// <summary>
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Enumeration___19_0_3_68e0225_1612550811680_794757_187">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.5.0.0")]
	public enum CompositionStateMotionEnum
	{
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />position of the <see cref="Composition">Composition</see> is closed to the point of a positive confirmation.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		CLOSED,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />position of the <see cref="Composition">Composition</see> is open to the point of a positive confirmation.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		OPEN,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />position of the <see cref="Composition">Composition</see> is not open to the<br /><br />point of a positive confirmation and is not closed to the point of a positive confirmation. <br /><br /><br /><br />It is in an intermediate position.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		UNLATCHED,
	}
}