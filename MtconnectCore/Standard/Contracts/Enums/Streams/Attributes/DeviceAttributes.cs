using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams.Attributes
{
    public enum DeviceAttributes {
        /// <summary>
        /// name of the Device.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure__EAID_02192189_58E6_456c_A679_CDDFF559DA00")]
        NAME,
        /// <summary>
        /// uuid of the Device.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure__EAID_02192189_58E6_456c_A679_CDDFF559DA00")]
        UUID,
    }
}
