using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Documents.Devices;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices
{
    /// <summary>
    /// Available options for a <c>coordinateSystem</c> attribute on a <see cref="DataItem.CoordinateSystem"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.4", MtconnectVersions.V_2_0_0)]
    [Obsolete("Deprecated in v2.0.0")]
    public enum CoordinateSystemEnum {
        /// <summary>
        /// An unchangeable coordinate system that has machine zero as its origin.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.4", MtconnectVersions.V_2_0_0)]
        [Obsolete("Deprecated in v2.0.0")]
        WORK,
        /// <summary>
        /// The coordinate system that represents the working area for a particular workpiece whose origin is shifted within the MACHINE coordinate system. If the WORK coordinates are not currently defined in the device, the MACHINE coordinates will be used.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.4", MtconnectVersions.V_2_0_0)]
        [Obsolete("Deprecated in v2.0.0")]
        MACHINE
    }
}
