#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	﻿/// amount of time a piece of equipment or a sub-part of a piece of equipment has performed specific activities.
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580378218298_41713_1803">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.5.0.0")]
	public enum EquipmentTimerSubTypes
	{
		/// <summary>
		﻿/// elapsed time of a temporary halt of action.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		
		DELAY,
		/// <summary>
		﻿/// time that the sub-parts of a piece of equipment are under load.<br /><br /><br /><br />Example: For traditional machine tools, this is a measurement of the time that the cutting tool is assumed to be engaged with the part.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		
		LOADED,
		/// <summary>
		﻿/// time that the major sub-parts of a piece of equipment are powered or performing any activity whether producing a part or product or not.<br /><br /><br /><br />Example: For traditional machine tools, this includes <c>WORKING</c>, plus idle time.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		
		OPERATING,
		/// <summary>
		﻿/// time that primary power is applied to the piece of equipment and, as a minimum, the controller or logic portion of the piece of equipment is powered and functioning or components that are required to remain on are powered.<br /><br /><br /><br />Example: Heaters for an extrusion machine that are required to be powered even when the equipment is turned off.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		
		POWERED,
		/// <summary>
		﻿/// time that a piece of equipment is performing any activity the equipment is active and performing a function under load or not.<br /><br /><br /><br />Example: For traditional machine tools, this includes <c>LOADED</c>, plus rapid moves, tool changes, etc.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		
		WORKING,
	}
}