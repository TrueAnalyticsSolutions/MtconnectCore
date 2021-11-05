using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="EventElements.DOOR_STATE"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
    public enum DoorStateValues {
        /// <summary>
        /// The door is opened.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
        OPEN,
        /// <summary>
        /// The door is closed.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
        CLOSED
    }
}
