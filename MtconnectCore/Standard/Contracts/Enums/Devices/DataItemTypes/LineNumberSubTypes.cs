using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of EVENT <c>type</c> <see cref="EventTypes.LINE_NUMBER"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
    public enum LineNumberSubTypes
    {
        /// <summary>
        /// The position of a block of program code relative to the beginning of the  control program.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        ABSOLUTE,
        /// <summary>
        /// The position of a block of program code relative to the occurrence of the  last LINE_LABEL encountered in the control program.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.2")]
        INCREMENTAL
    }
}
