using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Assets.Attributes;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Assets
{
    public class CuttingToolArchetypeReference : MtconnectNode
    {
        /// <inheritdoc cref="CuttingToolArchetypeReferenceAttributes.SOURCE"/>
        [MtconnectNodeAttribute(CuttingToolArchetypeReferenceAttributes.SOURCE)]
        public string Source { get; set; }

        public CuttingToolArchetypeReference() : base() { }

        public CuttingToolArchetypeReference(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE, version) { }
    }
}
