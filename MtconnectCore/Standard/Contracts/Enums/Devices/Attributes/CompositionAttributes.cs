using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    /// <summary>
    /// Attributes for the Composition element in the MTConnect Response document.
    /// </summary>
    public enum CompositionAttributes {
        /// <summary>
        /// The unique identifier for this element.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, Constants.ModelBrowserLinks.DeviceModel.COMPOSITION)]
        ID,
        /// <summary>
        /// The type of Composition element.
        /// <example>
        /// <list type="bullet">
        /// <item>MOTOR</item>
        /// <item>FILTER</item>
        /// <item>PUMP</item>
        /// <item>AMPLIFIER</item>
        /// </list>
        /// </example>
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, Constants.ModelBrowserLinks.DeviceModel.COMPOSITION)]
        TYPE,
        /// <summary>
        /// The name of the Composition element.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, Constants.ModelBrowserLinks.DeviceModel.COMPOSITION)]
        NAME,
        /// <summary>
        /// A unique identifier for this XML element.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, Constants.ModelBrowserLinks.DeviceModel.COMPOSITION)]
        UUID,
    }
}
