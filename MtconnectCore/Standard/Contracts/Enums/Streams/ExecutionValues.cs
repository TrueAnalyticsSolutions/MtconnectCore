using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum ExecutionValues
	{
		/// <summary>
		﻿/// <see cref="Component">Component</see> is ready to execute instructions.  It is currently idle.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		READY,
		/// <summary>
		﻿/// <see cref="Component">Component</see> is actively executing an instruction.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		ACTIVE,
		/// <summary>
		﻿/// <see cref="Component">Component</see> suspends the execution of the program due to an external signal.  Action is required to resume execution.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		INTERRUPTED,
		/// <summary>
		﻿/// motion of the active axes are commanded to stop at their current position.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		FEED_HOLD,
		/// <summary>
		﻿/// <see cref="Component">Component</see> program is not <c>READY</c> to execute.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		STOPPED,
		/// <summary>
		﻿/// command from the program has intentionally interrupted execution.  The <see cref="Component">Component</see> <b>MAY</b> have another state that indicates if the execution is interrupted or the execution ignores the interrupt instruction.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		OPTIONAL_STOP,
		/// <summary>
		﻿/// command from the program has intentionally interrupted execution.  Action is required to resume execution.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		PROGRAM_STOPPED,
		/// <summary>
		﻿/// program completed execution.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		PROGRAM_COMPLETED,
		/// <summary>
		﻿/// <see cref="Component">Component</see> suspends execution while a secondary operation executes.  Execution resumes automatically once the secondary operation completes.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		WAIT,
	}
}