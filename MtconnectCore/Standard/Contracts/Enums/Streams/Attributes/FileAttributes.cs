using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams.Attributes
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.2.1")]
    public enum FileAttributes
    {
        /// <summary>
        /// The size of the file in bytes.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.2.1")]
        SIZE,
        /// <summary>
        /// The version identifier of the file.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.2.1")]
        VERSION_ID,
        /// <summary>
        /// The state of the file.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.2.1")]
        STATE
    }
}
