using MtconnectCore.Standard.Contracts.Attributes;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Streams.Attributes
{
    public enum ObservationAttributes
    {
        /// <summary>
        /// identifier of the Composition entity defined in the MTConnectDevices Response Document associated with the data reported for the  Observation.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531115_47734_25731")]
        COMPOSITION_ID,
        /// <summary>
        /// unique identifier of the  DataItem associated with this  Observation.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531115_47734_25731")]
        DATA_ITEM_ID,
        /// <summary>
        /// name of the  DataItem associated with this  Observation.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531115_47734_25731")]
        NAME,
        /// <summary>
        /// number representing the sequential position of an occurrence of an observation in the data buffer of an agent.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531115_47734_25731")]
        SEQUENCE,
        /// <summary>
        /// subtype of the  DataItem associated with this  Observation.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531115_47734_25731")]
        SUB_TYPE,
        /// <summary>
        /// most accurate time available to a piece of equipment that represents the point in time that the data reported was measured.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531115_47734_25731")]
        TIMESTAMP,
        /// <summary>
        /// type of the  DataItem associated with this  Observation.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531115_47734_25731")]
        TYPE,
        /// <summary>
        /// units of the  DataItem associated with this  Observation.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531115_47734_25731")]
        UNITS,
        /// <summary>
        /// when true, Observation::result is indeterminate.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531115_47734_25731")]
        IS_UNAVAILABLE,
        /// <summary>
        /// observation of the  Observation entity.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531115_47734_25731")]
        RESULT
    }
}
