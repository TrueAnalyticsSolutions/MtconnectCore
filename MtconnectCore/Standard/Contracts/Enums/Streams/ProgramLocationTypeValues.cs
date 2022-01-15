using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="EventTypes.PROGRAM_LOCATION_TYPE"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 6.2")]
    public enum ProgramLocationTypeValues
    {
        /// <summary>
        /// Managed by the controller.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 6.2")]
        LOCAL,
        /// <summary>
        /// Not managed by the controller.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 6.2")]
        EXTERNAL
    }
}
