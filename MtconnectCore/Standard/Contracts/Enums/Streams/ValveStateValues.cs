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
	public enum ValveStateValues
	{
		/// <summary>
		﻿/// <see cref="ValveState">ValveState</see> where flow is allowed and the aperture is static.  > Note: For a binary value, <c>OPEN</c> indicates the valve has the maximum possible aperture.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		OPEN,
		/// <summary>
		﻿/// valve is transitioning from a <c>CLOSED</c> state to an <c>OPEN</c> state.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		OPENING,
		/// <summary>
		﻿/// <see cref="ValveState">ValveState</see> where flow is not possible, the aperture is static, and the valve is completely shut.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		CLOSED,
		/// <summary>
		﻿/// valve is transitioning from an <c>OPEN</c> state to a <c>CLOSED</c> state.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		CLOSING,
	}
}