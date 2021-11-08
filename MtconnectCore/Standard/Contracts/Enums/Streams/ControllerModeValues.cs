using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using System;

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
        MANUAL_DATA_INPUT,
        /// <summary>
        /// The controller is currently editing a program in the  foreground.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        EDIT,
        /// <summary>
        /// The machine is executing single block or instruction.
        /// </summary>
        [Obsolete("Deprecated in version 1.4.0. See CONTROLLER_MODE_OVERRIDE.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3", MtconnectVersions.V_1_3_1)]
        SINGLE_BLOCK,
        /// <summary>
        /// The axes of the device are commanded to stop, but the  spindle continues to function.
        /// </summary>
        [Obsolete("Deprecated in version 1.3.0.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.10.2", MtconnectVersions.V_1_2_0)]
        FEED_HOLD
    }
}
