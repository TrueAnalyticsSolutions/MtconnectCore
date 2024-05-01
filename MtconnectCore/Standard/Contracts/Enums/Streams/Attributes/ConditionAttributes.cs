using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams.Attributes
{
    public enum ConditionAttributes
    {
        SEQUENCE,
        TIMESTAMP,
        NAME,
        DATA_ITEM_ID,
        COMPOSITION_ID,
        TYPE,
        /// <summary>
        /// native code is the proprietary identifier designating a specific alarm, fault or warning code provided by the piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531113_85883_25726")]
        NATIVE_CODE,
        /// <summary>
        /// severity information to a client software application if the piece of equipment designates a severity level to a fault.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531113_85883_25726")]
        NATIVE_SEVERITY,
        /// <summary>
        /// additional information regarding a condition state associated with the measured value of a process variable.
        /// Condition::qualifier defines whether the condition state represented indicates a measured value that is above or below an expected value of a process variable.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531113_85883_25726")]
        QUALIFIER,
        /// <summary>
        /// Condition::statistic provides additional information describing the meaning of the Condition entity.
        /// Condition::statistic MUST match the  DataItem::statistic defined in the MTConnectDevices Response Document.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531113_85883_25726")]
        STATISTIC,
        SUB_TYPE,
        /// <summary>
        /// identifier of an individual condition activation provided by a piece of equipment.
        /// Condition::conditionId MUST be unique for all concurrent condition activation.
        /// Condition::conditionId MUST be maintained for all state transitions related to the same condition activation.
        /// Multiple Condition::conditionIds MAY exist for the same  Condition::nativeCode.
        /// If Condition::conditionId is not given, the value is the Condition::nativeCode. If Condition::nativeCode and  Condition::conditionId are not given, Condition::conditionId MUST be generated.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_2_3_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531113_85883_25726")]
        CONDITION_ID
    }
}
