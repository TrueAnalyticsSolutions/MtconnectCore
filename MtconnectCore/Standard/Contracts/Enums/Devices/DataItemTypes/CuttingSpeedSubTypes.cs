using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.CUTTING_SPEED"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
    public enum CuttingSpeedSubTypes
    {
        /// <summary>
        /// The measured value between the cutting mechanism and the surface of the workpiece it is operating on.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
        ACTUAL,
        /// <summary>
        /// The commanded value between the cutting mechanism and the surface of the workpiece it is operating on.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
        COMMANDED,
        /// <summary>
        /// The programmed value between the cutting mechanism and the surface of the workpiece it is operating on.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
        PROGRAMMED,
    }
}
