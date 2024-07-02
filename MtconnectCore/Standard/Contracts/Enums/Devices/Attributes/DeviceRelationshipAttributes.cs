using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    /// <summary>
    /// DeviceRelationship describes the association between two pieces of equipment that function independently but together perform a manufacturing operation.
    /// </summary>
    /// <remarks>See Part 2 Section 9.2.1.1 of the MTConnect specification.</remarks>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, Constants.ModelBrowserLinks.DEVICE_RELATIONSHIP)]
    public enum DeviceRelationshipAttributes
    {
        /// <summary>
        /// A reference to the associated piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, Constants.ModelBrowserLinks.DEVICE_RELATIONSHIP)]
        DEVICE_UUID_REF,
        /// <summary>
        /// A URI identifying the Agent that is publishing information for the associated piece of equipment. <see cref="HREF"/> MUST also include the <see cref="DEVICE_UUID_REF"/> for that specific piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, Constants.ModelBrowserLinks.DEVICE_RELATIONSHIP)]
        HREF,
        /// <summary>
        /// Defines the services or capabilities that the referenced piece of equipment provides relative to this piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, Constants.ModelBrowserLinks.DEVICE_RELATIONSHIP)]
        ROLE,
        /// <summary>
        /// xlink:typeMUST have a fixed value of locator as defined in W3C XLink 1.1 https://www.w3.org/TR/xlink11/.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, Constants.ModelBrowserLinks.DEVICE_RELATIONSHIP)]
        XLINK_TYPE,
    }
}
