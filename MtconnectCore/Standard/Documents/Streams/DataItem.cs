using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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

        /// <inheritdoc cref="SampleAttributes.SUB_TYPE"/>
        [MtconnectNodeAttribute(SampleAttributes.SUB_TYPE)]
        public string SubType { get; set; }

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
            //validationErrors = new List<MtconnectValidationException>();
            //if (!string.IsNullOrEmpty(this.SourceNode.LocalName))
            //{
            //    if (!EnumHelper.Contains<T>(this.SourceNode.LocalName))
            //    {
            //        validationErrors.Add(new MtconnectValidationException(
            //            ValidationSeverity.ERROR,
            //            $"{categoryType.ToString()} '{this.SourceNode.LocalName}' is not defined in the MTConnect Standard in version '{MtconnectVersion}' as a valid {categoryType.ToString()} type.",
            //            SourceNode));
            //    }
            //    else if (!EnumHelper.ValidateToVersion<T>(this.SourceNode.LocalName, MtconnectVersion.GetValueOrDefault()) && !EnumHelper.ValidateToVersion<T>(this.SourceNode.LocalName, MtconnectVersion.GetValueOrDefault()))
            //    {
            //        validationErrors.Add(new MtconnectValidationException(
            //            ValidationSeverity.WARNING,
            //            $"{categoryType.ToString()} '{this.SourceNode.LocalName}' is not valid in version '{MtconnectVersion}' of the MTConnect Standard as a valid {categoryType.ToString()} type.",
            //            SourceNode));
            //    }
            //}
            //return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);

            bool isValidType = true, isValidSubType = true;
            validationErrors = new List<MtconnectValidationException>();

            // Validate the observational type
            if (!EnumHelper.Contains<T>(SourceNode.LocalName))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"DataItem type of '{SourceNode.LocalName}' is not defined in the MTConnect Standard for category '{categoryType}' in version '{MtconnectVersion}'.",
                    SourceNode));
                isValidType = false;
            }
            else if (!EnumHelper.ValidateToVersion<T>(SourceNode.LocalName, MtconnectVersion.GetValueOrDefault()))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.WARNING,
                    $"DataItem type of '{SourceNode.LocalName}' is not valid for category '{categoryType}' in version '{MtconnectVersion}' of the MTConnect Standard.",
                    SourceNode));
                isValidType = false;
            }

            if (isValidType)
            {
                // Get the Enum and look for an attribute pointing to the SubType enum
                Type enumType = typeof(T);
                MemberInfo[] typeValueInfos = enumType.GetMember(EnumHelper.Enumify(SourceNode.LocalName));
                var valueInfo = typeValueInfos.FirstOrDefault(o => o.DeclaringType == enumType);
                var obsSubType = valueInfo?.GetCustomAttribute<ObservationalSubTypeAttribute>();
                // Validate the observational sub-type
                if (obsSubType != null)
                {
                    if (string.IsNullOrEmpty(SubType))
                    {
                        validationErrors.Add(new MtconnectValidationException(
                            ValidationSeverity.ERROR,
                            $"DataItem type '{SourceNode.LocalName}' is missing a subType",
                            SourceNode));
                        isValidSubType = false;
                    } else if (!EnumHelper.Contains(obsSubType.SubTypeEnum, SubType))
                    {
                        validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.ERROR,
                            $"DataItem subType of '{SubType}' is not defined in the MTConnect Standard for category '{categoryType}' and type '{SourceNode.LocalName}' in version '{MtconnectVersion}'.",
                            SourceNode));
                        isValidSubType = false;
                    }
                    else if (!EnumHelper.ValidateToVersion(obsSubType.SubTypeEnum, SubType, MtconnectVersion.GetValueOrDefault()))
                    {
                        validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                            $"DataItem subType of '{SubType}' is not valid for category '{categoryType}' and type '{SourceNode.LocalName}' in version '{MtconnectVersion}' of the MTConnect Standard.",
                            SourceNode));
                        isValidSubType = false;
                    }
                }
            }

            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
