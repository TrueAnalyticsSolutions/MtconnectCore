using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of EVENT <c>type</c> <see cref="EventTypes.TOOL_OFFSET"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
    public enum ToolOffsetSubTypes
    {
        /// <summary>
        /// A reference to a radial type tool offset variable.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        RADIAL,
        /// <summary>
        /// A reference to a length type tool offset variable.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        LENGTH
    }
}
