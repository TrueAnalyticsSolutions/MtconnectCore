using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum AxisCouplingValues
	{
		/// <summary>
		﻿/// axes are physically connected to each other and operate as a single unit.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		TANDEM,
		/// <summary>
		﻿/// axes are not physically connected to each other but are operating together in lockstep.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		SYNCHRONOUS,
		/// <summary>
		﻿/// axis is the master of the <see cref="CoupledAxes">CoupledAxes</see>.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		MASTER,
		/// <summary>
		﻿/// axis is a slave to the <see cref="CoupledAxes">CoupledAxes</see>.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		SLAVE,
	}
}