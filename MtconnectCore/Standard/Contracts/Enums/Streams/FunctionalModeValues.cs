using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum FunctionalModeValues
	{
		/// <summary>
		﻿/// <see cref="Component">Component</see> is currently producing product, ready to produce product, or its current intended use is to be producing product.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		PRODUCTION,
		/// <summary>
		﻿/// <see cref="Component">Component</see> is not currently producing product.   It is being prepared or modified to begin production of product.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		SETUP,
		/// <summary>
		﻿/// <see cref="Component">Component</see> is not currently producing product.  Typically, it has completed the production of a product and is being modified or returned to a neutral state such that it may then be prepared to begin production of a different product.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		TEARDOWN,
		/// <summary>
		﻿/// <see cref="Component">Component</see> is not currently producing product.  It is currently being repaired, waiting to be repaired, or has not yet been returned to a normal production status after maintenance has been performed.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		MAINTENANCE,
		/// <summary>
		﻿/// <see cref="Component">Component</see> is being used to prove-out a new process, testing of equipment or processes, or any other active use that does not result in the production of product.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		PROCESS_DEVELOPMENT,
	}
}