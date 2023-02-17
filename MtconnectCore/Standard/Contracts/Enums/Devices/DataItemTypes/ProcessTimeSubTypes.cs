using MtconnectCore.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MTConnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum ProcessTimeSubTypes
	{
		/// <summary>
		﻿/// boundary when an activity or an event commences.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		START,
		/// <summary>
		﻿/// time and date associated with the completion of an activity or event.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		COMPLETE,
		/// <summary>
		﻿/// projected time and date associated with the end or completion of an activity or event.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		TARGET_COMPLETION,
	}
}