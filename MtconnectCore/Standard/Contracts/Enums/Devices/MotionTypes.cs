using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Documents.Devices;

namespace MtconnectCore.Standard.Contracts.Enums.Devices
{
    /// <summary>
    /// Available options for the <see cref="Motion.Type"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.1.1")]
    public enum MotionTypes
    {
        /// <summary>
        /// Rotates around an axis with a fixed range of motion.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.1.1")]
        REVOLUTE,
        /// <summary>
        /// Revolves around an axis with a continuous range of motion.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.1.1")]
        CONTINUOUS,
        /// <summary>
        /// Sliding linear motinon along an axis with a fixed range of motion.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.1.1")]
        PRISMATIC,
        /// <summary>
        /// The axis does not move.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.1.1")]
        FIXED
    }
}
