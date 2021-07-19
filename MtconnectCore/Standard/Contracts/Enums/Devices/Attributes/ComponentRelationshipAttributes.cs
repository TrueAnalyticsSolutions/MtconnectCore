namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    /// <summary>
    /// ComponentRelationship describes the association between two components within a piece of equipment that function independently but together perform a capability or service within a piece of equipment.
    /// </summary>
    /// <remarks>See Part 2 Section 9.2.1.2 of the MTConnect specification.</remarks>
    public enum ComponentRelationshipAttributes {
        /// <summary>
        /// The unique identifier for this ComponentRelationship.
        /// </summary>
        ID,
        /// <summary>
        /// The name associated with this ComponentRelationship. name is provided as an additional human readable identifier for this ComponentRelationship.
        /// </summary>
        NAME,
        /// <summary>
        /// Defines the authority that this component element has relative to the associated component element.
        /// </summary>
        /// <remarks>The value provided for <see cref="TYPE"/> MUST be one of the following values:
        /// <list type="bullet">
        /// <item>PARENT: This component functions as a parent in the relationship with the associated component element.</item>
        /// <item>CHILD: This component functions as a child in the relationship with the associated component element.</item>
        /// <item>CHILD: This component functions as a child in the relationship with the associated component element.</item>
        /// </list>
        /// </remarks>
        TYPE,
        /// <summary>
        /// Defines whether the services or functions provided by the associated component element is required for the operation of this piece of equipment.
        /// </summary>
        /// <remarks>The value provided for <see cref="ID_REF"/> MUST be one of the following values:
        /// <list type="bullet">
        /// <item>CRITICAL: The services or functions provided by the associated component element is required for the operation of this piece of equipment.</item>
        /// <item>NONCRITICAL: The services or functions provided by the associated component element is not required for the operation of this piece of equipment.</item>
        /// </list>
        /// </remarks>
        CRITICALITY,
        /// <summary>
        /// A reference to the associated component element. The value provided for idRef MUST be the value provided for the id attribute of the associated Component element.
        /// </summary>
        ID_REF
    }
}
