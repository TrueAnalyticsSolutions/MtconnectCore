using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams.Attributes
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.2.1")]
    public enum AssetRemovedAttributes
    {
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.2.1")]
        SEQUENCE,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.2.1")]
        SUB_TYPE,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.2.1")]
        TIMESTAMP,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.2.1")]
        NAME,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.2.1")]
        DATA_ITEM_ID,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 4 Section 6.2.1")]
        COMPOSITION_ID,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 4 Section 6.2.1")]
        RESET_TRIGGERD,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.2.1")]
        ASSET_TYPE
    }
}
