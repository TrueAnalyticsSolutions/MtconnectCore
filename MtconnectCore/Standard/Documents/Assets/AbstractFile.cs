using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using System.Collections.Generic;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Assets
{
    public abstract class AbstractFile : Asset
    {
        /// <inheritdoc cref="AbstractFileAttributes.NAME"/>
        [MtconnectNodeAttribute(AbstractFileAttributes.NAME)]
        public string Name { get; set; }

        /// <inheritdoc cref="AbstractFileAttributes.MEDIA_TYPE"/>
        [MtconnectNodeAttribute(AbstractFileAttributes.MEDIA_TYPE)]
        public string MediaType { get; set; }

        /// <inheritdoc cref="AbstractFileAttributes.APPLICATION_CATEGORY"/>
        [MtconnectNodeAttribute(AbstractFileAttributes.APPLICATION_CATEGORY)]
        public string ApplicationCategory { get; set; }

        /// <inheritdoc cref="AbstractFileAttributes.APPLICATION_TYPE"/>
        [MtconnectNodeAttribute(AbstractFileAttributes.APPLICATION_TYPE)]
        public string ApplicationType { get; set; }

        private List<FileProperty> _fileProperties = new List<FileProperty>();
        [MtconnectNodeElements(nameof(AbstractFileElements.FILE_PROPERTIES), nameof(TryAddFileProperty), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public ICollection<FileProperty> FileProperties => _fileProperties;

        private List<FileComment> _fileComments = new List<FileComment>();
        [MtconnectNodeElements(nameof(AbstractFileElements.FILE_COMMENTS), nameof(TryAddFileComment), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public ICollection<FileComment> FileComments => _fileComments;

        /// <inheritdoc />
        public AbstractFile() : base() { }

        /// <inheritdoc/>
        public AbstractFile(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE, version) { }

        public bool TryAddFileProperty(XmlNode xNode, XmlNamespaceManager nsmgr, out FileProperty fileProperty)
            => base.TryAdd<FileProperty>(xNode, nsmgr, ref _fileProperties, out fileProperty);

        public bool TryAddFileComment(XmlNode xNode, XmlNamespaceManager nsmgr, out FileComment fileComment)
            => base.TryAdd<FileComment>(xNode, nsmgr, ref _fileComments, out fileComment);
    }
}
