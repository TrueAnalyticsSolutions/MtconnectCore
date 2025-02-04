using MtconnectCore.Standard.Contracts.Attributes;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.RequestParameters
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.Protocol.CURRENT)]
    public enum CurrentParameters
    {
        /// <summary>
        /// optional  Device name or uuid. If not given, all devices are returned.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.Protocol.CURRENT)]
        DEVICE,
        /// <summary>
        /// XPath evaluated against the Device Information Model that references the Components and DataItems to include in the MTConnectStreams Response Document. When a Component element is referenced by the XPath, all observations for its DataItems and related Components MUST be included in the MTConnectStreams Response Document.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.Protocol.CURRENT)]
        PATH,
        /// <summary>
        /// agent MUST stream samples and events to the client application pausing for frequency milliseconds between each part. DEPRECATED Version 1.2, replace by  Agent::interval
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.Protocol.CURRENT, MtconnectVersions.V_1_2_0)]
        [Obsolete("Deprecated in v1.2")]
        FREQUENCY,
        /// <summary>
        /// response documents MUST include observations consistent with a specific sequence number given by the value of the at parameter. If the value is either less than the firstSequence or greater than the lastSequence, the request MUST return a 404 HTTP Status Code and the agent MUST return an MTConnectErrors Response Document with an OUT_OF_RANGE  Error::errorCode. The at parameter MUST NOT be used in conjunction with the interval parameter.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, Constants.ModelBrowserLinks.Protocol.CURRENT)]
        AT,
        /// <summary>
        /// agent MUST continuously publish response documents pausing for the number of milliseconds given as the value. The interval value MUST be in milliseconds, and MUST be a positive integer greater than zero (0). The interval parameter MUST NOT be used in conjunction with the at parameter.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, Constants.ModelBrowserLinks.Protocol.CURRENT)]
        INTERVAL,
        /// <summary>
        /// type of  Device. If present, Agent::deviceType MUST have a value of Device or Agent. See  Device Information Model.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_2_3_0, Constants.ModelBrowserLinks.Protocol.CURRENT)]
        DEVICE_TYPE
    }
}
