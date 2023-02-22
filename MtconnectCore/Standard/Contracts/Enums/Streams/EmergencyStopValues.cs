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
	public enum EmergencyStopValues
	{
		/// <summary>
		﻿/// emergency stop circuit is complete and the piece of equipment, component, or composition is allowed to operate. 
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		ARMED,
		/// <summary>
		﻿/// operation of the piece of equipment, component, or composition is inhibited.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		TRIGGERED,
	}
}