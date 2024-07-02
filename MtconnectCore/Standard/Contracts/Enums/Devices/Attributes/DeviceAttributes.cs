using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DEVICE)]
    public enum DeviceAttributes
    {
        /// <summary>
        /// DEPRECATED in MTConnect Version 1.2.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DEVICE, MtconnectVersions.V_1_2_0)]
        ISO_841_CLASS,
        /// <summary>
        /// universally unique identifier for the element.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DEVICE)]
        UUID,
        /// <summary>
        /// MTConnect version of the Device Information Model used to configure the information to be published for a piece of equipment in an MTConnect Response Document.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, Constants.ModelBrowserLinks.DEVICE)]
        MTCONNECT_VERSION,
        /// <summary>
        /// name of an element or a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DEVICE)]
        NAME,
        /// <summary>
        /// condensed message digest from a secure one-way hash function. FIPS PUB 180-4
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, Constants.ModelBrowserLinks.DEVICE)]
        HASH,
    }
}
