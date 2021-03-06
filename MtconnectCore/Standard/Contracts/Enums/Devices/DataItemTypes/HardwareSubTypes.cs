using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of EVENT <c>type</c> <see cref="EventTypes.HARDWARE"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 8.2")]
    public enum HardwareSubTypes
    {
        /// <summary>
        /// The license code to validate or activate the hardware or software.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 8.2")]
        LICENSE,
        /// <summary>
        /// The version of the hardware or software.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 8.2")]
        VERSION,
        /// <summary>
        /// The date the hardware or software was released for general use.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 8.2")]
        RELEASE_DATE,
        /// <summary>
        /// The date the hardware or software was installed.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 8.2")]
        INSTALL_DATE,
        /// <summary>
        /// The corporate identity for the maker of the hardware or software.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 8.2")]
        MANUFACTURER
    }
}
