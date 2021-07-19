using System;
using System.Collections.Generic;
using System.Text;

namespace MtconnectCore.Standard.Contracts.Enums
{
    /// <summary>
    /// Types of supported MTConnect Response Documents.
    /// </summary>
    public enum DocumentTypes
    {
        /// <summary>
        /// Represents a MTConnectDevices Response Document.
        /// </summary>
        Devices,
        /// <summary>
        /// Represents a MTConnectStreams Response Document.
        /// </summary>
        Streams,
        /// <summary>
        /// Represents a MTConnectAssets Response Document.
        /// </summary>
        Assets,
        /// <summary>
        /// Represents a MTConnectErrors Response Document.
        /// </summary>
        Errors
    }
}
