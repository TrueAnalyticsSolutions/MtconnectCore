#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration___19_0_3_91b028d_1587752011247_360664_3696">model.mtconnect.org</seealso>
	﻿	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "1.0.15.3")]
	public enum NetworkSubTypes
	{
		/// <summary>
		﻿/// IPV4 network address of the component. 
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		IPV4_ADDRESS,
		/// <summary>
		﻿/// IPV6 network address of the component. 
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		IPV6_ADDRESS,
		/// <summary>
		﻿/// Gateway for the component network.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		GATEWAY,
		/// <summary>
		﻿/// SubNet mask for the component network. 
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		SUBNET_MASK,
		/// <summary>
		﻿/// layer2 Virtual Local Network (VLAN) ID for the component network.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		VLAN_ID,
		/// <summary>
		﻿/// Media Access Control Address.   The unique physical address of the network hardware. 
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		MAC_ADDRESS,
		/// <summary>
		﻿/// identifies whether the connection type is wireless.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		WIRELESS,
	}
}