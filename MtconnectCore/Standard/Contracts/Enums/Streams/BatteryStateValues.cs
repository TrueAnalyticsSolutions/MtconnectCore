using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum BatteryStateValues
	{
		/// <summary>
		﻿/// <see cref="Component">Component</see> is at it's maximum rated charge level.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		CHARGED,
		/// <summary>
		﻿/// <see cref="Component">Component</see>'s charge is increasing.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		CHARGING,
		/// <summary>
		﻿/// <see cref="Component">Component</see>'s charge is decreasing.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		DISCHARGING,
		/// <summary>
		﻿/// <see cref="Component">Component</see> is at it's minimum charge level.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		DISCHARGED,
	}
}