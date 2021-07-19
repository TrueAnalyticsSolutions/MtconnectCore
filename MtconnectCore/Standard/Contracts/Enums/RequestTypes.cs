namespace MtconnectCore.Standard.Contracts.Enums
{
    /// <summary>
    /// Options for request paths against a MTConnect Agent.
    /// </summary>
    public enum RequestTypes
    {
        /// <summary>
        /// An Agent responds to a Probe Request with an MTConnectDevices Response Document that contains the Equipment Metadata for pieces of equipment that are requested and currently represented in the Agent.
        /// </summary>
        PROBE,
        /// <summary>
        /// An Agent responds to a Current Request with an MTConnectStreams Response Document that contains the current value of Data Entities associated with each piece of Streaming Data available from the Agent, subject to any filtering defined in the Request.
        /// </summary>
        CURRENT,
        /// <summary>
        /// An Agent responds to a Sample Request with an MTConnectStreams Response Document that contains a set of values for Data Entities currently available for Streaming Data from the Agent, subject to any filtering defined in the Request.
        /// </summary>
        SAMPLE,
        /// <summary>
        /// An Agent responds to an Asset Request with an MTConnectAssets Response Document that contains information for MTConnect Assets from the Agent, subject to any filtering defined in the Request.
        /// </summary>
        ASSET,
    }
}
