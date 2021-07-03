using System;
using System.Collections.Generic;
using System.Text;

namespace MtconnectCore.Standard.Documents
{
    public interface IMtconnectDocumentHeader
    {
        DateTime CreationTime { get; set; }

        string Sender { get; set; }

        string AgentVersion { get; set; }

        int InstanceId { get; set; }

        bool IsValid();
    }
}
