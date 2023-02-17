using MtconnectCore.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MTConnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum UnloadCountSubTypes
	{
		/// <summary>
		﻿/// accumulation of actions or activities that were attempted, but terminated before they could be completed.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		ABORTED,
		/// <summary>
		﻿/// accumulation of actions, items, or activities being counted that do not conform to specification or expectation.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		BAD,
		/// <summary>
		﻿/// accumulation of actions, items, or activities being counted that do not conform to specification or expectation.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		FAILED,
		/// <summary>
		﻿/// accumulation of actions, items, or activities being counted that conform to specification or expectation.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		GOOD,
		/// <summary>
		﻿/// accumulation of actions, items, or activities that have been completed, independent of the outcome.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		COMPLETE,
		/// <summary>
		﻿/// accumulation of all actions, items, or activities being counted independent of the outcome.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		ALL,
		/// <summary>
		﻿/// goal of the operation or process.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		TARGET,
		/// <summary>
		﻿/// accumulation of actions, items, or activities yet to be counted.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		REMAINING,
	}
}