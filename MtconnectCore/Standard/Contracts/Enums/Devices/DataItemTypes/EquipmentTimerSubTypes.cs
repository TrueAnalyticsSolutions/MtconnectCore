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
	public enum EquipmentTimerSubTypes
	{
		/// <summary>
		﻿/// time that the sub-parts of a piece of equipment are under load.  Example: For traditional machine tools, this is a measurement of the time that the cutting tool is assumed to be engaged with the part.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		LOADED,
		/// <summary>
		﻿/// time that a piece of equipment is performing any activity the equipment is active and performing a function under load or not.  Example: For traditional machine tools, this includes <c>LOADED</c>, plus rapid moves, tool changes, etc.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		WORKING,
		/// <summary>
		﻿/// time that the major sub-parts of a piece of equipment are powered or performing any activity whether producing a part or product or not.  Example: For traditional machine tools, this includes <c>WORKING</c>, plus idle time.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		OPERATING,
		/// <summary>
		﻿/// time that primary power is applied to the piece of equipment and, as a minimum, the controller or logic portion of the piece of equipment is powered and functioning or components that are required to remain on are powered.  Example: Heaters for an extrusion machine that are required to be powered even when the equipment is turned off.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		POWERED,
		/// <summary>
		﻿/// elapsed time of a temporary halt of action.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		DELAY,
	}
}