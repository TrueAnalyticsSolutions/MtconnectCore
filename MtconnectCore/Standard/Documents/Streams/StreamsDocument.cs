using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Streams
{
    /// <inheritdoc />
    public partial class StreamsDocument : ResponseDocument<StreamsDocumentHeader, Device>
    {
        /// <inheritdoc />
        public override DocumentTypes Type => DocumentTypes.Streams;

        /// <inheritdoc />
        public override string DefaultNamespace => Constants.DEFAULT_XML_NAMESPACE;

        /// <inheritdoc />
        public override string DataElementName => StreamsElements.STREAMS.ToPascalCase();

        [MtconnectNodeElements(StreamsElements.HEADER, nameof(TrySetHeader), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        internal override StreamsDocumentHeader _header { get; set; }
        /// <inheritdoc />
        public StreamsDocumentHeader Header => (StreamsDocumentHeader)_header;

        /// <inheritdoc />
        public StreamsDocument(XmlDocument xDoc) : base(xDoc)
        {
            _header = new StreamsDocumentHeader(xDoc.DocumentElement.FirstChild, NamespaceManager, MtconnectVersion.GetValueOrDefault());
        }

        public int GetDataItemCount() => Items.SelectMany(o => o.Components).Select(o => o.Samples.Count + o.Events.Count + o.Conditions.Count).Sum();

        /// <inheritdoc />
        public override bool TryAddItem(XmlNode xNode, XmlNamespaceManager nsmgr, out Device device) => base.TryAdd<Device>(xNode, nsmgr, ref _items, out device);
    }
}
