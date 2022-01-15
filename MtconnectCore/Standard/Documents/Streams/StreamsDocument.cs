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


        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.2")]
        protected bool validateSequence(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            var allDataItems = new List<IDataItem>();
            var allComponents = Items.SelectMany(o => o.Components);
            allDataItems.AddRange(allComponents.SelectMany(o => o.Samples));
            allDataItems.AddRange(allComponents.SelectMany(o => o.Events));
            allDataItems.AddRange(allComponents.SelectMany(o => o.Conditions));
            var allSequenceNumbers = allDataItems.Select(o => o.Sequence).ToArray();
            var distinctSequenceNumbers = allSequenceNumbers.Distinct().ToArray();
            if (allSequenceNumbers.Length != distinctSequenceNumbers.Length)
            {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, $"'sequence' values MUST be unique for each incoming DataItem."));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3")]
        protected bool validateDataItemValue(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            var allUnavailable = Items.All(o => o.Components.All(c => c.Samples.All(d => d.Value == "UNAVAILABLE") && c.Events.All(d => d.Value == "UNAVAILABLE") && c.Conditions.All(d => d.Value == "UNAVAILABLE")));
            if (allUnavailable)
            {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.WARNING, $"All DataItems reporting UNAVAILABLE. This could be an indication that the Adapter is not reporting correctly."));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
