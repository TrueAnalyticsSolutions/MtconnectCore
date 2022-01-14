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
        /// The controller has been stopped.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1")]
        STOPPED,
    }
}
