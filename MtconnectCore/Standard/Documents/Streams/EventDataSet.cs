using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using System.Collections.Generic;
using System.Xml;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using System.Linq;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using MtconnectCore.Standard.Contracts;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class EventDataSet : Event, IDataSet
    {
        /// <summary>
        /// Description of a means to interpret data consisting of multiple data points or samples reported as a single value.
        /// </summary>
        [MtconnectNodeAttribute(DataItemAttributes.REPRESENTATION)]
        public override string Representation { get; set; } = RepresentationEnum.DATA_SET.ToString();


        /// <summary>
        /// Collected from the count attribute. Refer to Part 3 Streams - 5.6.3.1
        /// 
        /// Occurance: 1
        /// </summary>
        [MtconnectNodeAttribute(DataSetAttributes.COUNT)]
        public ParsedValue<uint?> Count { get; set; }

        public new IDictionary<string, string> Value {
            get {
                return _entries
                    .ToDictionary(o => o.Key, o => o.Result);
            }
        }

        private List<Entry> _entries = new List<Entry>();
        /// <summary>
        /// Collected from the textcontent of the Event element. Refer to Part 3 Streams - 5.5.3
        /// </summary>
        [MtconnectNodeElements(DataSetElements.ENTRY, nameof(TryAddEntry))]
        public new ICollection<Entry> Result => _entries;

        /// <inheritdoc/>
        public EventDataSet() : base() { }

        /// <inheritdoc/>
        public EventDataSet(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        public bool TryAddEntry(XmlNode xNode, XmlNamespaceManager nsmgr, out Entry entry) => base.TryAdd<Entry>(xNode, nsmgr, ref _entries, out entry);

        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "See model.mtconnect.org/Observation Information Model/Representations/DataSet")]
        private bool ValidateProperties(out ICollection<MtconnectValidationException> validationErrors)
        {
            return new NodeValidationContext(this)
                // Validate Count
                .ValidateValueProperty(
                    DataSetAttributes.COUNT,
                    (o) =>
                        o.IsImplemented(Count)
                        .IsUIntValueType(Count.RawValue, out _)
                        .IsUIntWithinRange(Count, (uint)(Result?.Count ?? 0), (uint)(Result?.Count ?? 0))
                )
                // Validate Entry Key uniqueness
                .ValidateValueProperty<DataSetElements>(
                    DataSetElements.ENTRY,
                    (o) =>
                    o.IsImplemented()
                    ?.If(
                        v => _entries.Count > 0 && !_entries.All(e => _entries.Count(x => x.Key == e.Key) == 1),
                        v => throw new MtconnectValidationException(
                            ValidationSeverity.ERROR,
                            "DataSet Entry 'key' must be a unique identifier for each key-value pair within the DataSet.",
                            SourceNode) {
                            Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.DUPLICATE_ENTRY,
                            ScopeType = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY,
                            Scope = "Entry.Key"
                        }
                    )
                )
                // Return validation errors
                .HasError(out validationErrors);
        }
    }
}
