using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.1")]
    public enum MotionAttributes
    {
        /// <summary>
        /// The unique identifier for this element. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.1")]
        ID,
        /// <summary>
        /// A pointer to the id attribute of the parent Motion. The kinematic chain connects all components using the parent relations. All motion is connected to the motion of the parent.The first node in the chain will not have a parent.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.1")]
        PARENT_ID_REF,
        /// <summary>
        /// The coordinate system within which the kinematic motion occurs.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.1")]
        COORDINATE_SYSTEM_ID_REF,
        /// <summary>
        /// Describes the type of motion.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.1")]
        TYPE,
        /// <summary>
        /// Describes if this Component is actuated directly or indirectly as a result of other motion.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.1")]
        ACTUATION
    }
}
