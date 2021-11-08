using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of EVENT <c>type</c> <see cref="EventTypes.COMPOSITION_STATE"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
    public enum CompositionStateSubTypes
    {
        /// <summary>
        /// An indication of the operating state of a mechanism represented by a  Composition type component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        ACTION,
        /// <summary>
        /// An indication of the position of a mechanism that may move in a lateral  direction. The mechanism is represented by a Composition type component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        LATERAL,
        /// <summary>
        /// An indication of the open or closed state of a mechanism. The  mechanism is represented by a Composition type component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        MOTION,
        /// <summary>
        /// An indication of the activation state of a mechanism represented by a  Composition type component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        SWITCHED,
        /// <summary>
        /// An indication of the position of a mechanism that may move in a vertical  direction. The mechanism is represented by a Composition type component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        VERTICAL
    }
}
