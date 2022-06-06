using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 5.1.1")]
    public enum AssetTypeValues
    {
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1")]
        CUTTING_TOOL,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 4 Section 6.1.1")]
        FILE
    }
}
