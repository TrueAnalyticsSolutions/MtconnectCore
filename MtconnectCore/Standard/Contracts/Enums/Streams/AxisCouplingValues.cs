using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="EventTypes.AXIS_COUPLING"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
    public enum AxisCouplingValues
    {
        /// <summary>
        /// The axes are physically connected to each other and must  operate as a single unit.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
        TANDEM,
        /// <summary>
        /// The axes are coupled and are operating together in  lockstep.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
        SYNCHRONOUS,
        /// <summary>
        /// The axis is the master of the CoupledAxes
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
        MASTER,
        /// <summary>
        /// The axis is a slave of the CoupledAxes
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
        SLAVE
    }
}
