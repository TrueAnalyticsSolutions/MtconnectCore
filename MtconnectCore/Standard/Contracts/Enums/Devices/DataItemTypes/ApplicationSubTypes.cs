using MtconnectCore.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MTConnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum ApplicationSubTypes
	{
		/// <summary>
		﻿/// version of the hardware or software.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		VERSION,
		/// <summary>
		﻿/// date the hardware or software was released for general use.  
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		RELEASE_DATE,
		/// <summary>
		﻿/// corporate identity for the maker of the hardware or software.  
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		MANUFACTURER,
		/// <summary>
		﻿/// license code to validate or activate the hardware or software.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		LICENSE,
		/// <summary>
		﻿/// date the hardware or software was installed.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		INSTALL_DATE,
	}
}