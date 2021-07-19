using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace MtconnectCore.Standard.Documents
{
    /// <summary>
    /// Structural interface for a MTConnect Response Document Header. See Part 1 Section 6.5 of MTConnect specification.
    /// </summary>
    public interface IResponseDocumentHeader
    {
        /// <summary>
        /// Represents the time that a MTConnect Agent published the Response Document.
        /// </summary>
        DateTime CreationTime { get; set; }

        /// <summary>
        /// An identification defining where the Agent that published the Response Document is installed or hosted.
        /// </summary>
        string Sender { get; set; }

        /// <summary>
        /// The major, minor, and revision number of the MTConnect Standard that defines the semantic data model that represents the content of the Response Document. It also includes the revision number of the schema associated with that specific semantic data model.
        /// </summary>
        string AgentVersion { get; set; }

        /// <summary>
        /// A number indicating a specific instantiation of the buffer associated with the Agent that published the Response Document.
        /// </summary>
        ulong InstanceId { get; set; }

        /// <summary>
        /// An overridable method for validating the entity model. It is recommended to validate sometime after parsing a MTConnect Response Document.
        /// </summary>
        /// <returns>Flag for whether the entity is valid.</returns>
        bool TryValidate(out ICollection<MtconnectValidationException> validationErrors);
    }
}
