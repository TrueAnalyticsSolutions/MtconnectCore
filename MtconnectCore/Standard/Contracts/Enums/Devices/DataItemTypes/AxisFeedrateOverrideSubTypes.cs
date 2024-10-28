#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	﻿/// value of a signal or calculation issued to adjust the feedrate of an individual linear type axis.
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580378218198_335017_1581">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#_Version_1.3")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.5.0.0")]
	public enum AxisFeedrateOverrideSubTypes
	{
		/// <summary>
		﻿/// relating to momentary activation of a function or a movement.<br /><br /><br /><br /><b>DEPRECATION WARNING</b>: May be deprecated in the future.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br />When the <c>JOG</c> subtype of <c>AxisFeedrateOverride</c> is applied, the resulting commanded feedrate for the axis is limited to the value of the original <c>JOG</c> subtype of the <c>AxisFeedrate</c> multiplied by the value of the <c>JOG</c> subtype of<br /><br /><c>AxisFeedrateOverride</c>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#_Version_1.3")]
		
		
		JOG,
		/// <summary>
		﻿/// directive value without offsets and adjustments.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#_Version_1.3")]
		
		
		PROGRAMMED,
		/// <summary>
		﻿/// performing an operation faster or in less time than nominal rate.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#_Version_1.3")]
		
		
		RAPID,
	}
}