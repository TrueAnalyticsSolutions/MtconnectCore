namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    public enum EntryDefinitionAttributes {
        /// <summary>
        /// The unique identification of the Entry in the Definition. The description applies to all Entry observations having this key.
        /// </summary>
        KEY,
        /// <summary>
        /// Same as DataItem units. See Section 7.2.2.5 - units Attribute for DataItem. Only valid for representation of DATA_SET.
        /// </summary>
        UNITS,
        /// <summary>
        /// Same as DataItem type. See Section 8 - Listing of Data Items.
        /// </summary>
        TYPE,
        /// <summary>
        /// Same as DataItem subType. See Section 8 - Listing of Data Items.
        /// </summary>
        SUB_TYPE
    }
}
