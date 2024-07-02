using MtconnectCore.Standard.Contracts.Attributes;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Streams.Attributes
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.ObservationModel.OBSERVATION)]
    public enum ObservationAttributes
    {
        /// <summary>
        /// identifier of the Composition entity defined in the MTConnectDevices Response Document associated with the data reported for the  Observation.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, Constants.ModelBrowserLinks.ObservationModel.OBSERVATION)]
        COMPOSITION_ID,
        /// <summary>
        /// unique identifier of the  DataItem associated with this  Observation.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.ObservationModel.OBSERVATION)]
        DATA_ITEM_ID,
        /// <summary>
        /// name of the  DataItem associated with this  Observation.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.ObservationModel.OBSERVATION)]
        NAME,
        /// <summary>
        /// number representing the sequential position of an occurrence of an observation in the data buffer of an agent.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.ObservationModel.OBSERVATION)]
        SEQUENCE,
        /// <summary>
        /// subtype of the  DataItem associated with this  Observation.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, Constants.ModelBrowserLinks.ObservationModel.OBSERVATION)]
        SUB_TYPE,
        /// <summary>
        /// most accurate time available to a piece of equipment that represents the point in time that the data reported was measured.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.ObservationModel.OBSERVATION)]
        TIMESTAMP,
        /// <summary>
        /// type of the  DataItem associated with this  Observation.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.ObservationModel.OBSERVATION)]
        TYPE,
        /// <summary>
        /// units of the  DataItem associated with this  Observation.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.ObservationModel.OBSERVATION)]
        UNITS,
        /// <summary>
        /// when true, Observation::result is indeterminate.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.ObservationModel.OBSERVATION)]
        IS_UNAVAILABLE,
        /// <summary>
        /// observation of the  Observation entity.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.ObservationModel.OBSERVATION)]
        RESULT
    }
}
