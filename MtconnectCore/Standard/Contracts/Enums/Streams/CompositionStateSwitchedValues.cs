using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="EventTypes.COMPOSITION_STATE"/> when the subType is SWITCHED
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
    public enum CompositionStateSwitchedValues
    {
        /// <summary>
        /// The activation state of the Compositio element is in an ON condition, it is operating, or it is powered.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        ON,
        /// <summary>
        /// The activation state of the Compositio element is in an OFF condition, it is not operating, or it is not powered.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        OFF
    }
}
