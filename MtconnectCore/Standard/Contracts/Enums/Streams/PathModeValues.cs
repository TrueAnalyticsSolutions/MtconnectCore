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
	public enum PathModeValues
	{
		/// <summary>
		﻿/// path is operating independently and without the influence of another path.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		INDEPENDENT,
		/// <summary>
		﻿/// path provides information or state values that influences the operation of other <see cref="DataItem">DataItem</see> of similar type.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		MASTER,
		/// <summary>
		﻿/// physical or logical parts which are not physically connected to each other but are operating together.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		SYNCHRONOUS,
		/// <summary>
		﻿/// axes associated with the path are mirroring the motion of the <c>MASTER</c> path.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		MIRROR,
	}
}