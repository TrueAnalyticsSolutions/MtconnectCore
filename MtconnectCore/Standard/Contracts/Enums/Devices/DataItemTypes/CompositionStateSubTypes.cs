using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum CompositionStateSubTypes
	{
		/// <summary>
		﻿/// indication of the operating state of a mechanism.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		ACTION,
		/// <summary>
		﻿/// indication of the position of a mechanism that may move in a lateral direction.   
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		LATERAL,
		/// <summary>
		﻿/// indication of the open or closed state of a mechanism. 
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		MOTION,
		/// <summary>
		﻿/// indication of the activation state of a mechanism.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		SWITCHED,
		/// <summary>
		﻿/// indication of the position of a mechanism that may move in a vertical direction.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		VERTICAL,
	}
}