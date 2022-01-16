using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of EVENT <c>type</c> <see cref="EventTypes.NETWORK"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 8.2")]
    public enum NetworkSubTypes
    {
        /// <summary>
        /// The IPV4 network address of the component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 8.2")]
        IPV4_ADDRESS,
        /// <summary>
        /// The IPV6 network address of the component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 8.2")]
        IPV6_ADDRESS,
        /// <summary>
        /// The Gateway for the component network.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 8.2")]
        GATEWAY,
        /// <summary>
        /// The SubNet mask for the component network.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 8.2")]
        SUBNET_MASK,
        /// <summary>
        /// The layer2 Virtual Local Network (VLAN) ID for the component network.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 8.2")]
        VLAN_ID,
        /// <summary>
        /// Media Access Control Address. The unique physical address of the network hardware.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 8.2")]
        MAC_ADDRESS,
        /// <summary>
        /// Identifies whether the connection type is wireless.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 8.2")]
        WIRELESS
    }
}
