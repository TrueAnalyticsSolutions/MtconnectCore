namespace MtconnectCore.Standard.Contracts.Enums.Assets.Attributes
{
    public enum LocationAttributes {
        /// <summary>
        /// The type of location being identified.
        /// </summary>
        TYPE,
        /// <summary>
        /// The number of locations at higher index value from this location.
        /// </summary>
        POSITIVE_OVERLAP,
        /// <summary>
        /// The number of location at lower index values from this location.
        /// </summary>
        NEGATIVE_OVERLAP
    }
}
