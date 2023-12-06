using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices
{
    /// <summary>
    /// Available options for a <c>statistic</c> attribute on a <see cref="Condition.Qualifier"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 3.5.7")]
    public enum QualifierTypes
    {
        /// <summary>
        /// measured value is greater than the expected value for a process variable.
        /// </summary>
        HIGH,
        /// <summary>
        /// measured value is less than the expected value for a process variable.
        /// </summary>
        LOW
    }
}
