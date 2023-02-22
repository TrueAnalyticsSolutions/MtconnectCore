using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[Obsolete("Deprecated according to https://model.mtconnect.org/")]
	[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/", MtconnectVersions.V_1_4_0)]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum DirectionValues
	{
		/// <summary>
		﻿/// clockwise rotation using the right-hand rule.
		/// </summary>
		[Obsolete("Deprecated according to https://model.mtconnect.org/")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/", MtconnectVersions.V_1_4_0)]
		CLOCKWISE,
		/// <summary>
		﻿/// counter-clockwise rotation using the right-hand rule.
		/// </summary>
		[Obsolete("Deprecated according to https://model.mtconnect.org/")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/", MtconnectVersions.V_1_4_0)]
		COUNTER_CLOCKWISE,
		/// <summary>
		﻿		/// </summary>
		[Obsolete("Deprecated according to https://model.mtconnect.org/")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/", MtconnectVersions.V_1_4_0)]
		POSITIVE,
		/// <summary>
		﻿		/// </summary>
		[Obsolete("Deprecated according to https://model.mtconnect.org/")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/", MtconnectVersions.V_1_4_0)]
		NEGATIVE,
	}
}