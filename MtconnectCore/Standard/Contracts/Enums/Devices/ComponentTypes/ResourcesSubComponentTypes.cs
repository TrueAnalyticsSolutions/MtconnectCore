using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.ComponentTypes
{
    /// <summary>
    /// Sub-components of <see cref="ComponentTypes.RESOURCES"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 5.5")]
    public enum ResourcesSubComponentTypes
    {
        /// <summary>
        /// Materials is an XML container that provides information about materials or other items consumed or used by the piece of equipment for production of parts, materials, or other types of goods. Materials also represents parts or part stock that are present at a piece of equipment or location to which work is applied to transform the part or stock material into a more finished state.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 5.5.1")]
        MATERIALS,
        /// <summary>
        /// Personnel is an XML container that provides information about an individual or individuals who either control, support, or otherwise interface with a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 5.5.2")]
        PERSONNEL,
        /// <summary>
        /// Stock is an XML container that represents the information for the material that is used in a manufacturing process and to which work is applied in a machine or piece of equipment to produce parts. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 5.5.1.1")]
        STOCK
    }
}
