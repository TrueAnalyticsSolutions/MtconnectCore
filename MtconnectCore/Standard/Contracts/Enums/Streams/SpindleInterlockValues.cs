using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum SpindleInterlockValues
	{
		/// <summary>
		﻿/// power has been removed and the spindle cannot be operated.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		ACTIVE,
		/// <summary>
		﻿/// spindle has not been deactivated.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		INACTIVE,
	}
}