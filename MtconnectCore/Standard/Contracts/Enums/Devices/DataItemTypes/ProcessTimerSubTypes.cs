using MtconnectCore.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MTConnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum ProcessTimerSubTypes
	{
		/// <summary>
		﻿/// time from the beginning of production of a part or product on a piece of equipment until the time that production is complete for that part or product on that piece of equipment.  This includes the time that the piece of equipment is running, producing parts or products, or in the process of producing parts.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		PROCESS,
		/// <summary>
		﻿/// elapsed time of a temporary halt of action.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		DELAY,
	}
}