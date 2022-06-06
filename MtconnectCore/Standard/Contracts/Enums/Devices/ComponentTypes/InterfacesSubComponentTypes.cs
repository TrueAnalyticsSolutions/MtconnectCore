using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.ComponentTypes
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 5.9.1")]
    public enum InterfacesSubComponentTypes
    {
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 5.9.1.1")]
        BAR_FEEDER_INTERFACE,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 5.9.1.4")]
        CHUCK_INTERFACE,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 5.9.1.3")]
        DOOR_INTERFACE,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 5.9.1.2")]
        MATERIAL_HANDLER_INTERFACE
    }
}
