#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	﻿/// amount of a substance in a container.
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Structure___2024x_68e0225_1727727492980_335553_24207">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.5">v2.5</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_2_5_0, "https://model.mtconnect.org/#_Version_2.5")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.5.0.0")]
	public enum FillHeightSubTypes
	{
		/// <summary>
		﻿/// <see cref="SampleEnum.FILL_HEIGHT">SampleEnum.FILL_HEIGHT</see> that is <see cref="DataItemSubTypeEnum.ACTUAL">DataItemSubTypeEnum.ACTUAL</see>
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.5">v2.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_5_0, "https://model.mtconnect.org/#_Version_2.5")]
		
		
		Actual,
		/// <summary>
		﻿/// <see cref="SampleEnum.FILL_HEIGHT">SampleEnum.FILL_HEIGHT</see> that is <see cref="DataItemSubTypeEnum.TARGET">DataItemSubTypeEnum.TARGET</see>
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.5">v2.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_5_0, "https://model.mtconnect.org/#_Version_2.5")]
		
		
		Target,
	}
}