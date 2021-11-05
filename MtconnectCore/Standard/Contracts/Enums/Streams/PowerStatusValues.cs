using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="EventElements.POWER_STATUS"/>
    /// </summary>
    [Obsolete("Deprecated in version 1.1.0.")]
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1", MtconnectVersions.V_1_0_1)]
    public enum PowerStatusValues
    {
        /// <summary>
        /// The power to the component is ON.
        /// </summary>
        [Obsolete("Deprecated in version 1.1.0.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1", MtconnectVersions.V_1_0_1)]
        ON,
        /// <summary>
        /// The power to the component is OFF.
        /// </summary>
        [Obsolete("Deprecated in version 1.1.0.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8.1", MtconnectVersions.V_1_0_1)]
        OFF
    }
}
