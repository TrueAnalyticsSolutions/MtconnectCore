using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of EVENT <c>type</c> <see cref="EventTypes.PATH_FEEDRATE_OVERRIDE"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
    public enum PathFeedrateOverrideSubTypes
    {
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        JOG,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        PROGRAMMED,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        RAPID
    }
}
