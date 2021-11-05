using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.ANGLE"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1")]
    public enum AngleSubTypes {
        /// <summary>
        /// The angular position as read from the physical  component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1")]
        ACTUAL,
        /// <summary>
        /// The angular position computed by the Controller.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1")]
        COMMANDED
    }
}
