using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum ConnectionStatusValues
	{
		/// <summary>
		﻿/// no connection at all.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		CLOSED,
		/// <summary>
		﻿/// <i>agent</i> is waiting for a connection request from an <i>adapter</i>.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		LISTEN,
		/// <summary>
		﻿/// open connection.  The normal state for the data transfer phase of the connection.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		ESTABLISHED,
	}
}