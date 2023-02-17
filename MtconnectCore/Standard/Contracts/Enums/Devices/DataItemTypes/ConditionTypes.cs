using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum ConditionTypes
	{
		/// <summary>
		﻿/// {{def(ConditionEnum:ACTUATOR)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		ACTUATOR,
		/// <summary>
		﻿/// {{def(ConditionEnum:COMMUNICATIONS)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		COMMUNICATIONS,
		/// <summary>
		﻿/// {{def(ConditionEnum:DATA_RANGE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		DATA_RANGE,
		/// <summary>
		﻿/// {{def(ConditionEnum:LOGIC_PROGRAM)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		LOGIC_PROGRAM,
		/// <summary>
		﻿/// {{def(ConditionEnum:MOTION_PROGRAM)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		MOTION_PROGRAM,
		/// <summary>
		﻿/// {{def(ConditionEnum:SYSTEM)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		SYSTEM,
	}
}