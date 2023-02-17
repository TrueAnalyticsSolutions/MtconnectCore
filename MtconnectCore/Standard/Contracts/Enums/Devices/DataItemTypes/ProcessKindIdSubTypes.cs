using MtconnectCore.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum ProcessKindIdSubTypes
	{
		/// <summary>
		﻿/// universally unique identifier as specified in ISO 11578 or RFC 4122.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		UUID,
		/// <summary>
		﻿/// reference to a ISO 10303 Executable.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		I_S_O_STEP_EXECUTABLE,
		/// <summary>
		﻿/// word or set of words by which a process being executed (process occurrence) by the device is known, addressed, or referred to. 
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		PROCESS_NAME,
	}
}