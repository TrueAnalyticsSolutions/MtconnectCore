#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	﻿/// position of a block of program code within a control program.
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580378218338_357401_1893">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.5.0.0")]
	public enum LineNumberSubTypes
	{
		/// <summary>
		﻿/// position of a block of program code relative to the beginning of the control program.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		
		ABSOLUTE,
		/// <summary>
		﻿/// position of a block of program code relative to the occurrence of the last <see cref="LineLabel">LineLabel</see> encountered in the control program.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		
		INCREMENTAL,
	}
}