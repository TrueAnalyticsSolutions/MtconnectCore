using MtconnectCore.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[Obsolete("Deprecated according to https://model.mtconnect.org/")]
	[MTConnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/", MtconnectVersions.V_1_4_0)]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum LineSubTypes
	{
		/// <summary>
		﻿/// maximum line number of the code being executed.
		/// </summary>
		[Obsolete("Deprecated according to https://model.mtconnect.org/")]
		[MTConnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/", MtconnectVersions.V_1_4_0)]
		MAXIMUM,
		/// <summary>
		﻿/// minimum line number of the code being executed.
		/// </summary>
		[Obsolete("Deprecated according to https://model.mtconnect.org/")]
		[MTConnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/", MtconnectVersions.V_1_4_0)]
		MINIMUM,
	}
}