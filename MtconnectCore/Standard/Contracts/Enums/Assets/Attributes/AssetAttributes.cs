namespace MtconnectCore.Standard.Contracts.Enums.Assets.Attributes
{
    public enum AssetAttributes
    {
        /// <summary>
        /// The unique identifier for the MTConnect Asset.
        /// </summary>
        ASSET_ID,
        /// <summary>
        /// The time this MTConnect Asset was last modified.
        /// </summary>
        TIMESTAMP,
        /// <summary>
        /// The piece of equipment’s UUID that supplied this data.
        /// </summary>
        DEVICE_UUID,
        /// <summary>
        /// This is an optional attribute that is an indicator that the MTConnect Asset has been removed from the piece of equipment.
        /// </summary>
        REMOVED
    }
}
