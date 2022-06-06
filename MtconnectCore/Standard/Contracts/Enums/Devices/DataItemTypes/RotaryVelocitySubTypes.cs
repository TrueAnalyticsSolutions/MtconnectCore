using MtconnectCore.Standard.Contracts.Attributes;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.ROTARY_VELOCITY"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
    public enum RotaryVelocitySubTypes {
        /// <summary>
        /// The rotational speed the rotary axis is spinning at.  ROTARY_MODE MUST be SPINDLE.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        ACTUAL,
        /// <summary>
        /// The rotational speed as specified in the program. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        COMMANDED,
        /// <summary>
        /// The rotational velocity specified  by a logic or motion program or set by a switch
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        PROGRAMMED,
        /// <summary>
        /// The operator’s overridden value. Percent of commanded.
        /// </summary>
        [Obsolete("Deprecated in version 1.3.0. See EVENT Type DataItems.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10", MtconnectVersions.V_1_2_0)]
        OVERRIDE
    }
}
