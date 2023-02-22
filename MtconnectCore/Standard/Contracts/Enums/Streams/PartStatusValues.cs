using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum PartStatusValues
	{
		/// <summary>
		﻿/// part conforms to given requirements.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		PASS,
		/// <summary>
		﻿/// part does not conform to some given requirements.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		FAIL,
	}
}