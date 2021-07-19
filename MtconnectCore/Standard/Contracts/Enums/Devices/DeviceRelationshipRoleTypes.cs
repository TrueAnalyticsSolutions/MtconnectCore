using MtconnectCore.Standard.Documents.Devices;

namespace MtconnectCore.Standard.Contracts.Enums.Devices
{
    /// <summary>
    /// Available options for a <see cref="DeviceRelationship.Role"/>
    /// </summary>
    public enum DeviceRelationshipRoleTypes {
        /// <summary>
        /// The associated piece of equipment performs the functions of a System for this piece of equipment. In MTConnect, System provides utility type services to support the operation of a piece of equipment and these services are required for the operation of a piece of equipment.
        /// </summary>
        SYSTEM,
        /// <summary>
        /// The associated piece of equipment performs the functions as an Auxiliary for this piece of equipment. In MTConnect, Auxiliary extends the capabilities of a piece of equipment, but is not required for the equipment to function.
        /// </summary>
        AUXILIARY
    }
}
