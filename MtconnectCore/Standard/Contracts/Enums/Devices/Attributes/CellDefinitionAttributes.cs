using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    public enum CellDefinitionAttributes
    {
        /// <summary>
        /// same as  DataItem::units.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.DeviceModel.CELL_DEFINITION)]
        UNITS,
        /// <summary>
        /// unique identification of the  Cell in the  Definition. The description applies to all  Cell observations having this  CellDefinition::key.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.DeviceModel.CELL_DEFINITION)]
        KEY,
        /// <summary>
        /// same as  DataItem::type.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.DeviceModel.CELL_DEFINITION)]
        TYPE,
        /// <summary>
        /// same as  DataItem::subType.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, Constants.ModelBrowserLinks.DeviceModel.CELL_DEFINITION)]
        SUB_TYPE,
        /// <summary>
        ///  DataItem::type that defines the meaning of  CellDefinition::key.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, Constants.ModelBrowserLinks.DeviceModel.CELL_DEFINITION)]
        KEY_TYPE,
    }
}
