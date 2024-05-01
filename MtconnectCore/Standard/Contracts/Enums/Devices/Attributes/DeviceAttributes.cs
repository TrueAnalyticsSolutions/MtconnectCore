using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    public enum DeviceAttributes
    {
        /// <summary>
        /// universally unique identifier for the element.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1620240839406_285612_1596")]
        UUID,
        /// <summary>
        /// name of an element or a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1620240839406_285612_1596")]
        NAME,
        /// <summary>
        /// unique identifier for the Component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure__EAID_8548C620_467A_4f50_9A22_58D84B7E8779")]
        ID,
        /// <summary>
        /// interval in milliseconds between the completion of the reading of the data associated with the Component until the beginning of the next sampling of that data.
        /// This information may be used by client software applications to understand how often information from a Component is expected to be refreshed.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure__EAID_8548C620_467A_4f50_9A22_58D84B7E8779")]
        SAMPLE_INTERVAL,
        /// <summary>
        /// common name associated with Component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure__EAID_8548C620_467A_4f50_9A22_58D84B7E8779")]
        NATIVE_NAME,
        /// <summary>
        /// DEPRECATED in MTConnect Version 1.2. Replaced by Component::sampleInterval.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure__EAID_8548C620_467A_4f50_9A22_58D84B7E8779")]
        SAMPLE_RATE,
        /// <summary>
        /// DEPRECATED in MTConnect Version 1.2.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1620240839406_285612_1596", MtconnectVersions.V_1_1_0)]
        ISO_841_CLASS,
        /// <summary>
        /// MTConnect version of the Device Information Model used to configure the information to be published for a piece of equipment in an MTConnect Response Document.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1620240839406_285612_1596")]
        MTCONNECT_VERSION,
        /// <summary>
        /// condensed message digest from a secure one-way hash function. FIPS PUB 180-4
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1620240839406_285612_1596")]
        HASH,
        /// <summary>
        /// specifies the  CoordinateSystem for this Component and its children.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure__EAID_8548C620_467A_4f50_9A22_58D84B7E8779")]
        COORDINATE_SYSTEM_ID_REF
    }
}
