namespace MtconnectCore.Standard.Contracts.Enums.Devices.Elements
{
    /// <summary>
    /// Elements contained within the Component element in the MTConnect Response document.
    /// </summary>
    /// <remarks>See Part 2 Section 4.4.3 of the MTConnect specification.</remarks>
    public enum ComponentElements {
        /// <summary>
        /// An element that can contain any descriptive content.
        /// </summary>
        DESCRIPTION,
        /// <summary>
        /// An XML element that contains technical information about a piece of equipment describing its physical layout or functional characteristics.
        /// </summary>
        CONFIGURATION,
        /// <summary>
        /// A container for the Data Entities (See <see cref="MtconnectCore.Standard.Documents.Devices.DataItem"/>) associated with this Component element.
        /// </summary>
        DATA_ITEMS,
        /// <summary>
        /// See <see cref="MtconnectCore.Standard.Documents.Devices.DataItem"/>.
        /// </summary>
        DATA_ITEM,
        /// <summary>
        /// A container for Lower Level Component XML elements associated with this parent Component.
        /// </summary>
        COMPONENTS,
        /// <summary>
        /// See <see cref="MtconnectCore.Standard.Documents.Devices.Component"/>.
        /// </summary>
        COMPONENT,
        /// <summary>
        /// A container for the Composition elements (See <see cref="MtconnectCore.Standard.Documents.Devices.Composition"/>) associated with this Component element.
        /// </summary>
        COMPOSITIONS,
        /// <summary>
        /// See <see cref="MtconnectCore.Standard.Documents.Devices.Composition"/>.
        /// </summary>
        COMPOSITION,
        /// <summary>
        /// A container for the Reference elements associated with this Component element.
        /// </summary>
        REFERENCES,
        /// <summary>
        /// See <see cref="MtconnectCore.Standard.Documents.Devices.Reference"/>.
        /// </summary>
        REFERENCE,
        /// <summary>
        /// A ComponentRef element as an implementation.
        /// </summary>
        COMPONENT_REF,
        /// <summary>
        /// A DataItemRef element as an implementation.
        /// </summary>
        DATA_ITEM_REF
    }
}
