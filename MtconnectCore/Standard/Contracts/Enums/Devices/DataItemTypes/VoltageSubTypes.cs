using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.VOLTAGE"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
    public enum VoltageSubTypes {
        /// <summary>
        /// The measurement of alternating voltage. If not  specified further in statistic, defaults to RMS voltage
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        ALTERNATING,
        /// <summary>
        /// The measurement of DC voltage 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        DIRECT,
    }
}
