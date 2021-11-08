using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="EventElements.EXECUTION"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
    public enum ExecutionValues {
        /// <summary>
        /// The controller is ready to execute. It is currently idle.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
        READY,
        /// <summary>
        /// The controller is actively executing an instruction.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
        ACTIVE,
        /// <summary>
        /// The operator or the program has paused execution and is waiting to be continued.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
        INTERRUPTED,
        /// <summary>
        /// The controller has is in a feed hold and motion has  been stopped.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        FEED_HOLD,
        /// <summary>
        /// The controller has been stopped.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
        STOPPED,
        /// <summary>
        /// The controller’s program has  been intentionally stopped using an M01 or similar command.The program may be stopped at the designated location based upon the state of a secondary indication provided to the controller indicating whether the program execution must be stopped at this location or program execution should continue.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.2")]
        OPTIONAL_STOP,
        /// <summary>
        /// The program has been stopped.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        PROGRAM_STOPPED,
        /// <summary>
        /// The program has completed execution.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3")]
        PROGRAM_COMPLETED,
        /// <summary>
        /// The program has been intentionally optionally stopped using an M01 or similar code.
        /// </summary>
        [Obsolete("Deprecated in version 1.4.0. See OPTIONAL_STOP")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.10.3", MtconnectVersions.V_1_3_1)]
        PROGRAM_OPTIONAL_STOP
    }
}
