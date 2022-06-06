using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams.Attributes
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.1")]
    public enum AbstractFileAttributes
    {
        /// <summary>
        /// The name of the file.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.1")]
        NAME,
        /// <summary>
        /// The mime type of the file.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.1")]
        MEDIA_TYPE,
        /// <summary>
        /// The category of application that will use this file.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.1")]
        APPLICATION_CATEGORY,
        /// <summary>
        /// The type of application that will use this file.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.1.1")]
        APPLICATION_TYPE
    }
}
