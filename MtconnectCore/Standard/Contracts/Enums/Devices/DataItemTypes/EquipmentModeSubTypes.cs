using MtconnectCore.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MTConnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum EquipmentModeSubTypes
	{
		/// <summary>
		﻿/// indication that the sub-parts of a piece of equipment are under load.  Example: For traditional machine tools, this is an indication that the cutting tool is assumed to be engaged with the part.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		LOADED,
		/// <summary>
		﻿/// indication that a piece of equipment is performing any activity, the equipment is active and performing a function under load or not.  Example: For traditional machine tools, this includes when the piece of equipment is <c>LOADED</c>, making rapid moves, executing a tool change, etc.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		WORKING,
		/// <summary>
		﻿/// indication that the major sub-parts of a piece of equipment are powered or performing any activity whether producing a part or product or not.  Example: For traditional machine tools, this includes when the piece of equipment is <c>WORKING</c> or it is idle.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		OPERATING,
		/// <summary>
		﻿/// indication that primary power is applied to the piece of equipment and, as a minimum, the controller or logic portion of the piece of equipment is powered and functioning or components that are required to remain on are powered.  Example: Heaters for an extrusion machine that required to be powered even when the equipment is turned off.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		POWERED,
		/// <summary>
		﻿/// elapsed time of a temporary halt of action.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		DELAY,
	}
}