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
        DateTime CreationTime { get; set; }

        string Sender { get; set; }

        string AgentVersion { get; set; }

        int InstanceId { get; set; }

        bool IsValid();
    }
}
