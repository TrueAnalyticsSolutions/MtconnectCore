using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    /// <summary>
    /// Attributes of the abstract Relationship element
    /// </summary>
    /// <remarks>See Part 2 Section 9.2.1 of the MTConnect specification.</remarks>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, Constants.ModelBrowserLinks.CONFIGURATION_RELATIONSHIP)]
    public enum ConfigurationRelationshipAttributes
    {
        /// <summary>
        /// name associated with this ConfigurationRelationship.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, Constants.ModelBrowserLinks.CONFIGURATION_RELATIONSHIP)]
        NAME,
        /// <summary>
        /// unique identifier for this ConfigurationRelationship.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, Constants.ModelBrowserLinks.CONFIGURATION_RELATIONSHIP)]
        ID,
        /// <summary>
        /// defines the authority that this piece of equipment has relative to the associated piece of equipment. The type MUST be specified
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, Constants.ModelBrowserLinks.CONFIGURATION_RELATIONSHIP)]
        TYPE,
        /// <summary>
        /// defines whether the services or functions provided by the associated piece of equipment is required for the operation of this piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, Constants.ModelBrowserLinks.CONFIGURATION_RELATIONSHIP)]
        CRITICALITY,
    }
}
