using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="EventElements.AVAILABILITY"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10")]
    public enum AvailabilityValues {
        /// <summary>
        /// The component is available.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10")]
        AVAILABLE,
        /// <summary>
        /// The component is not available.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10")]
        UNAVAILABLE
    }
}
