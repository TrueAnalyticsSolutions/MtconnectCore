using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class AssetRemoved : Event
    {
        [MtconnectNodeAttribute(AssetRemovedAttributes.ASSET_TYPE)]
        public string AssetType { get; set; }

        /// <inheritdoc/>
        public AssetRemoved() : base() { }

        /// <inheritdoc/>
        public AssetRemoved(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version)
        {
            Value = xNode.InnerText;
            TagName = xNode.LocalName;
        }
    }
}
