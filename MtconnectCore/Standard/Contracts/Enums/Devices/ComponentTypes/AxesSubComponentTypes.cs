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
        /// Chuck represents a mechanism that holds a part or stock material in place. It may also represent a mechanism that holds any other item in place within a device. The operation of a Chuck is represented by Chuck_State. The value of Chuck_State MAY be OPEN, CLOSED, or UNLATCHED.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 5.1.1")]
        CHUCK,
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
