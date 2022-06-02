using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of EVENT <c>type</c> <see cref="EventTypes.PROCESS_KIND_ID"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
    public enum ProcessKindIdSubTypes
    {
        /// <summary>
        /// The globally unique identifier as specified in ISO 11578 or RFC 4122.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        UUID,
        /// <summary>
        /// A word or set of words by which a process being executed (process occurrence) by the device is known, addressed, or referred to.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        PROCESS_NAME,
        /// <summary>
        /// A reference to a ISO 10303 Executable.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.2")]
        ISO_STEP_EXECUTABLE
    }
}
