namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    /// <summary>
    /// DeviceRelationship describes the association between two pieces of equipment that function independently but together perform a manufacturing operation.
    /// </summary>
    /// <remarks>See Part 2 Section 9.2.1.1 of the MTConnect specification.</remarks>
    public enum DeviceRelationshipAttributes
    {
        /// <summary>
        /// The unique identifier for this DeviceRelationship.
        /// </summary>
        ID,
        /// <summary>
        /// The name associated with this DeviceRelationship.
        /// </summary>
        NAME,
        /// <summary>
        /// Defines the authority that this piece of equipment has relative to the associated piece of equipment.
        /// </summary>
        /// <remarks>The value provided for <see cref="TYPE"/> MUST be one of the following values:
        /// <list type="bullet">
        /// <item>PARENT: This piece of equipment functions as a parent in the relationship with the associated piece of equipment.</item>
        /// <item>CHILD: This piece of equipment functions as a child in the relationship with the associated piece of equipment.</item>
        /// <item>PEER: This piece of equipment functions as a peer which provides equal functionality and capabilities in the relationship with the associated piece of equipment.</item>
        /// </list></remarks>
        TYPE,
        /// <summary>
        /// Defines whether the services or functions provided by the associated piece of equipment is required for the operation of this piece of equipment.
        /// </summary>
        /// <remarks>The value provided for <see cref="CRITICALITY"/> MUST be one of the following values:
        /// <list type="bullet">
        /// <item>CRITICAL: The services or functions provided by the associated piece of equipment is required for the operation of this piece of equipment.</item>
        /// <item>NONCRITICAL: The services or functions provided by the associated piece of equipment is not required for the operation of this piece of equipment.</item>
        /// </list>
        /// </remarks>
        CRITICALITY,
        /// <summary>
        /// A reference to the associated piece of equipment.
        /// </summary>
        DEVICE_UUID_REF,
        /// <summary>
        /// Defines the services or capabilities that the referenced piece of equipment provides relative to this piece of equipment.
        /// </summary>
        ROLE,
        /// <summary>
        /// A URI identifying the Agent that is publishing information for the associated piece of equipment. <see cref="HREF"/> MUST also include the <see cref="DEVICE_UUID_REF"/> for that specific piece of equipment.
        /// </summary>
        HREF
    }
}
