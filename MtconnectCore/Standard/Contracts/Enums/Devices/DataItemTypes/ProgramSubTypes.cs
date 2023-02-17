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
	public enum ProgramSubTypes
	{
		/// <summary>
		﻿/// phase or segment of a recipe or program.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/")]
		ACTIVITY,
		/// <summary>
		﻿/// phase of a recipe process.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/")]
		SEGMENT,
		/// <summary>
		﻿/// process as part of product production; can be a subprocess of a larger process.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/")]
		RECIPE,
		/// <summary>
		﻿/// step of a discrete manufacturing process.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/")]
		OPERATION,
		/// <summary>
		﻿/// identity of the logic or motion program currently executing.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		ACTIVE,
		/// <summary>
		﻿/// identity of the primary logic or motion program currently being executed.   It is the starting nest level in a call structure and may contain calls to sub programs.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		MAIN,
		/// <summary>
		﻿/// identity of a control program that is used to specify the order of execution of other programs.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		SCHEDULE,
	}
}