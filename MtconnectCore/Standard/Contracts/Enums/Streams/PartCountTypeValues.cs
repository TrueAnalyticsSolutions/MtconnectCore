using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MtconnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum PartCountTypeValues
	{
		/// <summary>
		﻿/// count is of individual items.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/")]
		EACH,
		/// <summary>
		﻿/// pre-specified group of items.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/")]
		BATCH,
	}
}