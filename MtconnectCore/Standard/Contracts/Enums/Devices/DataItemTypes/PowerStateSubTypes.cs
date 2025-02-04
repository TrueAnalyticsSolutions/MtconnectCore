#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	﻿/// indication of the status of the source of energy for an entity to allow it to perform its intended function or the state of an enabling signal providing permission for the entity to perform its functions.
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580378218405_135132_2064">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.5.0.0")]
	public enum PowerStateSubTypes
	{
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />source of energy for an entity or the enabling signal providing permission for the entity to perform its function(s) is not present or is disconnected.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		OFF,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />source of energy for an entity or the enabling signal providing permission for the entity to perform its function(s) is present and active.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		ON,
	}
}