using MtconnectCore.Standard.Contracts.Attributes;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of EVENT <c>type</c> <see cref="EventTypes.LINE"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2")]
    public enum LineSubTypes {
        /// <summary>
        /// The maximum line number of the code being executed. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2")]
        MAXIMUM,
        /// <summary>
        /// The minimum line number of the code being executed.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2")]
        MINIMUM
    }
}
