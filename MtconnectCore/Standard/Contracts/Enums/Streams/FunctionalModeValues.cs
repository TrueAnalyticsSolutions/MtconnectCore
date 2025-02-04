#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
	/// <summary>
	﻿/// current intended production status of the <see cref="Component">Component</see>.
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580378218312_721573_1833">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#_Version_1.3")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.5.0.0")]
	public enum FunctionalModeValues
	{
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Component">Component</see> is not currently producing product.<br /><br /><br /><br />It is currently being repaired, waiting to be repaired, or has not yet been returned to a normal production status after maintenance has been performed.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		MAINTENANCE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Component">Component</see> is being used to prove-out a new process, testing of equipment or processes, or any other active use that does not result in the production of product.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		PROCESS_DEVELOPMENT,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Component">Component</see> is currently producing product, ready to produce product, or its current intended use is to be producing product.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		PRODUCTION,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Component">Component</see> is not currently producing product. <br /><br /><br /><br />It is being prepared or modified to begin production of product.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		SETUP,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Component">Component</see> is not currently producing product.<br /><br /><br /><br />Typically, it has completed the production of a product and is being modified or returned to a neutral state such that it may then be prepared to begin production of a different product.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		TEARDOWN,
	}
}