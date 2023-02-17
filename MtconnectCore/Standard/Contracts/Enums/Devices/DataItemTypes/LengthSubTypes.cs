using MtconnectCore.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MTConnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum LengthSubTypes
	{
		/// <summary>
		﻿/// standard or original length of an object.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		STANDARD,
		/// <summary>
		﻿/// remaining total length of an object.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		REMAINING,
		/// <summary>
		﻿/// remaining usable length of an object.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		USEABLE,
	}
}