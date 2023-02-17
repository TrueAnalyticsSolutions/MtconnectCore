﻿using MtconnectCore.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum PartKindIdSubTypes
	{
		/// <summary>
		﻿/// universally unique identifier as specified in ISO 11578 or RFC 4122.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		UUID,
		/// <summary>
		﻿/// identifier given to a group of parts having similarities in geometry, manufacturing process, and/or functions.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		PART_FAMILY,
		/// <summary>
		﻿/// word or set of words by which a part is known, addressed, or referred to.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		PART_NAME,
		/// <summary>
		﻿/// identifier of a particular part design or model.
		/// </summary>
		[MTConnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		PART_NUMBER,
	}
}