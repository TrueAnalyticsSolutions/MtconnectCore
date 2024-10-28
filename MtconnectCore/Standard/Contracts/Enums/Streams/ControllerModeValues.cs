#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
	/// <summary>
	﻿/// current mode of the <see cref="Controller">Controller</see> component.
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580378218235_737319_1656">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.5.0.0")]
	public enum ControllerModeValues
	{
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Controller">Controller</see> is configured to automatically execute a program.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		AUTOMATIC,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Controller">Controller</see> is not executing an active program. <br /><br /><br /><br />It is capable of receiving instructions from an external source – typically an operator. The <see cref="Controller">Controller</see> executes operations based on the instructions received from the external source.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		MANUAL,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />operator can enter a series of operations for the <see cref="Controller">Controller</see> to perform.<br /><br /><br /><br />The <see cref="Controller">Controller</see> will execute this specific series of operations and then stop.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		MANUAL_DATA_INPUT,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Controller">Controller</see> is operating in a mode that restricts the active program from processing its next process step without operator intervention.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		SEMI_AUTOMATIC,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />axes of the device are commanded to stop, but the spindle continues to function.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// <item><b>Deprecated</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		[Obsolete("Deprecated in v1.3 according to https://model.mtconnect.org/#_Version_1.3")]
		FEED_HOLD,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Controller">Controller</see> is currently functioning as a programming device and is not capable of executing an active program.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		EDIT,
	}
}