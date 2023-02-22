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
	public enum PartProcessingStateValues
	{
		/// <summary>
		﻿/// part occurrence is not actively being processed, but the processing has not ended.   Processing requirements exist that have not yet been fulfilled. This is the default entry state when the part occurrence is originally received. In some cases, the part occurrence may return to this state while it waits for additional processing to be performed.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		NEEDS_PROCESSING,
		/// <summary>
		﻿/// part occurrence is actively being processed.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		IN_PROCESS,
		/// <summary>
		﻿/// part occurrence is no longer being processed.   A general state when the reason for termination is unknown.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		PROCESSING_ENDED,
		/// <summary>
		﻿/// part occurrence has completed processing successfully.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		PROCESSING_ENDED_COMPLETE,
		/// <summary>
		﻿/// process has been stopped during the processing.   The part occurrence will require special treatment.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		PROCESSING_ENDED_STOPPED,
		/// <summary>
		﻿/// processing of the part occurrence has come to a premature end.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		PROCESSING_ENDED_ABORTED,
		/// <summary>
		﻿/// terminal state when the part occurrence has been removed from the equipment by an external entity and it no longer exists at the equipment.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		PROCESSING_ENDED_LOST,
		/// <summary>
		﻿/// part occurrence has been skipped for processing on the piece of equipment.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		PROCESSING_ENDED_SKIPPED,
		/// <summary>
		﻿/// part occurrence has been processed completely. However, the processing may have a problem.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		PROCESSING_ENDED_REJECTED,
		/// <summary>
		﻿/// part occurrence is waiting for transit.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		WAITING_FOR_TRANSIT,
		/// <summary>
		﻿/// part occurrence is being transported to its destination.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		IN_TRANSIT,
		/// <summary>
		﻿/// part occurrence has been placed at its designated destination.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		TRANSIT_COMPLETE,
	}
}