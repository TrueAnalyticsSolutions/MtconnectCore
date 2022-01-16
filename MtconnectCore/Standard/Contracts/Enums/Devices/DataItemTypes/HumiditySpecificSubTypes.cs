using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.HUMIDITY_SPECIFIC"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 4.2")]
    public enum HumiditySpecificSubTypes
    {
        /// <summary>
        /// The measured value.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 4.2")]
        ACTUAL,
        /// <summary>
        /// The commanded value. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 4.2")]
        COMMANDED
    }
}
