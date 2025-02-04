using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    /// <summary>
    /// Attributes implemented from and extending that of the abstract Reference element in the context of a DataItem in the MTConnect Response document.
    /// </summary>
    /// <remarks>See Part 2 Section 4.8.2 of the MTConnect specification.</remarks>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, Constants.ModelBrowserLinks.DeviceModel.DATA_ITEM_REF)]
    public enum DataItemRefAttributes {
        /// <summary>
        /// A pointer to the id attribute of the DataItem that contains the information to be associated with this XML element.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, Constants.ModelBrowserLinks.DeviceModel.DATA_ITEM_REF)]
        ID_REF,
    }
}
