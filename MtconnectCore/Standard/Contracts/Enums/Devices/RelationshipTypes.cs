using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Documents.Devices;

namespace MtconnectCore.Standard.Contracts.Enums.Devices
{
    /// <summary>
    /// Available options for a <see cref="ConfigurationRelationship.Type"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 4.10.1")]
    public enum RelationshipTypes {
        /// <summary>
        /// This piece of equipment functions as a parent in the relationship with the associated piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 4.10.1")]
        PARENT,
        /// <summary>
        /// This piece of equipment functions as a child in the relationship with the associated piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 4.10.1")]
        CHILD,
        /// <summary>
        /// This piece of equipment functions as a peer which provides equal functionality and capabilities in the relationship with the associated piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 4.10.1")]
        PEER
    }
}
