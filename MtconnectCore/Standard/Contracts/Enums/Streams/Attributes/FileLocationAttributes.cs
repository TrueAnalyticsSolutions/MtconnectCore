using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams.Attributes
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.2.3.1")]
    public enum FileLocationAttributes
    {
        /// <summary>
        /// A URL reference to the file.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.2.3.1")]
        HREF,
        /// <summary>
        /// The type of href for the xlink href type.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.2.3.1")]
        XLINK_TYPE
    }
}
