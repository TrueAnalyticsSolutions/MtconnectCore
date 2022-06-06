using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams.Attributes
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.2.4.1")]
    public enum DestinationAttributes
    {
        /// <summary>
        /// uuid of the target device or application.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Files Section 3.2.4.1")]
        DEVICE_UUID
    }
}
