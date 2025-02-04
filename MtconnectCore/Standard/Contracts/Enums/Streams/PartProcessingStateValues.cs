#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
	/// <summary>
	﻿/// particular condition of the part occurrence at a specific time.
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Structure___19_0_3_68e0225_1622460050272_943675_1231">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.8">v1.8</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/#_Version_1.8")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.5.0.0")]
	public enum PartProcessingStateValues
	{
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />part occurrence is actively being processed.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.8">v1.8</see></item>
		/// </list>
		/// </remarks>
		IN_PROCESS,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />part occurrence is being transported to its destination.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.8">v1.8</see></item>
		/// </list>
		/// </remarks>
		IN_TRANSIT,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />part occurrence is not actively being processed, but the processing has not ended. <br /><br /><br /><br />Processing requirements exist that have not yet been fulfilled. This is the default entry state when the part occurrence is originally received. In some cases, the part occurrence may return to this state while it waits for additional processing to be performed.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.8">v1.8</see></item>
		/// </list>
		/// </remarks>
		NEEDS_PROCESSING,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />part occurrence is no longer being processed. <br /><br /><br /><br />A general state when the reason for termination is unknown.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.8">v1.8</see></item>
		/// </list>
		/// </remarks>
		PROCESSING_ENDED,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />processing of the part occurrence has come to a premature end.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.8">v1.8</see></item>
		/// </list>
		/// </remarks>
		PROCESSING_ENDED_ABORTED,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />part occurrence has completed processing successfully.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.8">v1.8</see></item>
		/// </list>
		/// </remarks>
		PROCESSING_ENDED_COMPLETE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />terminal state when the part occurrence has been removed from the equipment by an external entity and it no longer exists at the equipment.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.8">v1.8</see></item>
		/// </list>
		/// </remarks>
		PROCESSING_ENDED_LOST,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />part occurrence has been processed completely. However, the processing may have a problem.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.8">v1.8</see></item>
		/// </list>
		/// </remarks>
		PROCESSING_ENDED_REJECTED,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />part occurrence has been skipped for processing on the piece of equipment.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.8">v1.8</see></item>
		/// </list>
		/// </remarks>
		PROCESSING_ENDED_SKIPPED,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />process has been stopped during the processing. <br /><br /><br /><br />The part occurrence will require special treatment.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.8">v1.8</see></item>
		/// </list>
		/// </remarks>
		PROCESSING_ENDED_STOPPED,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />part occurrence has been placed at its designated destination.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.8">v1.8</see></item>
		/// </list>
		/// </remarks>
		TRANSIT_COMPLETE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />part occurrence is waiting for transit.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.8">v1.8</see></item>
		/// </list>
		/// </remarks>
		WAITING_FOR_TRANSIT,
	}
}