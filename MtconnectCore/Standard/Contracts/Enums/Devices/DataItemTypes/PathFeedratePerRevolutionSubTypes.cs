using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.PATH_FEEDRATE_PER_REVOLUTION"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
    public enum PathFeedratePerRevolutionSubTypes
    {
        /// <summary>
        /// The measured value of the feedrate of the axes, or a single axis.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
        ACTUAL,
        /// <summary>
        /// The feedrate as specified by the Controller for the axes, or a single axis. The COMMANDED feedrate is a calculated value that includes adjustments and overrides.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
        COMMANDED,
        /// <summary>
        /// The feedrate specified by a logic or motion program or set by a switch as the feedrate for the axes, or a single axis.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
        PROGRAMMED
    }
}
