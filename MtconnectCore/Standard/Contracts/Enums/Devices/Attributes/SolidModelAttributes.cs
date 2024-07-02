using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, Constants.ModelBrowserLinks.SOLID_MODEL)]
    public enum SolidModelAttributes
    {
        /// <summary>
        /// The unique identifier for this entity within the MTConnectDevices document.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, Constants.ModelBrowserLinks.SOLID_MODEL)]
        ID,
        /// <summary>
        /// The associated model file if an item reference is used.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, Constants.ModelBrowserLinks.SOLID_MODEL)]
        SOLID_MODEL_ID_REF,
        /// <summary>
        /// The URL giving the location of the Solid Model. If not present, the model referenced in the solidModelIdRef is used.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, Constants.ModelBrowserLinks.SOLID_MODEL)]
        HREF,
        /// <summary>
        /// The reference to the item within the model within the related geometry. A solidModelIdRef MUST be given.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, Constants.ModelBrowserLinks.SOLID_MODEL)]
        ITEM_REF,
        /// <summary>
        /// The format of the referenced document.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, Constants.ModelBrowserLinks.SOLID_MODEL)]
        MEDIA_TYPE,
        /// <summary>
        /// A reference to the coordinate system for this SolidModel.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, Constants.ModelBrowserLinks.SOLID_MODEL)]
        COORDINATE_SYSTEM_ID_REF,
        /// <summary>
        /// same as  DataItem::nativeUnits. See Section DataItem.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_2_0_0, Constants.ModelBrowserLinks.SOLID_MODEL)]
        NATIVE_UNITS,
        /// <summary>
        /// same as  DataItem::units. See Section DataItem.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_2_0_0, Constants.ModelBrowserLinks.SOLID_MODEL)]
        UNITS,
    }
}
