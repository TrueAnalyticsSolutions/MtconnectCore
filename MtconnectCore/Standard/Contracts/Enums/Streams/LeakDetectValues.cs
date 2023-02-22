using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum LeakDetectValues
	{
		/// <summary>
		﻿/// leak is currently being detected.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		DETECTED,
		/// <summary>
		﻿/// leak is currently not being detected.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		NOT_DETECTED,
	}
}