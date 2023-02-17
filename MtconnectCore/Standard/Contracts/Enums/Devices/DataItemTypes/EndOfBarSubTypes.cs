using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum EndOfBarSubTypes
	{
		/// <summary>
		﻿/// specific applications <b>MAY</b> reference one or more locations on a piece of bar stock as the indication for the <see cref="EndOfBar">EndOfBar</see>.   The main or most important location <b>MUST</b> be designated as the <see cref="PRIMARY">PRIMARY</see> indication for the <see cref="EndOfBar">EndOfBar</see>.  If no <see cref="subType">subType</see> is specified, <see cref="PRIMARY">PRIMARY</see> <b>MUST</b> be the default <see cref="EndOfBar">EndOfBar</see> indication.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		PRIMARY,
		/// <summary>
		﻿/// when multiple locations on a piece of bar stock are referenced as the indication for the <see cref="EndOfBar">EndOfBar</see>, the additional location(s) <b>MUST</b> be designated as <c>AUXILIARY</c> indication(s) for the <see cref="EndOfBar">EndOfBar</see>.  
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		AUXILIARY,
	}
}