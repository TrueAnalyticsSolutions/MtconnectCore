#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration___19_0_3_45f01b9_1580378417652_570136_2869">model.mtconnect.org</seealso>
	﻿	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "1.0.15.3")]
	public enum ActuatorStateValues
	{
		/// <summary>
		﻿/// <see cref="Actuator">Actuator</see> is operating.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		ACTIVE,
		/// <summary>
		﻿/// <see cref="Actuator">Actuator</see> is not operating.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		INACTIVE,
	}
}