using MtconnectCore.Standard.Documents.Devices;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Elements
{
    /// <summary>
    /// Available elements for the <see cref="DataItem"/> element
    /// </summary>
    public enum DataItemElements {
        /// <summary>
        /// Source is an optional XML element that identifies the Component, DataItem, or Composition representing the area of the piece of equipment from which a measured value originates. Additionally, Source MAY provide information relating to the identity of a measured value. This information is reported as CDATA for Source. (example, a PLC tag)
        /// </summary>
        SOURCE,
        /// <summary>
        /// Constraints is an optional container that provides a set of expected values that can be reported for this DataItem. Constraints are used by a software application to evaluate the validity of the reported data.
        /// </summary>
        CONSTRAINTS,
        /// <summary>
        /// An optional container for the Filter elements associated with this DataItem element.
        /// </summary>
        FILTERS,
        /// <summary>
        /// InitialValue is an optional XML element that defines the starting value for a data item as well as the value to be set for the data item after a reset event. Only one InitialValue element may be defined for a data item. The value will be constant and cannot change. If no InitialValue element is defined for a data item that is periodically reset, then the starting value for the data item MUST be a value of 0.
        /// </summary>
        INITIAL_VALUE,
        /// <summary>
        /// ResetTrigger is an optional XML element that identifies the type of event that may cause a reset to occur. It is additional information regarding the meaning of the data that establishes an understanding of the time frame that the data represents so that the data may be correctly understood by a client software application.
        /// </summary>
        RESET_TRIGGER,
        /// <summary>
        /// The Definition defines the meaning of Entry and Cell elements associated with the DataItem when the representation is either DATA_SET or TABLE.
        /// </summary>
        DEFINITION
    }
}
