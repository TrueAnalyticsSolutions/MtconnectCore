using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams.Elements
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.2")]
    public enum AbstractFileElements
    {
        /// <summary>
        /// FileProperties organizes one or more FileProperty entities for Files.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.2")]
        FILE_PROPERTIES,
        /// <summary>
        /// A key-value pair providing additional metadata about a File.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.2")]
        FILE_PROPERTY,
        /// <summary>
        /// FileComments organizes one or more FileComment entities for Files.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.2")]
        FILE_COMMENTS,
        /// <summary>
        /// A remark or interpretation for human interpretation associated with a File or FileArchetype.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.2")]
        FILE_COMMENT
    }
}
