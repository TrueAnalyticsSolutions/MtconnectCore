#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
	/// <summary>
	﻿/// state of <see cref="Component">Component</see> or <see cref="Composition">Composition</see> that describes the automatic or manual operation of the entity.
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Structure___19_0_3_68e0225_1637936881318_547715_125">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.0">v2.0</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/#_Version_2.0")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.5.0.0")]
	public enum OperatingModeValues
	{
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />automatically execute instructions from a recipe or program.<br /><br /><br /><br />&gt; Note: Setpoint comes from a recipe.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.0">v2.0</see></item>
		/// </list>
		/// </remarks>
		AUTOMATIC,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />execute instructions from an external agent or person.<br /><br /><br /><br />&gt; Note 1 to entry: Valve or switch is manipulated by an agent/person.<br /><br /><br /><br />&gt; Note 2 to entry: Direct control of the PID output. % of the range: A user manually sets the % output, not the setpoint.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.0">v2.0</see></item>
		/// </list>
		/// </remarks>
		MANUAL,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />executes a single instruction from a recipe or program.<br /><br /><br /><br />&gt; Note 1 to entry: Setpoint is entered and fixed, but the PID is controlling.<br /><br /><br /><br />&gt; Note 2 to entry: Still goes through the PID control system.<br /><br /><br /><br />&gt; Note 3 to entry: Manual fixed entry from a recipe.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.0">v2.0</see></item>
		/// </list>
		/// </remarks>
		SEMI_AUTOMATIC,
	}
}