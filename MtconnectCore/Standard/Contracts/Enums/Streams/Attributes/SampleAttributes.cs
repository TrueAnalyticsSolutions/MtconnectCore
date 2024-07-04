using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams.Attributes
{
    /// <summary>
    /// Value properties of <see cref="Sample" /> <see cref="Observation" />
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.ObservationModel.SAMPLE)]
    public enum SampleAttributes
    {
        /// <summary>
        /// time-period over which the data was collected.
        /// Sample::duration MUST be provided when the  DataItem::statistic is defined in the MTConnectDevices Response Document.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, Constants.ModelBrowserLinks.ObservationModel.SAMPLE)]
        DURATION,
        /// <summary>
        /// identifies when a reported value has been reset and what has caused that reset to occur for those  DataItem entities that may be periodically reset to an initial value.
        /// resetTriggered MUST only be provided for the specific occurrence of a  DataItem reported in the MTConnectStreams Response Document when the reset occurred.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, Constants.ModelBrowserLinks.ObservationModel.SAMPLE)]
        RESET_TRIGGERED,
        /// <summary>
        /// rate at which successive samples of the value are recorded.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, Constants.ModelBrowserLinks.ObservationModel.SAMPLE)]
        SAMPLE_RATE,
        /// <summary>
        /// type of statistical calculation defined by the  DataItem::statistic defined in the MTConnectDevices Response Document.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, Constants.ModelBrowserLinks.ObservationModel.SAMPLE)]
        STATISTIC,
        /// <summary>
        /// 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.ObservationModel.SAMPLE)]
        UNITS,
    }
}
