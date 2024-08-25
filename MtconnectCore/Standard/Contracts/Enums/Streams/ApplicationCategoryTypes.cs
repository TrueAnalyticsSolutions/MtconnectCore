using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.1.1")]
    public enum ApplicationCategoryEnum
    {
        /// <summary>
        /// Files regarding the fully assembled product.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.1.1")]
        ASSEMBLY,
        /// <summary>
        /// Device related files.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.1.1")]
        DEVICE,
        /// <summary>
        /// Files relating to the handling of material.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.1.1")]
        HANDLING,
        /// <summary>
        /// File relating to equipment maintenance.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.1.1")]
        MAINTENANCE,
        /// <summary>
        /// Files relating to a part.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.1.1")]
        PART,
        /// <summary>
        /// Files related to the manufacturing process.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.1.1")]
        PROCESS,
        /// <summary>
        /// Files related to the quality inspection.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.1.1")]
        INSPECTION,
        /// <summary>
        /// Files related to the setup of a process.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.1.1")]
        SETUP
    }
}
