using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="EventTypes.CONNECTION_STATUS"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 3 Section 6.2")]
    public enum ConnectionStatusValues
    {
        /// <summary>
        /// Represents no connection at all.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 3 Section 6.2")]
        CLOSED,
        /// <summary>
        /// Represents the Agent waiting for a connection request from an Adapter.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 3 Section 6.2")]
        LISTEN,
        /// <summary>
        /// Represents an open connection. The normal state for the data transfer phase of the connection.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 3 Section 6.2")]
        ESTABLISHED
    }
}
