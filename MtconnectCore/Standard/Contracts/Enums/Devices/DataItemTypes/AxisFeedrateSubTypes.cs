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
        /// The operator’s overridden value. Percent of commanded.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1", MtconnectVersions.V_1_2_0)]
        OVERRIDE
    }
}
