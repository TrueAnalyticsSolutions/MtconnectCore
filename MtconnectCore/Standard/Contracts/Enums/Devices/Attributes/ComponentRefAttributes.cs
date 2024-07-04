using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    /// <summary>
    /// Attributes implemented from and extending that of the abstract Reference element in the context of a Component in the MTConnect Response document.
    /// </summary>
    /// <remarks>See Part 2 Section 4.8.1 of the MTConnect specification.</remarks>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, Constants.ModelBrowserLinks.DeviceModel.COMPONENT_REF)]
    public enum ComponentRefAttributes {
        /// <summary>
        /// A pointer to the id attribute of the Component that contains the information to be associated with this XML element.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, Constants.ModelBrowserLinks.DeviceModel.COMPONENT_REF)]
        ID_REF
    }
}
