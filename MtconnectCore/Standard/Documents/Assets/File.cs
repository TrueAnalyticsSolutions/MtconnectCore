using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using System;
using System.Collections.Generic;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Assets
{
    public class File : AbstractFile
    {
        /// <inheritdoc cref="FileAttributes.SIZE"/>
        [MtconnectNodeAttribute(FileAttributes.SIZE)]
        public int Size { get; set; }

        /// <inheritdoc cref="FileAttributes.VERSION_ID"/>
        [MtconnectNodeAttribute(FileAttributes.VERSION_ID)]
        public string VersionId { get; set; }

        /// <inheritdoc cref="FileAttributes.STATE"/>
        [MtconnectNodeAttribute(FileAttributes.STATE)]
        public string State { get; set; }

        /// <inheritdoc cref="FileElements.SIGNATURE"/>
        [MtconnectNodeElement(nameof(FileElements.SIGNATURE))]
        public string Signature { get; set; }

        /// <inheritdoc cref="FileElements.PUBLIC_KEY"/>
        [MtconnectNodeElement(nameof(FileElements.PUBLIC_KEY))]
        public string PublicKey { get; set; }

        /// <inheritdoc cref="FileElements.CREATION_TIME"/>
        [MtconnectNodeElement(nameof(FileElements.CREATION_TIME))]
        public DateTime CreationTime { get; set; }

        /// <inheritdoc cref="FileElements.MODIFICATION_TIME"/>
        [MtconnectNodeElement(nameof(FileElements.MODIFICATION_TIME))]
        public DateTime? ModificationTime { get; set; }

        /// <inheritdoc cref="FileElements.FILE_LOCATION"/>
        [MtconnectNodeElements(nameof(FileElements.FILE_LOCATION), nameof(TrySetFileLocation))]
        public FileLocation FileLocation { get; set; }

        private List<Destination> _destinations = new List<Destination>();
        [MtconnectNodeElements(nameof(FileElements.DESTINATIONS), nameof(TryAddDestination))]
        public ICollection<Destination> Destinations => _destinations;

        /// <inheritdoc />
        public File() : base() { }

        /// <inheritdoc/>
        public File(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        public bool TrySetFileLocation(XmlNode xNode, XmlNamespaceManager nsmgr, out FileLocation fileLocation)
            => base.TrySet<FileLocation>(xNode, nsmgr, nameof(FileLocation), out fileLocation);

        public bool TryAddDestination(XmlNode xNode, XmlNamespaceManager nsmgr, out Destination destination)
            => base.TryAdd<Destination>(xNode, nsmgr, ref _destinations, out destination);
    }
}
