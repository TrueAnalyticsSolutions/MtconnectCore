#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	﻿/// detection result of a sensor.
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Structure___19_0_3_68e0225_1677588817278_345680_780">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.4.0.0")]
	public enum SensorStateSubTypes
	{
		/// <summary>
		﻿/// <see cref="EventEnum.SENSOR_STATE">EventEnum.SENSOR_STATE</see> where the state is <see cref="DataItemSubTypeEnum.BINARY">DataItemSubTypeEnum.BINARY</see>
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		
		
		BINARY,
		/// <summary>
		﻿/// <see cref="EventEnum.SENSOR_STATE">EventEnum.SENSOR_STATE</see> where the state is <see cref="DataItemSubTypeEnum.BOOLEAN">DataItemSubTypeEnum.BOOLEAN</see>
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		
		
		BOOLEAN,
		/// <summary>
		﻿/// <see cref="EventEnum.SENSOR_STATE">EventEnum.SENSOR_STATE</see> where the state is <see cref="DataItemSubTypeEnum.DETECT">DataItemSubTypeEnum.DETECT</see>
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		
		
		DETECT,
		/// <summary>
		﻿/// <see cref="EventEnum.SENSOR_STATE">EventEnum.SENSOR_STATE</see> where the state is <see cref="DataItemSubTypeEnum.ENUMERATED">DataItemSubTypeEnum.ENUMERATED</see>
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		
		
		ENUMERATED,
	}
}