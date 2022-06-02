using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.6.1")]
    public enum SolidModelAttributes
    {
        /// <summary>
        /// The unique identifier for this entity within the MTConnectDevices document.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.6.1")]
        ID,
        /// <summary>
        /// The associated model file if an item reference is used.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.6.1")]
        SOLID_MODEL_ID_REF,
        /// <summary>
        /// The URL giving the location of the Solid Model. If not present, the model referenced in the solidModelIdRef is used.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.6.1")]
        HREF,
        /// <summary>
        /// The reference to the item within the model within the related geometry. A solidModelIdRef MUST be given.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.6.1")]
        ITEM_REF,
        /// <summary>
        /// The format of the referenced document.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.6.1")]
        MEDIA_TYPE,
        /// <summary>
        /// A reference to the coordinate system for this SolidModel.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.6.1")]
        COORDINATE_SYSTEM_ID_REF
    }
}
