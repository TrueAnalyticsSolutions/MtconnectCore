#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
	/// <summary>
	﻿/// describes the way the axes will be associated to each other. <br />  <br />This is used in conjunction with <c>COUPLED_AXES</c> to indicate the way they are interacting.
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580378218184_367826_1557">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.5.0.0")]
	public enum AxisCouplingValues
	{
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />axis is the master of the <see cref="CoupledAxes">CoupledAxes</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		MASTER,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />axis is a slave to the <see cref="CoupledAxes">CoupledAxes</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		SLAVE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />axes are not physically connected to each other but are operating together in lockstep.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		SYNCHRONOUS,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />axes are physically connected to each other and operate as a single unit.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		TANDEM,
	}
}