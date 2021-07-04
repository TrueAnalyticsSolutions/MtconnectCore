using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using System;
using System.Xml;

namespace MtconnectCore.Standard.Documents
{
    /// <summary>
    /// Structural interface for a MTConnect Response Document Header. See Part 1 Section 6.5 of MTConnect specification.
    /// </summary>
    public abstract class ResponseDocumentHeader : MtconnectNode, IResponseDocumentHeader
    {
        [MtconnectNodeAttribute(HeaderAttributes.CREATION_TIME)]
        public DateTime CreationTime { get; set; }

        [MtconnectNodeAttribute(HeaderAttributes.SENDER)]
        public string Sender { get; set; }

        [MtconnectNodeAttribute(HeaderAttributes.VERSION)]
        public string AgentVersion { get; set; }

        [MtconnectNodeAttribute(HeaderAttributes.INSTANCE_ID)]
        public int InstanceId { get; set; }

        public ResponseDocumentHeader() : base() { }
        public ResponseDocumentHeader(XmlNode xNode, XmlNamespaceManager nsmgr, string defaultNamespace) : base(xNode, nsmgr, defaultNamespace) { }
    }
}
