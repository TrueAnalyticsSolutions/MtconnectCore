using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.ComponentTypes
{
    /// <summary>
    /// Structure is a Component that organizes the parts comprising the rigid bodies of the piece of equipment.
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 5.8")]
    public enum StructureSubComponentTypes
    {
        /// <summary>
        /// Link is a structural Component providing a connection between Components.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 5.8.1")]
        LINK
    }
}
