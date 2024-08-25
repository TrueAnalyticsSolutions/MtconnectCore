#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
	/// <summary>
	﻿/// pass/fail result of the measurement.
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Structure___19_0_3_68e0225_1678250725500_734546_18580">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.4.0.0")]
	public enum CharacteristicStatusValues
	{
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />nominal provided without tolerance limits. <seealso href="https://www.google.com/search?q=QIF 3:2018 5.10.2.6&amp;btnI=I">QIF 3:2018 5.10.2.6</seealso><br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		BASIC_OR_THEORETIC_EXACT_DIMENSION,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />measurement is not within acceptable tolerances.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		FAIL,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />measurement cannot be determined.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		INDETERMINATE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />measurement cannot be evaluated.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		NOT_ANALYZED,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />measurement is within acceptable tolerances.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		PASS,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />failed, but acceptable constraints achievable by utilizing additional manufacturing processes.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		REWORK,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />measurement is indeterminate due to an equipment failure.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		SYSTEM_ERROR,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />status of measurement cannot be determined.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		UNDEFINED,
	}
}