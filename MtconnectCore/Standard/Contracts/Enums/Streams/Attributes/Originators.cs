using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams.Attributes
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.1.1")]
    public enum Originators
    {
        /// <summary>
        /// The manufacturer of a piece of equipment or Component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.1.1")]
        MANUFACTURER,
        /// <summary>
        /// The owner or implementer of a piece of equipment or Component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.1.1")]
        USER
    }
}
