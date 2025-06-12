#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	﻿/// number of particles counted by their size or other characteristics.
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Structure___2024x_68e0225_1727728953400_643342_24554">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.5">v2.5</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_2_5_0, "https://model.mtconnect.org/#_Version_2.5")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.5.0.0")]
	public enum ParticleCountSubTypes
	{
		/// <summary>
		﻿/// <see cref="SampleEnum.PARTICLE_COUNT">SampleEnum.PARTICLE_COUNT</see> for a <see cref="DataItemSubType.GAS">DataItemSubType.GAS</see>
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.5">v2.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_5_0, "https://model.mtconnect.org/#_Version_2.5")]
		
		
		Gas,
		/// <summary>
		﻿/// <see cref="SampleEnum.PARTICLE_COUNT">SampleEnum.PARTICLE_COUNT</see> for a <see cref="DataItemSubType.LIQUID">DataItemSubType.LIQUID</see>
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.5">v2.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_5_0, "https://model.mtconnect.org/#_Version_2.5")]
		
		
		Liquid,
		/// <summary>
		﻿/// <see cref="SampleEnum.PARTICLE_COUNT">SampleEnum.PARTICLE_COUNT</see> for a <see cref="DataItemSubType.SOLID">DataItemSubType.SOLID</see>
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.5">v2.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_5_0, "https://model.mtconnect.org/#_Version_2.5")]
		
		
		Solid,
	}
}