using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum ControllerModeValues
	{
		/// <summary>
		﻿/// <see cref="Controller">Controller</see> is configured to automatically execute a program.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		AUTOMATIC,
		/// <summary>
		﻿/// <see cref="Controller">Controller</see> is not executing an active program.   It is capable of receiving instructions from an external source – typically an operator. The <see cref="Controller">Controller</see> executes operations based on the instructions received from the external source.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		MANUAL,
		/// <summary>
		﻿/// operator can enter a series of operations for the <see cref="Controller">Controller</see> to perform.  The <see cref="Controller">Controller</see> will execute this specific series of operations and then stop.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		MANUAL_DATA_INPUT,
		/// <summary>
		﻿/// <see cref="Controller">Controller</see> is operating in a mode that restricts the active program from processing its next process step without operator intervention.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		SEMI_AUTOMATIC,
		/// <summary>
		﻿/// <see cref="Controller">Controller</see> is currently functioning as a programming device and is not capable of executing an active program.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		EDIT,
		/// <summary>
		﻿/// axes of the device are commanded to stop, but the spindle continues to function.
		/// </summary>
		[Obsolete("Deprecated according to https://model.mtconnect.org/")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/", MtconnectVersions.V_1_3_0)]
		FEED_HOLD,
	}
}