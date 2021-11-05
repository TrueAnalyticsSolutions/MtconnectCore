using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.PATH_POSITION"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.1")]
    public enum PathPositionSubTypes {
        /// <summary>
        /// The position of the Component as read from the  device.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.1")]
        ACTUAL,
        /// <summary>
        /// The position computed by the Controller.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.1")]
        COMMANDED,
        /// <summary>
        /// The target position for the movement.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.1")]
        TARGET,
        /// <summary>
        /// The position provided by a probe
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.1")]
        PROBE
    }
}
