﻿using MtconnectCore.Standard.Contracts.Attributes;

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
        /// <summary>
        /// rate at which successive samples of the value are recorded.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531116_175117_25733")]
        SAMPLE_RATE,
        /// <summary>
        /// identifies when a reported value has been reset and what has caused that reset to occur for those  DataItem entities that may be periodically reset to an initial value.
        /// resetTriggered MUST only be provided for the specific occurrence of a  DataItem reported in the MTConnectStreams Response Document when the reset occurred.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531116_175117_25733")]
        RESET_TRIGGERED,
        /// <summary>
        /// type of statistical calculation defined by the  DataItem::statistic defined in the MTConnectDevices Response Document.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531116_175117_25733")]
        STATISTIC,
        /// <summary>
        /// time-period over which the data was collected.
        /// Sample::duration MUST be provided when the  DataItem::statistic is defined in the MTConnectDevices Response Document.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531116_175117_25733")]
        DURATION,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531116_175117_25733")]
        SAMPLE_COUNT
    }
}
