namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    /// <summary>
    /// Attributes of the abstract Relationship element
    /// </summary>
    /// <remarks>See Part 2 Section 9.2.1 of the MTConnect specification.</remarks>
    public enum RelationshipAttributes
    {
        /// <summary>
        /// The unique identifier for a Relationship element.
        /// </summary>
        ID,
        /// <summary>
        /// The name of an element or a piece of equipment.
        /// </summary>
        NAME,
        /// <summary>
        /// The type of either a structural element or a dataitem being measured.
        /// </summary>
        TYPE,
        /// <summary>
        /// Criticality
        /// </summary>
        CRITICALITY
    }
}
