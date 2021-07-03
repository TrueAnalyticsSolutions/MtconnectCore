using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using System;
using System.Xml;

namespace MtconnectCore.Standard.Documents
{
    public abstract class MtconnectDocumentHeader : MtconnectNode, IMtconnectDocumentHeader
    {
        [MtconnectNodeAttribute(HeaderAttributes.CREATION_TIME)]
        public DateTime CreationTime { get; set; }

        [MtconnectNodeAttribute(HeaderAttributes.SENDER)]
        public string Sender { get; set; }

        [MtconnectNodeAttribute(HeaderAttributes.VERSION)]
        public string AgentVersion { get; set; }

        [MtconnectNodeAttribute(HeaderAttributes.INSTANCE_ID)]
        public int InstanceId { get; set; }

        public MtconnectDocumentHeader() : base() { }
        public MtconnectDocumentHeader(XmlNode xNode, XmlNamespaceManager nsmgr, string defaultNamespace) : base(xNode, nsmgr, defaultNamespace) { }
    }
}
