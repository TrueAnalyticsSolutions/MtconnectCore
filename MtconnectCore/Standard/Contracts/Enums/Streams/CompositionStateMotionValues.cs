using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="EventElements.COMPOSITION_STATE"/> when the subType is MOTION
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
    public enum CompositionStateMotionValues
    {
        /// <summary>
        /// The position of the Composition element is open to the point of a positive confirmation
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        OPEN,
        /// <summary>
        /// The position of the Composition element is closed to the point of a positive confirmation
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        CLOSED,
        /// <summary>
        /// The position of the Composition element is not open to the point of a positive confirmation and is not closed to the point of a positive confirmation. It is in an intermediate position.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        UNLATCHED
    }
}
