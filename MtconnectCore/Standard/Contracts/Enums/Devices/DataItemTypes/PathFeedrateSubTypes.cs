﻿using MtconnectCore.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MTConnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum PathFeedrateSubTypes
	{
		/// <summary>
		﻿/// measured or reported value of an <i>observation</i>.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		ACTUAL,
		/// <summary>
		﻿/// directive value including adjustments such as an offset or overrides.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		COMMANDED,
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
		/// <summary>
		﻿/// operator's overridden value.  <b>DEPRECATED</b> in <i>Version 1.3</i>.
		/// </summary>
		[Obsolete("Deprecated according to https://model.mtconnect.org/")]
		[MTConnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/", MtconnectVersions.V_1_3_0)]
		OVERRIDE,
	}
}