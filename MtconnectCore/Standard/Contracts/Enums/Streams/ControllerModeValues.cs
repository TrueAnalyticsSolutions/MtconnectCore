using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="EventElements.CONTROLLER_MODE"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
    public enum ControllerModeValues {
        /// <summary>
        /// The controller is configured to automatically execute a  program.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
        AUTOMATIC,
        /// <summary>
        /// The controller is operating in a single cycle, single block,  or single step mode.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
        SEMI_AUTOMATIC,
        /// <summary>
        /// The controller is under manual control by the operator.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
        MANUAL,
        /// <summary>
        /// The operator can enter operations for the controller to  perform. There is no current program being executed.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
        MANUAL_DATA_INPUT
    }
}
