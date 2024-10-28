#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
	/// <summary>
	﻿/// indication of the reason that <see cref="Execution">Execution</see> is reporting a value of <c>WAIT</c>.
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580378218483_193774_2298">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.5.0.0")]
	public enum WaitStateValues
	{
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />execution is waiting while material is being loaded.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		MATERIAL_LOAD,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />execution is waiting while material is being unloaded.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		MATERIAL_UNLOAD,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />execution is waiting while one or more discrete workpieces are being loaded.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		PART_LOAD,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />execution is waiting while one or more discrete workpieces are being unloaded.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		PART_UNLOAD,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />execution is waiting while the equipment is pausing but the piece of equipment has not yet reached a fully paused state.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		PAUSING,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />execution is waiting while the equipment is powering down but has not fully reached a stopped state.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		POWERING_DOWN,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />execution is waiting while the equipment is powering up and is not currently available to begin producing parts or products.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		POWERING_UP,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />execution is waiting while the equipment is resuming the production cycle but has not yet resumed execution.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		RESUMING,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />execution is waiting while another process is completed before the execution can resume.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		SECONDARY_PROCESS,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />execution is waiting while a tool or tooling is being loaded.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		TOOL_LOAD,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />execution is waiting while a tool or tooling is being unloaded.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		TOOL_UNLOAD,
	}
}