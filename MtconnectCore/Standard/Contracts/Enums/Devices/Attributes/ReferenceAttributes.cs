using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    /// <summary>
    /// Attributes available in the abstract Reference element in the MTConnect Response document.
    /// </summary>
    /// <remarks>See Part 2 Section 4.8 of the MTConnect specification.</remarks>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, Constants.ModelBrowserLinks.DeviceModel.REFERENCE)]
    public enum ReferenceAttributes {
        /// <summary>
        /// A pointer to the id attribute of the implemented Reference target that contains the information to be associated with this XML element.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, Constants.ModelBrowserLinks.DeviceModel.REFERENCE)]
        ID_REF,
        /// <summary>
        /// The optional name of the implemented Reference target. Only informative.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, Constants.ModelBrowserLinks.DeviceModel.REFERENCE)]
        NAME,
        /// <summary>
        /// pointer to the  DataItem::id that contains the information to be associated with this entity.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, Constants.ModelBrowserLinks.DeviceModel.REFERENCE, MtconnectVersions.V_1_4_0)]
        DATA_ITEM_ID,
        /// <summary>
        /// pointer to the  DataItem::id that contains the information to be associated with this entity.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, Constants.ModelBrowserLinks.DeviceModel.REFERENCE, MtconnectVersions.V_1_4_0)]
        REF_DATA_ITEM_ID,
    }
}
