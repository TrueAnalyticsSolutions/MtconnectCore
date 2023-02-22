using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MtconnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum OperatingModeValues
	{
		/// <summary>
		﻿/// automatically execute instructions from a recipe or program.  > Note: Setpoint comes from a recipe.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/")]
		AUTOMATIC,
		/// <summary>
		﻿/// execute instructions from an external agent or person.  > Note 1 to entry: Valve or switch is manipulated by an agent/person.  > Note 2 to entry: Direct control of the PID output. % of the range: A user manually sets the % output, not the setpoint.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/")]
		MANUAL,
		/// <summary>
		﻿/// executes a single instruction from a recipe or program.  > Note 1 to entry: Setpoint is entered and fixed, but the PID is controlling.  > Note 2 to entry: Still goes through the PID control system.  > Note 3 to entry: Manual fixed entry from a recipe.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/")]
		SEMI_AUTOMATIC,
	}
}