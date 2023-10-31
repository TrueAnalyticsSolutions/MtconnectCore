using System;

namespace MtconnectCore.Standard.Contracts.Enums.Streams.Attributes
{
    public enum ObservationAttributes
    {
        /// <summary>
        /// identifier of the  <<abstract>> Composition entity defined in the MTConnectDevices Response Document associated with the data reported for the  Observation.
        /// </summary>
        COMPOSITION_ID,
        /// <summary>
        /// unique identifier of the  DataItem associated with this  Observation.
        /// </summary>
        DATA_ITEM_ID,
        /// <summary>
        /// name of the  DataItem associated with this  Observation.
        /// </summary>
        NAME,
        /// <summary>
        /// number representing the sequential position of an occurrence of an observation in the data buffer of an agent.
        /// </summary>
        SEQUENCE,
        /// <summary>
        /// subtype of the  DataItem associated with this  Observation.
        /// </summary>
        SUB_TYPE,
        /// <summary>
        /// most accurate time available to a piece of equipment that represents the point in time that the data reported was measured.
        /// </summary>
        TIMESTAMP,
        /// <summary>
        /// type of the  DataItem associated with this  Observation.
        /// </summary>
        TYPE,
        /// <summary>
        /// units of the  DataItem associated with this  Observation.
        /// </summary>
        UNITS,
        /// <summary>
        /// when true, Observation::result is indeterminate.
        /// </summary>
        IS_UNAVAILABLE,
        /// <summary>
        /// observation of the  Observation entity.
        /// </summary>
        RESULT
    }
}
