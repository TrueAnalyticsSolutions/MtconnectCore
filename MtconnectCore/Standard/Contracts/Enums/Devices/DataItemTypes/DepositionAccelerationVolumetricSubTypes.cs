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
	public enum DepositionAccelerationVolumetricSubTypes
	{
		/// <summary>
		﻿/// measured or reported value of an <i>observation</i>.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		ACTUAL,
		/// <summary>
		﻿/// directive value including adjustments such as an offset or overrides.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		COMMANDED,
	}
}