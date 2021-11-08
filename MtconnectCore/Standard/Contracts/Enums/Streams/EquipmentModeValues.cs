using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="EventElements.EQUIPMENT_MODE"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
    public enum EquipmentModeValues
    {
        /// <summary>
        /// The equipment is functioning in the mode  designated by the subType
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        ON,
        /// <summary>
        /// The equipment is not functioning in th mode designated by the subType.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        OFF
    }
}
