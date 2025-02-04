using MtconnectCore.Standard.Contracts.Attributes;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.RequestParameters
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.Protocol.PROBE)]
    public enum ProbeParameters
    {
        /// <summary>
        /// if present, speciﬁes that only the  Device for the given name or uuid will be returned. If not present, all associated  Device for the Agent will be returned.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.Protocol.PROBE)]
        DEVICE,
        /// <summary>
        /// type of  Device. If present, Agent::deviceType MUST have a value of Device or Agent. See  Device Information Model.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_2_3_0, Constants.ModelBrowserLinks.Protocol.PROBE)]
        DEVICE_TYPE,
    }
}
