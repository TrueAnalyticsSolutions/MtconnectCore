using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Documents.Devices;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    /// <summary>
    /// Attributes available for the <see cref="Filter"/> element.
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, Constants.ModelBrowserLinks.FILTER)]
    public enum FilterAttributes {
        /// <summary>
        /// Sets the type of the <see cref="Filter"/> element.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, Constants.ModelBrowserLinks.FILTER)]
        TYPE
    }
}
