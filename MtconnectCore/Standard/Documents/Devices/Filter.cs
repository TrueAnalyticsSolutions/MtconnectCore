using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System.Collections.Generic;
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
        public ParsedValue<float?> Value { get; set; }

        /// <inheritdoc/>
        public Filter() : base() { }

        /// <inheritdoc/>
        public Filter(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version)
        {
            Value = xNode.InnerText;
        }

        private bool ValidateProperties(out ICollection<MtconnectValidationException> validationErrors)
        {
            return new NodeValidationContext(this)
                // Validate type
                .ValidateValueProperty(
                    FilterAttributes.TYPE,
                    (o) =>
                        o.IsImplemented(Type)
                        ?.IsRequired(Type)
                )
                // Validate value
                .Validate((o) =>
                    o.IsFloatValueType(nameof(Value), Value?.RawValue, out _)
                )
                // Return validation errors
                .HasError(out validationErrors);
        }
    }
}
