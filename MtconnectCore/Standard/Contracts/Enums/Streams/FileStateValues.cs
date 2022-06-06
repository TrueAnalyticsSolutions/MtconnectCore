using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.2.1.1")]
    public enum FileStateValues
    {
        /// <summary>
        /// Used for processes other than production or otherwise defined.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.2.1.1")]
        EXPERIMENTAL,
        /// <summary>
        /// Used for production processes.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.2.1.1")]
        PRODUCTION,
        /// <summary>
        /// The content is modified from PRODUCTION or EXPERIMENTAL.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.2.1.1")]
        REVISION
    }
}
