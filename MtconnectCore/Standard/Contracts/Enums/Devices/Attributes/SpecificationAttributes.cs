namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    /// <summary>
    /// Attributes of the Specification element
    /// </summary>
    /// <remarks>See Part 2 Section 9.3.1.1 of the MTConnect specification.</remarks>
    public enum SpecificationAttributes {
        /// <summary>
        /// Same as <see cref="DataItemAttributes.TYPE"/>. <inheritdoc cref="DataItemAttributes.TYPE"/>
        /// </summary>
        TYPE,
        /// <summary>
        /// Same as <see cref="DataItemAttributes.SUB_TYPE"/>. <inheritdoc cref="DataItemAttributes.SUB_TYPE"/>
        /// </summary>
        SUB_TYPE,
        /// <summary>
        /// A reference to the id attribute of the DataItem associated with this element.
        /// </summary>
        DATA_ITEM_ID_REF,
        /// <summary>
        /// Same as <see cref="DataItemAttributes.UNITS"/>. <inheritdoc cref="DataItemAttributes.UNITS"/>
        /// </summary>
        UNITS,
        /// <summary>
        /// A reference to the id attribute of the Composition associated with this element.
        /// </summary>
        COMPOSITION_ID_REF,
        /// <summary>
        /// The name provides additional meaning and differentiates between Specifications. A name MUST exist when two Specifications have the same <see cref="TYPE"/> and <see cref="SUB_TYPE"/> within a Component.
        /// </summary>
        NAME,
        /// <summary>
        /// References the CoordinateSystem for geometric Specification elements.
        /// </summary>
        COORDINATE_SYSTEM_ID_REF
    }
}
