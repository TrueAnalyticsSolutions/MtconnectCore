#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration___19_0_3_68e0225_1605642679847_825017_142">model.mtconnect.org</seealso>
	﻿	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "1.0.7.0")]
	public enum DecelerationSubTypes
	{
		/// <summary>
		﻿/// directive value without offsets and adjustments.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		PROGRAMMED,
		/// <summary>
		﻿/// directive value including adjustments such as an offset or overrides.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		COMMANDED,
		/// <summary>
		﻿/// measured or reported value of an <i>observation</i>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		ACTUAL,
	}
}