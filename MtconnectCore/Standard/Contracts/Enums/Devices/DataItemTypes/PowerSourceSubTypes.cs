#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	﻿/// active energy source for the <see cref="Component">Component</see>.
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Structure___19_0_3_68e0225_1696872166478_3528_3677">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.3">v2.3</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_2_3_0, "https://model.mtconnect.org/#_Version_2.3")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.4.0.0")]
	public enum PowerSourceSubTypes
	{
		/// <summary>
		﻿/// <see cref="EventEnum.POWER_SOURCE">EventEnum.POWER_SOURCE</see> that is <see cref="DataItemSubTypeEnum.PRIMARY">DataItemSubTypeEnum.PRIMARY</see>
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.3">v2.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_3_0, "https://model.mtconnect.org/#_Version_2.3")]
		
		
		PRIMARY,
		/// <summary>
		﻿/// <see cref="EventEnum.POWER_SOURCE">EventEnum.POWER_SOURCE</see> that is <see cref="DataItemSubTypeEnum.SECONDARY">DataItemSubTypeEnum.SECONDARY</see>
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.3">v2.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_3_0, "https://model.mtconnect.org/#_Version_2.3")]
		
		
		SECONDARY,
		/// <summary>
		﻿/// <see cref="EventEnum.POWER_SOURCE">EventEnum.POWER_SOURCE</see> that is <see cref="DataItemSubTypeEnum.STANDBY">DataItemSubTypeEnum.STANDBY</see> that is uninterruptible or generator power supply.<br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.3">v2.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_3_0, "https://model.mtconnect.org/#_Version_2.3")]
		
		
		STANDBY,
	}
}