#pragma warning disable 0618
#pragma warning disable 1574
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#Enumeration___19_0_3_45f01b9_1580378417666_27713_2880")]
    public enum InterfaceStateValues
    {
        /// <summary>
        /// Interface is currently not operational.
        /// </summary>
        DISABLED,
        /// <summary>
        /// Interface is currently operational and performing as expected.
        /// </summary>
        ENABLED
    }
}