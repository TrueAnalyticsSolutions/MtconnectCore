using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum NetworkSubTypes
	{
		/// <summary>
		﻿/// IPV4 network address of the component. 
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		I_PV4_ADDRESS,
		/// <summary>
		﻿/// IPV6 network address of the component. 
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		I_PV6_ADDRESS,
		/// <summary>
		﻿/// Gateway for the component network.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		GATEWAY,
		/// <summary>
		﻿/// SubNet mask for the component network. 
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		SUBNET_MASK,
		/// <summary>
		﻿/// layer2 Virtual Local Network (VLAN) ID for the component network.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		V_LAN_ID,
		/// <summary>
		﻿/// Media Access Control Address.   The unique physical address of the network hardware. 
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		MAC_ADDRESS,
		/// <summary>
		﻿/// identifies whether the connection type is wireless.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		WIRELESS,
	}
}