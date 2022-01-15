using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="EventTypes.COMPOSITION_STATE"/> when the subType is LATERAL
    /// </summary>
    public enum CompositionStateLateralValues
    {
        /// <summary>
        /// The position of the Composition element is oriented to the right to the point of a positive confirmation
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        RIGHT,
        /// <summary>
        /// The position of the Composition element is oriented to the left to the point of a positive confirmation
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        LEFT,
        /// <summary>
        /// The position of the Composition element is not oriented to the right to the point of a positive confirmation and is not oriented to the left to the point of a positive confirmation. It is in an intermediate position.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        TRANSITIONING
    }
}
