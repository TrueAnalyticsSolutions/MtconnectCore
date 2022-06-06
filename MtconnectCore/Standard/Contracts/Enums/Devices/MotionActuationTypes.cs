using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Documents.Devices;

namespace MtconnectCore.Standard.Contracts.Enums.Devices
{
    /// <summary>
    /// Available options for the <see cref="Motion.Actuation"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.1.2")]
    public enum MotionActuationTypes
    {
        /// <summary>
        /// The movement is initiated by the Component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.1.2")]
        DIRECT,
        /// <summary>
        /// The motion is computed and is used for expressing an imaginary movement.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.1.2")]
        VIRTUAL,
        /// <summary>
        /// There is not actuation of this Axis.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.1.2")]
        NONE
    }
}
