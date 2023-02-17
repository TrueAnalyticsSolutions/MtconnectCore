using MtconnectCore.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MTConnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum PathPositionSubTypes
	{
		/// <summary>
		﻿/// measured or reported value of an <i>observation</i>.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		ACTUAL,
		/// <summary>
		﻿/// directive value including adjustments such as an offset or overrides.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		COMMANDED,
		/// <summary>
		﻿/// goal of the operation or process.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		TARGET,
		/// <summary>
		﻿/// position provided by a measurement probe.  <b>DEPRECATION WARNING</b>: May be deprecated in the future.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		PROBE,
	}
}