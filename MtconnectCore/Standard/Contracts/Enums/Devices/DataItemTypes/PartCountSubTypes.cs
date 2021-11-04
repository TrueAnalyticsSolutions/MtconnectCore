namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of EVENT <c>type</c> <see cref="EventTypes.PART_COUNT"/>
    /// </summary>
    public enum PartCountSubTypes {
        /// <summary>
        /// The count of all the parts produced. If the subtype is not given, this is the default. 
        /// </summary>
        ALL,
        /// <summary>
        /// Indicates the count of correct parts made. 
        /// </summary>
        GOOD,
        /// <summary>
        /// Indicates the count of incorrect parts produced.
        /// </summary>
        BAD
    }
}
