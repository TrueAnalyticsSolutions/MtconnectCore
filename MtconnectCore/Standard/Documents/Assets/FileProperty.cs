using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Assets
{
    public class FileProperty : MtconnectNode
    {
        /// <inheritdoc cref="FilePropertyAttributes.NAME"/>
        [MtconnectNodeAttribute(FilePropertyAttributes.NAME)]
        public string Name { get; set; }

        public string Value { get; set; }

        /// <inheritdoc />
        public FileProperty() : base() { }

        /// <inheritdoc/>
        public FileProperty(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE, version) { }
    }
}
