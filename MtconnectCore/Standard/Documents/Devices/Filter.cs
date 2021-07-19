using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <summary>
    /// Filter provides a means to control when an Agent records updated information for a data item. Currently, there are two types of Filter elements defined in the MTConnect Standard - MINIMUM_DELTA and PERIOD.More Filter types may be added in the future.
    /// </summary>
    public class Filter : MtconnectNode
    {
        /// <inheritdoc cref="FilterAttributes.TYPE"/>
        [MtconnectNodeAttribute(FilterAttributes.TYPE)]
        public string Type { get; set; }

        /// <summary>
        /// Inner content (CDATA) of the Filter element.
        /// </summary>
        public string Value { get; set; }

        /// <inheritdoc/>
        public Filter() : base() { }

        /// <inheritdoc/>
        public Filter(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE)
        {
            Value = xNode.InnerText;
        }

        /// <inheritdoc/>
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            const string documentationAttributes = "See Part 2 Section 7.2.3.3.1 of the MTConnect standard.";
            validationErrors = new List<MtconnectValidationException>();

            if (string.IsNullOrEmpty(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Filter MUST include a 'type' attribute. {documentationAttributes}"));
            }

            return !validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR);
        }
    }
}
