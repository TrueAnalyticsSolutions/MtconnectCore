using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams.Attributes
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 5.1.1")]
    public enum AssetChangedAttributes
    {
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 5.1.1")]
        SEQUENCE,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 5.1.1")]
        SUB_TYPE,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 5.1.1")]
        TIMESTAMP,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 5.1.1")]
        NAME,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 5.1.1")]
        DATA_ITEM_ID,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 5.1.1")]
        ASSET_TYPE
    }
}
