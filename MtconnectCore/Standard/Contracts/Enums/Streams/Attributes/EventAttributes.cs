using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams.Attributes
{
    public enum EventAttributes
    {
        SEQUENCE,
        SUB_TYPE,
        TIMESTAMP,
        NAME,
        DATA_ITEM_ID,
        COMPOSITION_ID,
        /// <summary>
        /// identifies when a reported value has been reset and what has caused that reset to occur for those  DataItem entities that may be periodically reset to an initial value.
        /// resetTriggered MUST only be provided for the specific occurrence of a  DataItem reported in the MTConnectStreams Response Document when the reset occurred.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531115_47447_25730")]
        RESET_TRIGGERED
    }
}
