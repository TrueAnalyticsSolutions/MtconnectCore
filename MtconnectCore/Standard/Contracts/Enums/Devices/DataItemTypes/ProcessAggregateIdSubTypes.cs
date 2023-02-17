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
	public enum ProcessAggregateIdSubTypes
	{
		/// <summary>
		﻿/// identifier of the authorization of the process occurrence. Synonyms include "job id", "work order".
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		ORDER_NUMBER,
		/// <summary>
		﻿/// identifier of the step in the process plan that this occurrence corresponds to. Synonyms include "operation id".
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		PROCESS_STEP,
		/// <summary>
		﻿/// identifier of the process plan that this occurrence belongs to. Synonyms include "routing id", "job id". 
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		PROCESS_PLAN,
	}
}