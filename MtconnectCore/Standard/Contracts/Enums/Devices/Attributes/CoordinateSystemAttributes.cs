using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    /// <summary>
    /// Attributes of the CoordinateSystem element
    /// </summary>
    /// <remarks>See Part 2 Section 9.4.1.1 of the MTConnect specification.</remarks>
    public enum CoordinateSystemAttributes
    {
        /// <summary>
        /// The unique identifier for this element.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.COORDINATE_SYSTEM)]
        ID,
        /// <summary>
        /// The name of the coordinate system.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.COORDINATE_SYSTEM)]
        NAME,
        /// <summary>
        /// The manufacturer’s name or users name for the coordinate system.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.COORDINATE_SYSTEM)]
        NATIVE_NAME,
        /// <summary>
        /// A pointer to the id attribute of the parent CoordinateSystem.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.COORDINATE_SYSTEM)]
        PARENT_ID_REF,
        /// <summary>
        /// The type of coordinate system. See <see cref="CoordinateSystemTypeEnum"/>.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.COORDINATE_SYSTEM)]
        TYPE,
        /// <summary>
        /// UUID for the coordinate system.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, Constants.ModelBrowserLinks.COORDINATE_SYSTEM)]
        UUID,
    }
}
