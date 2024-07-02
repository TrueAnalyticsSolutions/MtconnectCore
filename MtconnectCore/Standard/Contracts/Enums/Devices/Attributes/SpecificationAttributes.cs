using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    /// <summary>
    /// Attributes of the Specification element
    /// </summary>
    /// <remarks>See Part 2 Section 9.3.1.1 of the MTConnect specification.</remarks>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.SPECIFICATION)]
    public enum SpecificationAttributes {
        /// <summary>
        /// Same as <see cref="DataItemAttributes.TYPE"/>. <inheritdoc cref="DataItemAttributes.TYPE"/>
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.SPECIFICATION)]
        TYPE,
        /// <summary>
        /// Same as <see cref="DataItemAttributes.SUB_TYPE"/>. <inheritdoc cref="DataItemAttributes.SUB_TYPE"/>
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.SPECIFICATION)]
        SUB_TYPE,
        /// <summary>
        /// A reference to the id attribute of the DataItem associated with this element.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.SPECIFICATION)]
        DATA_ITEM_ID_REF,
        /// <summary>
        /// Same as <see cref="DataItemAttributes.UNITS"/>. <inheritdoc cref="DataItemAttributes.UNITS"/>
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.SPECIFICATION)]
        UNITS,
        /// <summary>
        /// A reference to the id attribute of the Composition associated with this element.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.SPECIFICATION)]
        COMPOSITION_ID_REF,
        /// <summary>
        /// The name provides additional meaning and differentiates between Specifications. A name MUST exist when two Specifications have the same <see cref="TYPE"/> and <see cref="SUB_TYPE"/> within a Component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.SPECIFICATION)]
        NAME,
        /// <summary>
        /// References the CoordinateSystem for geometric Specification elements.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.SPECIFICATION)]
        COORDINATE_SYSTEM_ID_REF,
        /// <summary>
        /// The unique identifier for this Specification. The id attribute MUST be unique within the MTConnectDevices document.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, Constants.ModelBrowserLinks.SPECIFICATION)]
        ID,
        /// <summary>
        /// A reference to the creator of the Specification.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, Constants.ModelBrowserLinks.SPECIFICATION)]
        ORIGINATOR
    }
}
