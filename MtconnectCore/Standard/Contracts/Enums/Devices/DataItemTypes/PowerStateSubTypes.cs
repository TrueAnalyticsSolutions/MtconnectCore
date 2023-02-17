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
	public enum PowerStateSubTypes
	{
		/// <summary>
		﻿/// state of the power source for the entity.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		LINE,
		/// <summary>
		﻿/// state of the enabling signal or control logic that enables or disables the function or operation of the entity.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		CONTROL,
	}
}