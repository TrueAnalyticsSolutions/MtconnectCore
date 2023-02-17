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
	public enum PathFeedrateOverrideSubTypes
	{
		/// <summary>
		﻿/// relating to momentary activation of a function or a movement.  <b>DEPRECATION WARNING</b>: May be deprecated in the future.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		JOG,
		/// <summary>
		﻿/// directive value without offsets and adjustments.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		PROGRAMMED,
		/// <summary>
		﻿/// performing an operation faster or in less time than nominal rate.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		RAPID,
	}
}