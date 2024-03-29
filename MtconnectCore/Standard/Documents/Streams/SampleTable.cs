﻿using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using MtconnectCore.Standard.Contracts.Errors;
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
        public override string Representation { get; set; } = RepresentationTypes.TABLE.ToString();


        /// <summary>
        /// Collected from the count attribute. Refer to Part 3 Streams - 5.6.3.1
        /// 
        /// Occurance: 1
        /// </summary>
        [MtconnectNodeAttribute(TableAttributes.COUNT)]
        public int? Count { get; set; }

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
        [MtconnectNodeElements(TableElements.ENTRY, nameof(TryAddEntry), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public new ICollection<TableEntry> Result => _entries;

        public bool TryAddEntry(XmlNode xNode, XmlNamespaceManager nsmgr, out TableEntry entry) => base.TryAdd<TableEntry>(xNode, nsmgr, ref _entries, out entry);

        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "See model.mtconnect.org/Observation Information Model/Representations/Table")]
        private bool validateCount(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (Count == null)
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Table representation MUST include a 'count' attribute equal to the number of Entry entities.",
                    SourceNode));
            }
            else if (Count != _entries.Count)
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Table representation 'count' attribute MUST equal the number of Entry entities.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "See model.mtconnect.org/Observation Information Model/Representations/TableEntry")]
        private bool validateTableEntryKey(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (_entries.Count > 0)
            {
                if (!_entries.All(o => _entries.Count(e => e.Key == o.Key) == 1))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.ERROR,
                        $"TableEntry 'key' must be a unique identifier for each key-value pair within the Table.",
                        SourceNode));
                }
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
