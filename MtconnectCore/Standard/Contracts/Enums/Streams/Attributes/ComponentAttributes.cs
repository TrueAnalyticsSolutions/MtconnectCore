using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams.Attributes
{
    public enum ComponentAttributes
    {
        /// <summary>
        /// identifier of the Component as defined by the Component::id in the MTConnectDevices Response Document.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure__EAID_9057AAF9_4687_42be_BD2B_E2F18DF049DC")]
        COMPONENT_ID,
        /// <summary>
        /// name of the Component associated with the ComponentStream.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure__EAID_9057AAF9_4687_42be_BD2B_E2F18DF049DC")]
        NAME,
        /// <summary>
        /// common name of the Component associated with the  ComponentStream.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#Structure__EAID_9057AAF9_4687_42be_BD2B_E2F18DF049DC")]
        NATIVE_NAME,
        /// <summary>
        /// identifies the Component type associated with the ComponentStream.
        /// Examples of  ComponentStream::component are  Device,  Controller,  Linear and  Loader.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure__EAID_9057AAF9_4687_42be_BD2B_E2F18DF049DC")]
        COMPONENT,
        /// <summary>
        /// uuid of the Component associated with the  ComponentStream.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure__EAID_9057AAF9_4687_42be_BD2B_E2F18DF049DC")]
        UUID
    }
}
