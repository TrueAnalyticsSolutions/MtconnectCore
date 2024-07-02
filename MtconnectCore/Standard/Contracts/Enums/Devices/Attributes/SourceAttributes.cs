using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    /// <summary>
    /// Attributes for the <see cref="MtconnectCore.Standard.Documents.Devices.Source"/> element.
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.SOURCE)]
    public enum SourceAttributes
    {
        /// <summary>
        /// The identifier attribute of the Component element that represents the physical part of a piece of equipment where the data represented by the DataItem element originated.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, Constants.ModelBrowserLinks.SOURCE)]
        COMPONENT_ID,
        /// <summary>
        /// The identifier attribute of the Composition element that represents the physical part of a piece of equipment where the data represented by the DataItem element originated.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, Constants.ModelBrowserLinks.SOURCE)]
        COMPOSITION_ID,
        /// <summary>
        /// The identifier attribute of the DataItem that represents the originally measured value of the data referenced by this data item.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, Constants.ModelBrowserLinks.SOURCE)]
        DATA_ITEM_ID
    }
}
