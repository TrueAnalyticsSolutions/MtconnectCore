using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    public class Source : MtconnectNode
    {
        /// <inheritdoc cref="SourceAttributes.COMPONENT_ID"/>
        [MtconnectNodeAttribute(SourceAttributes.COMPONENT_ID)]
        public string ComponentId { get; set; }

        /// <inheritdoc cref="SourceAttributes.COMPOSITION_ID"/>
        [MtconnectNodeAttribute(SourceAttributes.COMPOSITION_ID)]
        public string CompositionId { get; set; }

        /// <inheritdoc cref="SourceAttributes.DATA_ITEM_ID"/>
        [MtconnectNodeAttribute(SourceAttributes.DATA_ITEM_ID)]
        public string DataItemId { get; set; }

        /// <inheritdoc/>
        public Source() : base() { }

        /// <inheritdoc/>
        public Source(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        private bool ValidateProperties(out ICollection<MtconnectValidationException> validationErrors)
        {
            return new NodeValidationContext(this)
                // Validate componentId
                .ValidateValueProperty(
                    SourceAttributes.COMPONENT_ID,
                    (o) =>
                        o.IsImplemented(ComponentId)
                        ?.IsIdValueType(ComponentId)
                )
                // Validate compositionId
                .ValidateValueProperty(
                    SourceAttributes.COMPOSITION_ID,
                    (o) =>
                        o.IsImplemented(CompositionId)
                        ?.IsIdValueType(CompositionId)
                )
                // Validate dataItemId
                .ValidateValueProperty(
                    SourceAttributes.DATA_ITEM_ID,
                    (o) =>
                        o.IsImplemented(DataItemId)
                        ?.IsIdValueType(DataItemId)
                )
                // Validate that at least one of ComponentId, CompositionId, or DataItemId is provided
                .ValidateValueProperty<SourceAttributes>(nameof( ComponentId), (o) =>
                    o.IsImplemented(ComponentId)
                    ?? o.IsImplemented(CompositionId)
                    ?? o.IsImplemented(DataItemId)
                    //?.Or(
                    //    o.IsImplemented(CompositionId),
                    //    o.IsImplemented(DataItemId),
                    //    (v) => throw new MtconnectValidationException(
                    //        ValidationSeverity.ERROR,
                    //        "One of 'componentId', 'compositionId', or 'dataItemId' MUST be provided."
                    //    )
                    //)
                )
                // Return validation errors
                .HasError(out validationErrors);
        }

        //private bool validateSourceId(out ICollection<MtconnectValidationException> validationErrors) {
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (string.IsNullOrEmpty(ComponentId) && string.IsNullOrEmpty(CompositionId) && string.IsNullOrEmpty(DataItemId)) {
        //        validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, $"One of 'componentId', 'compositionId', or 'dataItemId' MUST be provided."));
        //    }
        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}
    }
}
