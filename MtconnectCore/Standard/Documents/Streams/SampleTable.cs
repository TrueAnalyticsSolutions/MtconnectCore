using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class SampleTable : Sample, ITable
    {
        /// <summary>
        /// Description of a means to interpret data consisting of multiple data points or samples reported as a single value.
        /// </summary>
        [MtconnectNodeAttribute(DataItemAttributes.REPRESENTATION)]
        public override string Representation { get; set; } = RepresentationEnum.TABLE.ToString();

        /// <summary>
        /// Collected from the count attribute. Refer to Part 3 Streams - 5.6.3.1
        /// 
        /// Occurance: 1
        /// </summary>
        [MtconnectNodeAttribute(TableAttributes.COUNT)]
        public ParsedValue<uint?> Count { get; set; }

        public new IDictionary<string, float[]> Value {
            get {
                return _entries
                    .ToDictionary(o => o.Key, o => o.Cells.Select(c => float.Parse(c.Result)).ToArray());
            }
        }

        private List<TableEntry> _entries = new List<TableEntry>();
        /// <summary>
        /// Collected from the textcontent of the Event element. Refer to Part 3 Streams - 5.5.3
        /// </summary>
        [MtconnectNodeElements(TableElements.ENTRY, nameof(TryAddEntry))]
        public new ICollection<TableEntry> Result => _entries;

        public bool TryAddEntry(XmlNode xNode, XmlNamespaceManager nsmgr, out TableEntry entry) => base.TryAdd<TableEntry>(xNode, nsmgr, ref _entries, out entry);

        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "See model.mtconnect.org/Observation Information Model/Representations/Table")]
        private bool ValidateProperties(out ICollection<MtconnectValidationException> validationErrors)
        {
            return new NodeValidationContext(this)
                // Validate Count
                .ValidateValueProperty(
                    TableAttributes.COUNT,
                    (o) =>
                        o.IsImplemented(Count)
                        .IsUIntValueType(Count.RawValue, out _)
                        .IsUIntWithinRange(Count, (uint)(Result?.Count ?? 0), (uint)(Result?.Count ?? 0))
                )
                // Validate Entry Key uniqueness
                .ValidateValueProperty(
                    TableElements.ENTRY,
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
