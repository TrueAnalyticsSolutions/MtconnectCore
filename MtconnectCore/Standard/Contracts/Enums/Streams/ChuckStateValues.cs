using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="EventElements.CHUCK_STATE"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
    public enum ChuckStateValues
    {
        /// <summary>
        /// The chuck is open to the point of a positive confirmation
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        OPEN,
        /// <summary>
        /// The chuck is closed to the point of a positive  confirmation
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        CLOSED,
        /// <summary>
        /// The chuck is not closed to the point of a positive  confirmation and not open to the point of a positive confirmation
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        UNLATCHED
    }
}
