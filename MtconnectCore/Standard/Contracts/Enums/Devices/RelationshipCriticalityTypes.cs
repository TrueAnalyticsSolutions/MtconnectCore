using MtconnectCore.Standard.Documents.Devices;

namespace MtconnectCore.Standard.Contracts.Enums.Devices
{
    /// <summary>
    /// Available options for a <see cref="Relationship.Criticality"/>.
    /// </summary>
    public enum RelationshipCriticalityTypes {
        /// <summary>
        /// The services or functions provided by the associated piece of equipment is required for the operation of this piece of equipment.
        /// </summary>
        CRITICAL,
        /// <summary>
        /// The services or functions provided by the associated piece of equipment is not required for the operation of this piece of equipment.
        /// </summary>
        NONCRITICAL
    }
}
