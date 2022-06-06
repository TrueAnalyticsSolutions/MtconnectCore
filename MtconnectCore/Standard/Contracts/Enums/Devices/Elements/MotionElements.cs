using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Elements
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.2")]
    public enum MotionElements
    {
        /// <summary>
        /// An element that can contain any descriptive content.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.2")]
        DESCRIPTION,
        /// <summary>
        /// Axis defines the axis along or around which the COmponent moves relative to a coordinate system.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.2")]
        AXIS,
        /// <summary>
        /// A fixed point from which measurement or motion commences.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.2")]
        ORIGIN,
        /// <summary>
        /// The Transformation of the parent Origin or Transformation using Translation and Rotation.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.2")]
        TRANSFORMATION
    }
}
