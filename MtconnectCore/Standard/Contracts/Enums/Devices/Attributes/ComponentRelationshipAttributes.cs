using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    /// <summary>
    /// ComponentRelationship describes the association between two components within a piece of equipment that function independently but together perform a capability or service within a piece of equipment.
    /// </summary>
    /// <remarks>See Part 2 Section 9.2.1.2 of the MTConnect specification.</remarks>
    public enum ComponentRelationshipAttributes {
        /// <summary>
        /// A reference to the associated component element. The value provided for idRef MUST be the value provided for the id attribute of the associated Component element.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, Constants.ModelBrowserLinks.COMPONENT_RELATIONSHIP)]
        ID_REF
    }
}
