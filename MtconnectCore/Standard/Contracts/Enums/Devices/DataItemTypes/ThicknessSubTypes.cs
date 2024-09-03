#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	﻿/// dimension between two surfaces of an object, usually the dimension of smallest measure, for example an additive layer, or a depth of cut.
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Structure___19_0_3_68e0225_1712321222573_635969_358">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.4">v2.4</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_2_4_0, "https://model.mtconnect.org/#_Version_2.4")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.4.0.0")]
	public enum ThicknessSubTypes
	{
		/// <summary>
		﻿/// <see cref="EventEnum.THICKNESS">EventEnum.THICKNESS</see> that is <see cref="DataItemSubTypeEnum.ACTUAL">DataItemSubTypeEnum.ACTUAL</see>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.4">v2.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_4_0, "https://model.mtconnect.org/#_Version_2.4")]
		
		
		ACTUAL,
		/// <summary>
		﻿/// <see cref="EventEnum.THICKNESS">EventEnum.THICKNESS</see> that is <see cref="DataItemSubTypeEnum.COMMANDED">DataItemSubTypeEnum.COMMANDED</see>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.4">v2.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_4_0, "https://model.mtconnect.org/#_Version_2.4")]
		
		
		COMMANDED,
		/// <summary>
		﻿/// <see cref="EventEnum.THICKNESS">EventEnum.THICKNESS</see> that is <see cref="DataItemSubTypeEnum.PROGRAMMED">DataItemSubTypeEnum.PROGRAMMED</see>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.4">v2.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_4_0, "https://model.mtconnect.org/#_Version_2.4")]
		
		
		PROGRAMMED,
		/// <summary>
		﻿/// <see cref="EventEnum.THICKNESS">EventEnum.THICKNESS</see> that is <see cref="DataItemSubTypeEnum.TARGET">DataItemSubTypeEnum.TARGET</see>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.4">v2.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_4_0, "https://model.mtconnect.org/#_Version_2.4")]
		
		
		TARGET,
	}
}