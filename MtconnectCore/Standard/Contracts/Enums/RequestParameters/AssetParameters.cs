using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.RequestParameters
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, Constants.ModelBrowserLinks.Protocol.ASSET)]
    public enum AssetParameters
    {
        /// <summary>
        /// optional  Device name or uuid. If not given, all devices are returned.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_2_0_0, Constants.ModelBrowserLinks.Protocol.ASSET)]
        DEVICE,
        /// <summary>
        /// path portion is a list of (asset_id) for specific MTConnectAssets Response Documents. In response, the agent returns an MTConnectAssets Response Document that contains information for the specific assets for each of the asset_id values provided in the request. Each asset_id is separated by a “;”.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, Constants.ModelBrowserLinks.Protocol.ASSET)]
        ASSET_IDS,
        /// <summary>
        /// specifies the maximum number of MTConnectAssets Response Documents returned in an MTConnectAssets Response Document. If count is not given, the default value MUST be 100.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, Constants.ModelBrowserLinks.Protocol.ASSET)]
        COUNT,
        /// <summary>
        /// type of Asset. See  Asset Information Model.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, Constants.ModelBrowserLinks.Protocol.ASSET)]
        TYPE,
        /// <summary>
        /// value for  Agent::removed MUST be true or false and interpreted as follows: true: MTConnectAssets Response Documents for assets marked as removed MUST be included in the response document. false: MTConnectAssets Response Documents for assets marked as removed MUST NOT be included in the response document. If  Agent::removed is not given, the default value MUST be false.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, Constants.ModelBrowserLinks.Protocol.ASSET)]
        REMOVED
    }
}
