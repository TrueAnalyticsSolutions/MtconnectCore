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
	public enum VolumeFluidSubTypes
	{
		/// <summary>
		﻿/// measured or reported value of an <i>observation</i>.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		ACTUAL,
		/// <summary>
		﻿/// reported or measured value of the amount used in the manufacturing process.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		CONSUMED,
		/// <summary>
		﻿/// reported or measured value of amount included in the <i>part</i>.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		PART,
		/// <summary>
		﻿/// reported or measured value of the amount discarded.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		WASTE,
		/// <summary>
		﻿/// boundary when an activity or an event commences.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		START,
		/// <summary>
		﻿/// boundary when an activity or an event terminates.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		ENDED,
	}
}