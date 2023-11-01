#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration___19_0_3_68e0225_1678195723846_572772_17405">model.mtconnect.org</seealso>
	﻿	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "1.0.15.3")]
	public enum CharacteristicStatusValues
	{
		/// <summary>
		﻿/// measurement is within acceptable tolerances.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		PASS,
		/// <summary>
		﻿/// measurement is not within acceptable tolerances.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		FAIL,
		/// <summary>
		﻿/// failed, but acceptable constraints achievable by utilizing additional manufacturing processes.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		REWORK,
		/// <summary>
		﻿/// measurement is indeterminate due to an equipment failure.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		SYSTEM_ERROR,
		/// <summary>
		﻿/// measurement cannot be determined.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		INDETERMINATE,
		/// <summary>
		﻿/// measurement cannot be evaluated.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		NOT_ANALYZED,
		/// <summary>
		﻿/// nominal provided without tolerance limits. <seealso href="https://www.google.com/search?q=QIF 3:2018 5.10.2.6&btnI=I">QIF 3:2018 5.10.2.6</seealso>
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		BASIC_OR_THEORETIC_EXACT_DIMENSION,
		/// <summary>
		﻿/// status of measurement cannot be determined.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		UNDEFINED,
	}
}