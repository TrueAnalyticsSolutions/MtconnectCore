using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum ProcessStateValues
	{
		/// <summary>
		﻿/// device is preparing to execute the process occurrence.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		INITIALIZING,
		/// <summary>
		﻿/// process occurrence is ready to be executed.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		READY,
		/// <summary>
		﻿/// process occurrence is actively executing.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		ACTIVE,
		/// <summary>
		﻿/// process occurrence is now finished.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		COMPLETE,
		/// <summary>
		﻿/// process occurrence has been stopped and may be resumed.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		INTERRUPTED,
		/// <summary>
		﻿/// process occurrence has come to a premature end and cannot be resumed.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		ABORTED,
	}
}