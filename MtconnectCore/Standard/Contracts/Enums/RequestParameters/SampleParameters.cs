using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.RequestParameters
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.Protocol.SAMPLE)]
    public enum SampleParameters
    {
        /// <summary>
        /// optional  Device name or uuid. If not given, all devices are returned.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.Protocol.SAMPLE)]
        DEVICE,
        /// <summary>
        /// XPath evaluated against the Device Information Model that references the Components and DataItems to include in the MTConnectStreams Response Document. When a  <<abstract>> Component element is referenced by the XPath, all observations for its DataItems and related Components MUST be included in the MTConnectStreams Response Document.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.Protocol.SAMPLE)]
        PATH,
        /// <summary>
        /// designates the sequence number of the first observation in the buffer the agent MUST consider publishing in the response document. If from is zero (0), it MUST be set to the firstSequence, the oldest observation in the buffer. If from and count parameters are not given, from MUST default to the firstSequence. If the from parameter is less than the firstSequence or greater than lastSequence, the agent MUST return a 404 HTTP Status Code and MUST publish an MTConnectErrors Response Document with an OUT_OF_RANGE  Error::errorCode.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.Protocol.SAMPLE)]
        FROM,
        /// <summary>
        /// designates the maximum number of observations the agent MUST publish in the response document. The count MUST NOT be zero (0). When the count is greater than zero (0), the from parameter MUST default to the firstSequence. The evaluation of observations starts at from and moves forward accumulating newer observations until the number of observations equals the count or the observation at lastSequence is considered. When the count is less than zero (0), the from parameter MUST default to the lastSequence. The evaluation of observations starts at from and moves backward accumulating older observations until the number of observations equals the absolute value of count or the observation at firstSequence is considered. count MUST NOT be less than zero (0) when an interval parameter is given. If count is not provided, it MUST default to 100. If the absolute value of count is greater than the size of the buffer or equal to zero (0), the agent MUST return a 404 HTTP Status Code and MUST publish an MTConnectErrors Response Document with an OUT_OF_RANGE  Error::errorCode. If the count parameter is not a numeric value, the agent MUST return a 400 HTTP Status Code and MUST publish an MTConnectErrors Response Document with an INVALID_REQUEST  Error::errorCode.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.Protocol.SAMPLE)]
        COUNT,
        /// <summary>
        /// agent MUST stream samples and events to the client application pausing for frequency milliseconds between each part. Each part will contain a maximum  Agent::count of events or samples and  Agent::from will be used to indicate the beginning of the stream. DEPRECATED Version 1.2, replace by  Agent::interval
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.Protocol.SAMPLE, MtconnectVersions.V_1_2_0)]
        FREQUENCY,
        /// <summary>
        /// sets the time period for the heartbeat function in an agent. The value for heartbeat represents the amount of time after a response document has been published until a new response document MUST be published, even when no new data is available. The value for heartbeat is defined in milliseconds. If no value is defined for heartbeat, the value MUST default to 10 seconds. heartbeat MUST only be specified if interval is also specified.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, Constants.ModelBrowserLinks.Protocol.SAMPLE)]
        HEARTBEAT,
        /// <summary>
        /// agent MUST continuously publish response documents when the query parameters include interval using the value as the minimum period between adjacent publications. The interval value MUST be in milliseconds, and MUST be a positive integer greater than or equal to zero (0). If the value for the interval parameter is zero (0), the agent MUST publish response documents when any observations become available. If the period between the publication of a response document and reception of observations exceeds the interval, the agent MUST wait for a maximum of heartbeat milliseconds for observations. Upon the arrival of observations, the agent MUST immediately publish a response document. When the period equals or exceeds the heartbeat, the agent MUST publish an empty response document.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, Constants.ModelBrowserLinks.Protocol.SAMPLE)]
        INTERVAL,
        /// <summary>
        /// specifies the sequence number of the observation in the buffer that will be the upper bound of the observations in the response document. Rules for to are as follows: The value of to MUST be an unsigned 64-bit integer. The value of to MUST be greater than the firstSequence. The value of to MUST be less than or equal to the lastSequence. The value of to MUST be greater than from. If to and count are given, the count parameter MUST be greater than zero. If to and count are given, the maximum number of observations published in the response document MUST NOT be greater than the value of count. If to is not given, see the from parameter for default behavior. If the to parameter is less than the firstSequence or greater than lastSequence, the agent MUST return a 404 HTTP Status Code and MUST publish an MTConnectErrors Response Document with an OUT_OF_RANGE errorCode. If the to parameter is not a positive numeric value, the agent MUST return a 400 HTTP Status Code and MUST publish an MTConnectErrors Response Document with an INVALID_REQUEST errorCode. If the to parameter is less than the from parameter, the agent MUST return a 400 HTTP Status Code and MUST publish an MTConnectErrors Response Document with an INVALID_REQUEST errorCode. If the to parameter is given and the count parameter is less than zero, the agent MUST return a 400 HTTP Status Code and MUST publish an MTConnectErrors Response Document with an INVALID_REQUEST errorCode.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, Constants.ModelBrowserLinks.Protocol.SAMPLE)]
        TO,
        /// <summary>
        /// type of  Device. If present, Agent::deviceType MUST have a value of Device or Agent. See  Device Information Model.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_2_3_0, Constants.ModelBrowserLinks.Protocol.SAMPLE)]
        DEVICE_TYPE,
    }
}
