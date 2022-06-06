using MtconnectCore.Standard.Contracts.Attributes;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of EVENT <c>type</c> <see cref="EventTypes.LINE"/>
    /// </summary>
    [Obsolete("Deprecated in version 1.4.0.")]
    [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2", MtconnectVersions.V_1_3_1)]
    public enum LineSubTypes {
        /// <summary>
        /// The maximum line number of the code being executed. 
        /// </summary>
        [Obsolete("Deprecated in version 1.4.0.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2", MtconnectVersions.V_1_3_1)]
        MAXIMUM,
        /// <summary>
        /// The minimum line number of the code being executed.
        /// </summary>
        [Obsolete("Deprecated in version 1.4.0.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.2", MtconnectVersions.V_1_3_1)]
        MINIMUM
    }
}
