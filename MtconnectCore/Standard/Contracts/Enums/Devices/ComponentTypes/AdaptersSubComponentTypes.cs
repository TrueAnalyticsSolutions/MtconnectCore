using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.ComponentTypes
{
    /// <summary>
    /// Adapters is a Component that organizes Adapter Components representing the connectivity state of the MTConnect Agent.
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 5.7")]
    public enum AdaptersSubComponentTypes
    {
        /// <summary>
        /// Adapter is a Component representing the connectivity state of a data source for the MTConnect Agent.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 5.7.1")]
        ADAPTER,
    }
}
