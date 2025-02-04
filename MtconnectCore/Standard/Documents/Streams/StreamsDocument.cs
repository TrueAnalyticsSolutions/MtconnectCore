using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    /// <inheritdoc />
    public partial class StreamsDocument : ResponseDocument<StreamsDocumentHeader, Device>
    {
        private const string MODEL_BROWSER_URL = "https://model.mtconnect.org/#Structure__EAID_02192189_58E6_456c_A679_CDDFF559DA00";

        /// <inheritdoc />
        public override DocumentTypes Type => DocumentTypes.Streams;

        /// <inheritdoc />
        public override string DataElementName => StreamsElements.STREAMS.ToPascalCase();

        [MtconnectNodeElements(StreamsElements.HEADER, nameof(TrySetHeader))]
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


        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL)]
        protected bool validateDataItems(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();

            var allObservations = DataItemNavigator.GetAll(this);
            var allComponents = DataItemNavigator.GetAllComponents(this);

            var allSequenceNumbers = allObservations.Select(o => o.Sequence).ToArray();
            var distinctSequenceNumbers = allSequenceNumbers.Distinct().ToArray();
            if (allSequenceNumbers.Length != distinctSequenceNumbers.Length)
            {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, $"'sequence' values MUST be unique for each incoming DataItem.", SourceNode) {
                    Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.DUPLICATE_ENTRY,
                    SourceContext = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY,
                    SourceContextScope = "DataItem.Sequence"
                });
            }

            var allUnavailable = allObservations.All(o => o.IsUnavailable);
            if (allUnavailable)
            {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.WARNING, $"All Observations reporting UNAVAILABLE. This could be an indication that the Adapter is not reporting correctly.", SourceNode) {
                    Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.INVALID_FORMAT,
                    SourceContext = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY,
                    SourceContextScope = "DataItem.Result"
                });
            }

            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

    }
}
