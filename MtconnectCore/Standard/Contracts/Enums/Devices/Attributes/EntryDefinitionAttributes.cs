using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.DeviceModel.ENTRY_DEFINITION)]
    public enum EntryDefinitionAttributes {
        /// <summary>
        /// The unique identification of the Entry in the Definition. The description applies to all Entry observations having this key.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.DeviceModel.ENTRY_DEFINITION)]
        KEY,
        /// <summary>
        /// Same as DataItem units. See Section 7.2.2.5 - units Attribute for DataItem. Only valid for representation of DATA_SET.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.DeviceModel.ENTRY_DEFINITION)]
        UNITS,
        /// <summary>
        /// Same as DataItem type. See Section 8 - Listing of Data Items.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.DeviceModel.ENTRY_DEFINITION)]
        TYPE,
        /// <summary>
        /// Same as DataItem subType. See Section 8 - Listing of Data Items.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, Constants.ModelBrowserLinks.DeviceModel.ENTRY_DEFINITION)]
        SUB_TYPE,
        /// <summary>
        ///  DataItem::type that defines the meaning of  EntryDefinition::key.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, Constants.ModelBrowserLinks.DeviceModel.ENTRY_DEFINITION)]
        KEY_TYPE,
    }
}
