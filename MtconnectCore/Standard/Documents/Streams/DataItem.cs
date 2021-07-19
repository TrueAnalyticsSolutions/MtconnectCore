using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    public abstract class DataItem : MtconnectNode, IDataItem
    {
        /// <summary>
        /// Collected from the dataItemId attribute. Refer to Part 3 Streams - 5.3.2, 5.5.2, 5.8.3
        /// 
        /// Occurance: 1
        /// </summary>
        [MtconnectNodeAttribute(SampleAttributes.DATA_ITEM_ID)]
        public string DataItemId { get; set; }

        /// <summary>
        /// Collected from the timestamp attribute. Refer to Part 3 Streams - 5.3.2, 5.5.2, 5.8.3
        /// 
        /// Occurance: 1
        /// </summary>
        [MtconnectNodeAttribute(SampleAttributes.TIMESTAMP)]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Collected from the sequence attribute. Refer to Part 3 Streams - 5.3.2, 5.5.2, 5.8.3
        /// 
        /// Occurance: 1
        /// </summary>
        [MtconnectNodeAttribute(SampleAttributes.SEQUENCE)]
        public int Sequence { get; set; }

        /// <inheritdoc/>
        public DataItem() { }

        /// <inheritdoc/>
        public DataItem(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE) { }

        /// <inheritdoc/>
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            const string documentationAttributes = "See Part 1 Section 5 of the MTConnect standard.";
            validationErrors = new List<MtconnectValidationException>();

            if (string.IsNullOrEmpty(DataItemId))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Data entity MUST include a 'dataItemId' attribute. {documentationAttributes}"));
            }

            if (Timestamp == null)
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Data entity MUST include a 'timestamp' attribute. {documentationAttributes}"));
            }

            if (Sequence == default(int))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Data entity MUST include a 'sequence' attribute. {documentationAttributes}"));
            }

            return !validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR);
        }
    }
}
