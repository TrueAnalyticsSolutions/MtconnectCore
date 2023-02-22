using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum WaitStateValues
	{
		/// <summary>
		﻿/// execution is waiting while the equipment is powering up and is not currently available to begin producing parts or products.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		POWERING_UP,
		/// <summary>
		﻿/// execution is waiting while the equipment is powering down but has not fully reached a stopped state.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		POWERING_DOWN,
		/// <summary>
		﻿/// execution is waiting while one or more discrete workpieces are being loaded.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		PART_LOAD,
		/// <summary>
		﻿/// execution is waiting while one or more discrete workpieces are being unloaded.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		PART_UNLOAD,
		/// <summary>
		﻿/// execution is waiting while a tool or tooling is being loaded.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		TOOL_LOAD,
		/// <summary>
		﻿/// execution is waiting while a tool or tooling is being unloaded.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		TOOL_UNLOAD,
		/// <summary>
		﻿/// execution is waiting while material is being loaded.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		MATERIAL_LOAD,
		/// <summary>
		﻿/// execution is waiting while material is being unloaded.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		MATERIAL_UNLOAD,
		/// <summary>
		﻿/// execution is waiting while another process is completed before the execution can resume.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		SECONDARY_PROCESS,
		/// <summary>
		﻿/// execution is waiting while the equipment is pausing but the piece of equipment has not yet reached a fully paused state.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		PAUSING,
		/// <summary>
		﻿/// execution is waiting while the equipment is resuming the production cycle but has not yet resumed execution.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		RESUMING,
	}
}