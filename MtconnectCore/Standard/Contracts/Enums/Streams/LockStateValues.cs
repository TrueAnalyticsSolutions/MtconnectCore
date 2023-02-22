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
	public enum LockStateValues
	{
		/// <summary>
		﻿/// mechanism is engaged and preventing the associated <see cref="Component">Component</see> from being opened or operated.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		LOCKED,
		/// <summary>
		﻿/// mechanism is disengaged and the associated <see cref="Component">Component</see> is able to be opened or operated.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/")]
		UNLOCKED,
	}
}