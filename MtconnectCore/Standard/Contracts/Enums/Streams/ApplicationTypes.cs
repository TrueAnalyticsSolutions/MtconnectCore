using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.1.2")]
    public enum ApplicationTypes
    {
        /// <summary>
        /// Computer aided design files or drawings.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.1.2")]
        DESIGN,
        /// <summary>
        /// Generic data.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.1.2")]
        DATA,
        /// <summary>
        /// Documentation regarding a category of file.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.1.2")]
        DOCUMENTATION,
        /// <summary>
        /// User instructions regarding the execution of a task.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.1.2")]
        INSTRUCTIONS,
        /// <summary>
        /// The data related to the history of a machine or process.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.1.2")]
        LOG,
        /// <summary>
        /// Machine instructions to perform a process.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.1.2")]
        PRODUCTION_PROGRAM
    }
}
