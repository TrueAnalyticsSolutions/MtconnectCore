using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class Condition : DataItem
    {
        /// <summary>
        /// Collected from the name attribute. Refer to Part 3 Streams - 5.8.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(ConditionAttributes.NAME)]
        public string Name { get; set; }

        /// <summary>
        /// Collected from the type attribute. Refer to Part 3 Streams - 5.8.3
        /// 
        /// Occurance: 1
        /// </summary>
        [MtconnectNodeAttribute(ConditionAttributes.TYPE)]
        public string Type { get; set; }

        /// <summary>
        /// Collected from the nativeCode attribute. Refer to Part 3 Streams - 5.8.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(ConditionAttributes.NATIVE_CODE)]
        public string NativeCode { get; set; }

        /// <summary>
        /// Collected from the nativeSeverity attribute. Refer to Part 3 Streams - 5.8.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(ConditionAttributes.NATIVE_SEVERITY)]
        public string NativeSeverity { get; set; }

        /// <summary>
        /// Collected from the qualifier attribute. Refer to Part 3 Streams - 5.8.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(ConditionAttributes.QUALIFIER)]
        public string Qualifier { get; set; }

        /// <summary>
        /// Collected from the statistic attribute. Refer to Part 3 Streams - 5.8.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(ConditionAttributes.STATISTIC)]
        public string Statistic { get; set; }

        /// <summary>
        /// Collected from the subType attribute. Refer to Part 3 Streams - 5.8.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(ConditionAttributes.SUB_TYPE)]
        public string SubType { get; set; }

        /// <summary>
        /// Collected from the compositionId attribute. Refer to Part 3 Streams - 5.8.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(ConditionAttributes.COMPOSITION_ID)]
        public string CompositionId { get; set; }

        /// <summary>
        /// Collected from the xs:lang attribute. Refer to Part 3 Streams - 5.8.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute("lang", XmlNamespace = "xs")]
        public string Language { get; set; }

        /// <summary>
        /// Collected from the textcontent of the Event element. Refer to Part 3 Streams - 5.8.4
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Reference to the name of the element. Refer to Part 3 Streams - 5.8
        /// </summary>
        public ConditionElements TagName { get; set; }

        /// <inheritdoc/>
        public Condition() : base() { }

        /// <inheritdoc/>
        public Condition(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version)
        {
            Value = xNode.InnerText;
            if (Enum.TryParse<ConditionElements>(xNode.LocalName, out ConditionElements condition))
            {
                TagName = condition;
            }
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.11.1")]
        private bool validateType(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Condition MUST include a 'type' attribute.",
                    SourceNode));
            }
            else if (!EnumHelper.Contains<Contracts.Enums.Devices.DataItemTypes.ConditionTypes>(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Condition 'type' attribute must be one of the following: [{EnumHelper.ToListString<Contracts.Enums.Devices.DataItemTypes.ConditionTypes>(", ", string.Empty, string.Empty)}].",
                    SourceNode));
            }
            else if (!EnumHelper.ValidateToVersion<Contracts.Enums.Devices.DataItemTypes.ConditionTypes>(Type, MtconnectVersion.GetValueOrDefault()))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.WARNING,
                    $"Condition type of '{Type}' is not supported in version '{MtconnectVersion}' of the MTConnect Standard.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8")]
        protected override bool validateNode(out ICollection<MtconnectValidationException> validationErrors)
            => validateNode<ConditionElements>(Contracts.Enums.Devices.CategoryTypes.CONDITION, out validationErrors);

        protected override bool validateValue(out ICollection<MtconnectValidationException> validationErrors) => throw new NotImplementedException();
    }
}
