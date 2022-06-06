using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Assets
{
    public class FileLocation : MtconnectNode
    {
        /// <inheritdoc cref="FileLocationAttributes.HREF"/>
        [MtconnectNodeAttribute(FileLocationAttributes.HREF)]
        public string Href { get; set; }

        /// <inheritdoc cref="FileLocationAttributes.XLINK_TYPE"/>
        [MtconnectNodeAttribute(FileLocationAttributes.XLINK_TYPE)]
        public string XlinkType { get; set; }

        /// <inheritdoc />
        public FileLocation() : base() { }

        /// <inheritdoc/>
        public FileLocation(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE, version) { }
    }
}
