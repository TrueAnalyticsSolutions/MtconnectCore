using MtconnectCore.Standard.Contracts.Attributes;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.ComponentTypes
{
    /// <summary>
    /// Sub-components of <see cref="ComponentTypes.AXES"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 5.3.1.2")]
    public enum AxesSubComponentTypes
    {
        /// <summary>
        /// A linear axis represents travel along a straight line. The name of the linear axis SHOULD follow  the conventions of the industry.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 5.3.1.2")]
        LINEAR,
        /// <summary>
        /// A rotary axis revolves around a line or vector. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 5.3.1.2")]
        ROTARY,
        [Obsolete("Deprecated in version 1.1.0.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 5.3.1.2", MtconnectVersions.V_1_0_1)]
        SPINDLE
    }
}
