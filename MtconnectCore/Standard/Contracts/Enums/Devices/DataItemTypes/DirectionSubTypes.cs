using MtconnectCore.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MTConnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum DirectionSubTypes
	{
		/// <summary>
		﻿/// rotational direction of a rotary motion using the right hand rule convention.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		ROTARY,
		/// <summary>
		﻿/// direction of motion of a linear motion.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		LINEAR,
	}
}