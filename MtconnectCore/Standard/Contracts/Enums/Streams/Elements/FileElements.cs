using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams.Elements
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.2.2")]
    public enum FileElements
    {
        /// <summary>
        /// A secure hash of the file.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.2.2")]
        SIGNATURE,
        /// <summary>
        /// The public key used to verify the signature.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.2.2")]
        PUBLIC_KEY,
        /// <summary>
        /// The time the file was created.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.2.2")]
        CREATION_TIME,
        /// <summary>
        /// The time the file was modified.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.2.2")]
        MODIFICATION_TIME,
        /// <summary>
        /// The URL reference to the file location.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.2.2")]
        FILE_LOCATION,
        /// <summary>
        /// Destinations organizes one or more Destination elements.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.2.2")]
        DESTINATIONS
    }
}
