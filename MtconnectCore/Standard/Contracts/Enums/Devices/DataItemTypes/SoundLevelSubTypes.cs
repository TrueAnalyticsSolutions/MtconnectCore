using MtconnectCore.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MTConnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.11.0")]
	public enum SoundLevelSubTypes
	{
		/// <summary>
		﻿/// No weighting factor on the frequency scale
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		NO_SCALE,
		/// <summary>
		﻿/// A Scale weighting factor.   This is the default weighting factor if no factor is specified
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		A_SCALE,
		/// <summary>
		﻿/// B Scale weighting factor
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		B_SCALE,
		/// <summary>
		﻿/// C Scale weighting factor
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		C_SCALE,
		/// <summary>
		﻿/// D Scale weighting factor
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		D_SCALE,
	}
}