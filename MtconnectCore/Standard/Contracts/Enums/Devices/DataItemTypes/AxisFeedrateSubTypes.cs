using MtconnectCore.Standard.Contracts.Attributes;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.AXIS_FEEDRATE"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1")]
    public enum AxisFeedrateSubTypes {
        /// <summary>
        /// The actual federate of a linear axis. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1")]
        ACTUAL,
        /// <summary>
        /// The feedrate as specified in the program. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1")]
        COMMANDED,
        /// <summary>
        /// The feedrate specified by a logic  or motion program, by a pre-set value, or set by a switch as the feedrate for a linear axis when operating in a manual state or method (jogging).
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        JOG,
        /// <summary>
        /// The feedrate specified by a logic  or motion program or set by a switch for a linear axis.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        PROGRAMMED,
        /// <summary>
        /// The feedrate specified by a logic  or motion program, by a pre-set value, or set by a switch as the feedrate for a linear axis when operating in a rapid positioning mode.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        RAPID,
        /// <summary>
        /// The operator’s overridden value. Percent of commanded.
        /// </summary>
        [Obsolete("Deprecated in version 1.3.0. See EVENT Type DataItems.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1", MtconnectVersions.V_1_2_0)]
        OVERRIDE
    }
}
