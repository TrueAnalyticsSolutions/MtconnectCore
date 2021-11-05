using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
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
        public DataItem(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE, version) { }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.1 and 3.8")]
        protected bool validateDataItemId(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(DataItemId))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"DataItem MUST include a 'dataItemId' attribute."));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.1 and 3.8")]
        protected bool validateTimestamp(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (Timestamp == null)
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Data entity MUST include a 'timestamp' attribute."));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.1 and 3.8")]
        protected bool validateSequence(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (Sequence == default(int))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Data entity MUST include a 'sequence' attribute."));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
