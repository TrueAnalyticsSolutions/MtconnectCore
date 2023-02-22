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
	public enum AxisInterlockValues
	{
		/// <summary>
		﻿/// axis lockout function is activated, power has been removed from the axis, and the axis is allowed to move freely.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		ACTIVE,
		/// <summary>
		﻿/// axis lockout function has not been activated, the axis may be powered, and the axis is capable of being controlled by another component.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		INACTIVE,
	}
}