using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using System;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Assets
{
    public class FileComment : MtconnectNode
    {
        /// <inheritdoc cref="FileCommentAttributes.TIMESTAMP"/>
        [MtconnectNodeAttribute(FileCommentAttributes.TIMESTAMP)]
        public DateTime Timestamp { get; set; }

        public string Value { get; set; }

        /// <inheritdoc />
        public FileComment() : base() { }

        /// <inheritdoc/>
        public FileComment(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }
    }
}
