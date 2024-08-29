﻿using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class SampleDataSet : Sample, IDataSet
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
        public int? Count { get; set; }

        public new IDictionary<string, float> Value {
            get {
                return _entries.Where(o => float.TryParse(o.Result,out _))
                    .ToDictionary(o => o.Key, o => float.Parse(o.Result));
            }
        }

        private List<Entry> _entries = new List<Entry>();
        /// <summary>
        /// Collected from the textcontent of the Event element. Refer to Part 3 Streams - 5.5.3
        /// </summary>
        [MtconnectNodeElements(DataSetElements.ENTRY, nameof(TryAddEntry))]
        public new ICollection<Entry> Result => _entries;

        public bool TryAddEntry(XmlNode xNode, XmlNamespaceManager nsmgr, out Entry entry) => base.TryAdd<Entry>(xNode, nsmgr, ref _entries, out entry);

        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "See model.mtconnect.org/Observation Information Model/Representations/DataSet")]
        private bool ValidateProperties(out ICollection<MtconnectValidationException> validationErrors)
        {
            return new NodeValidationContext(this)
                // Validate Count
                //.ValidateValueProperty<DataSetAttributes>(nameof(Count), (o) =>
                //    o.IsImplemented(Count)
                //    ?.If(
                //        v => Count == null,
                //        v => throw new MtconnectValidationException(
                //            ValidationSeverity.ERROR,
                //            "DataSet representation MUST include a 'count' attribute equal to the number of Entry entities.",
                //            SourceNode)
                //    )
                //    ?.If(
                //        v => Count != _entries.Count,
                //        v => throw new MtconnectValidationException(
                //            ValidationSeverity.ERROR,
                //            "DataSet representation 'count' attribute MUST equal the number of Entry entities.",
                //            SourceNode)
                //    )
                //)
                // Validate Entry Key uniqueness
                //.ValidateValueProperty<DataSetElements>(nameof(Result), (o) =>
                //    o.IsImplemented(Result)
                //    ?.If(
                //        v => _entries.Count > 0 && !_entries.All(e => _entries.Count(x => x.Key == e.Key) == 1),
                //        v => throw new MtconnectValidationException(
                //            ValidationSeverity.ERROR,
                //            "DataSet Entry 'key' must be a unique identifier for each key-value pair within the DataSet.",
                //            SourceNode)
                //    )
                //)
                // Return validation errors
                .HasError(out validationErrors);
        }

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "See model.mtconnect.org/Observation Information Model/Representations/DataSet")]
        //private bool validateCount(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (Count == null)
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"DataSet representation MUST include a 'count' attribute equal to the number of Entry entities.",
        //            SourceNode));
        //    }
        //    else if (Count != _entries.Count)
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"DataSet representation 'count' attribute MUST equal the number of Entry entities.",
        //            SourceNode));
        //    }
        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "See model.mtconnect.org/Observation Information Model/Representations/DataSet")]
        //private bool validateEntryKey(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (_entries.Count > 0)
        //    {
        //        if (!_entries.All(o => _entries.Count(e => e.Key == o.Key) == 1))
        //        {
        //            validationErrors.Add(new MtconnectValidationException(
        //                ValidationSeverity.ERROR,
        //                $"DataSet Entry 'key' must be a unique identifier for each key-value pair within the DataSet.",
        //                SourceNode));
        //        }
        //    }
        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}
    }
}
