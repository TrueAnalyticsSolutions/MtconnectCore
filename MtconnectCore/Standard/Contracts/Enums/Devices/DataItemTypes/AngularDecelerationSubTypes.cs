using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c> of SAMPLE <c>type</c> <see cref="SampleTypes.ANGULAR_DECELERATION"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.1")]
    public enum AngularDecelerationSubTypes
    {
        /// <summary>
        /// The measured value.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.1")]
        ACTUAL,
        /// <summary>
        /// The commanded value.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.1")]
        COMMANDED,
        /// <summary>
        /// The programmed value.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.1")]
        PROGRAMMED
    }
}
