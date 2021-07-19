using System;
using System.Collections.Generic;
using System.Text;

namespace MtconnectCore.Standard.Contracts.Enums
{
    /// <summary>
    /// Attributes available for the base MTConnect Response Document.
    /// </summary>
    public enum HeaderAttributes
    {
        /// <summary>
        /// The major, minor, and revision number of the MTConnect Standard that defines the semantic data model that represents the content of the Response Document. It also includes the revision number of the schema associated with that specific semantic data model.
        /// </summary>
        VERSION,
        /// <summary>
        /// Represents the time that an Agent published the Response Document.
        /// </summary>
        CREATION_TIME,
        /// <summary>
        /// An identification defining where the Agent that published the Response Document is installed or hosted.
        /// </summary>
        SENDER,
        /// <summary>
        /// A number indicating a specific instantiation of the buffer associated with the Agent that published the Response Document.
        /// </summary>
        INSTANCE_ID
    }
}
