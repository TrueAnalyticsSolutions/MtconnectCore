using MtconnectCore.Standard.Documents.Devices;

namespace MtconnectCore.Standard.Contracts.Enums.Devices
{
    /// <summary>
    /// Available options for a <see cref="Relationship.Type"/>
    /// </summary>
    public enum RelationshipTypes {
        /// <summary>
        /// This piece of equipment functions as a parent in the relationship with the associated piece of equipment.
        /// </summary>
        PARENT,
        /// <summary>
        /// This piece of equipment functions as a child in the relationship with the associated piece of equipment.
        /// </summary>
        CHILD,
        /// <summary>
        /// This piece of equipment functions as a peer which provides equal functionality and capabilities in the relationship with the associated piece of equipment.
        /// </summary>
        PEER
    }
}
