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
	public enum LineNumberSubTypes
	{
		/// <summary>
		﻿/// position of a block of program code relative to the beginning of the control program.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		ABSOLUTE,
		/// <summary>
		﻿/// position of a block of program code relative to the occurrence of the last <see cref="LineLabel">LineLabel</see> encountered in the control program.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		INCREMENTAL,
	}
}