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
                    $"DataItem MUST include a 'dataItemId' attribute.",
                        SourceNode));
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
                    $"Data entity MUST include a 'timestamp' attribute.",
                        SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.1 and 3.8")]
        protected bool validateSequence(out ICollection<MtconnectValidationException> validationErrors)
        {
            const long sequenceCeiling = 2 ^ 64;
            validationErrors = new List<MtconnectValidationException>();
            if (Sequence < 1 && Sequence > sequenceCeiling)
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Data entity MUST include a 'sequence' attribute.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        protected abstract bool validateValue(out ICollection<MtconnectValidationException> validationErrors);

        protected abstract bool validateNode(out ICollection<MtconnectValidationException> validationErrors);

        protected bool validateNode<T>(MtconnectCore.Standard.Contracts.Enums.Devices.CategoryTypes categoryType, out ICollection<MtconnectValidationException> validationErrors) where T : Enum
        {
            validationErrors = new List<MtconnectValidationException>();

            ICollection<MtconnectValidationException> extensionErrors;
            validateNodeExtension<T>(categoryType, out extensionErrors);

            if (extensionErrors.Any())
            {
                validationErrors = extensionErrors;
                return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
            }

            ICollection<MtconnectValidationException> standardErrors;
            validateNodeInStandard<T>(categoryType, out standardErrors);

            if (standardErrors.Any())
            {
                validationErrors = standardErrors;
            }

            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        protected bool validateNodeExtension<T>(MtconnectCore.Standard.Contracts.Enums.Devices.CategoryTypes categoryType, out ICollection<MtconnectValidationException> validationErrors) where T: Enum
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(this.SourceNode.Name))
            {
                if (SourceNode.Name.StartsWith("x:"))
                {
                    if (validateNodeInStandard<T>(categoryType, out ICollection<MtconnectValidationException> inStandardErrors))
                    {
                        validationErrors.Add(new MtconnectValidationException(
                            ValidationSeverity.WARNING,
                            $"{categoryType.ToString()} type of '{SourceNode.Name}' is an unnecessary extension of the MTConnect Standard as it already exists in version '{MtconnectVersion}'.",
                            SourceNode));
                    } else
                    {
                        validationErrors.Add(new MtconnectValidationException(
                            ValidationSeverity.MESSAGE,
                            $"{categoryType.ToString()} type of '{SourceNode.Name}' is an extension of the MTConnect Standard in this implementation.",
                            SourceNode));
                    }
                }
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        protected bool validateNodeInStandard<T>(MtconnectCore.Standard.Contracts.Enums.Devices.CategoryTypes categoryType, out ICollection<MtconnectValidationException> validationErrors) where T : Enum
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(this.SourceNode.LocalName))
            {
                if (!EnumHelper.Contains<T>(this.SourceNode.LocalName))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.ERROR,
                        $"{categoryType.ToString()} '{this.SourceNode.LocalName}' is not defined in the MTConnect Standard in version '{MtconnectVersion}' as a valid {categoryType.ToString()} type. Consider extending the schema and prefixing the type with the 'x:' namespace.",
                        SourceNode));
                }
                else if (!EnumHelper.ValidateToVersion<T>(this.SourceNode.LocalName, MtconnectVersion.GetValueOrDefault()) && !EnumHelper.ValidateToVersion<T>(this.SourceNode.LocalName, MtconnectVersion.GetValueOrDefault()))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"{categoryType.ToString()} '{this.SourceNode.LocalName}' is not valid in version '{MtconnectVersion}' of the MTConnect Standard as a valid {categoryType.ToString()} type.",
                        SourceNode));
                }
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        /// <summary>
        /// Attempts to validate a DataItem subType value according the specified type (<typeparamref name="T"/>).
        /// </summary>
        /// <typeparam name="T">Reference to the <see cref="Enum"/> containing appropriate subType values.</typeparam>
        /// <param name="subType">Reference to the subType provided in the Response Document.</param>
        /// <param name="validationError">Output of the error found in validating the subType.</param>
        /// <returns>Flag for whether or not the validation passed.</returns>
        protected bool tryValidateSubType<T>(string subType, out MtconnectValidationException validationError) where T : Enum
        {
            validationError = null;
            if (!EnumHelper.Contains<T>(subType))
            {
                validationError = new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"{SourceNode.LocalName} MUST be one of the following subTypes: {EnumHelper.ToListString<T>(", ", "'", "'")}",
                    SourceNode);
                return true;
            }
            return false;
        }
    }
}
