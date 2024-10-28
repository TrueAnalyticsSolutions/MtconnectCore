#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
	/// <summary>
	﻿/// operating state of a <see cref="Component">Component</see>.
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580378218306_196644_1821">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.5.0.0")]
	public enum ExecutionValues
	{
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Component">Component</see> is actively executing an instruction.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		ACTIVE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Component">Component</see> suspends the execution of the program due to an external signal.<br /><br /><br /><br />Action is required to resume execution.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		INTERRUPTED,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Component">Component</see> is ready to execute instructions.<br /><br /><br /><br />It is currently idle.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		READY,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Component">Component</see> program is not <c>READY</c> to execute.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		STOPPED,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />motion of the active axes are commanded to stop at their current position.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		FEED_HOLD,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />program completed execution.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		PROGRAM_COMPLETED,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />program has been intentionally optionally stopped using an M01 or similar code.<br /><br /><br /><br /><b>DEPRECATED</b> in <i>version 1.4</i> and replaced with <c>OPTIONAL_STOP</c>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// <item><b>Deprecated</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[Obsolete("Deprecated in v1.4 according to https://model.mtconnect.org/#_Version_1.4")]
		PROGRAM_OPTIONAL_STOP,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />command from the program has intentionally interrupted execution.<br /><br /><br /><br />Action is required to resume execution.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		PROGRAM_STOPPED,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />command from the program has intentionally interrupted execution.<br /><br /><br /><br />The <see cref="Component">Component</see> <b>MAY</b> have another state that indicates if the execution is interrupted or the execution ignores the interrupt instruction.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		OPTIONAL_STOP,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Component">Component</see> suspends execution while a secondary operation executes.<br /><br /><br /><br />Execution resumes automatically once the secondary operation completes.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		WAIT,
	}
}