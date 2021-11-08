using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams.Attributes
{
    public enum SampleAttributes
    {
        SEQUENCE,
        SUB_TYPE,
        TIMESTAMP,
        NAME,
        DATA_ITEM_ID,
        COMPOSITION_ID,
        SAMPLE_RATE,
        RESET_TRIGGERED,
        STATISTIC,
        DURATION,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.8.2")]
        SAMPLE_COUNT
    }
}
