using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System.Collections.Generic;
using System.Xml;
using HeaderAttributes = MtconnectCore.Standard.Contracts.Enums.Devices.Attributes.HeaderAttributes;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <inheritdoc/>
    public class DevicesDocumentHeader : ResponseDocumentHeader
    {
        /// <inheritdoc cref="HeaderAttributes.BUFFER_SIZE"/>
        [MtconnectNodeAttribute(HeaderAttributes.BUFFER_SIZE)]
        public ParsedValue<uint> BufferSize { get; set; }

        /// <inheritdoc cref="HeaderAttributes.TEST_INDICATOR"/>
        [MtconnectNodeAttribute(HeaderAttributes.TEST_INDICATOR)]
        public ParsedValue<bool> TestIndicator { get; set; }

        /// <inheritdoc cref="HeaderAttributes.ASSET_BUFFER_SIZE"/>
        [MtconnectNodeAttribute(HeaderAttributes.ASSET_BUFFER_SIZE)]
        public ParsedValue<uint?> AssetBufferSize { get; set; }

        /// <inheritdoc cref="HeaderAttributes.ASSET_COUNT"/>
        [MtconnectNodeAttribute(HeaderAttributes.ASSET_COUNT)]
        public ParsedValue<uint?> AssetCount { get; set; }

        /// <inheritdoc />
        public DevicesDocumentHeader() : base() { }

        /// <inheritdoc />
        public DevicesDocumentHeader(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2")]
        private bool ValidateProperties(out ICollection<MtconnectValidationException> validationErrors)
        {
            return new NodeValidationContext(this)
                // Validate assetBufferSize
                .ValidateValueProperty(
                    HeaderAttributes.ASSET_BUFFER_SIZE,
                    (o) =>
                        o.IsImplemented(AssetBufferSize)
                        ?.IsUIntValueType(AssetBufferSize, out _)
                )
                // Validate assetCount
                .ValidateValueProperty(
                    HeaderAttributes.ASSET_COUNT,
                    (o) =>
                        o.IsImplemented(AssetCount)
                        ?.IsUIntValueType(AssetCount, out _)
                )
                // Validate BufferSize
                .ValidateValueProperty(
                    HeaderAttributes.BUFFER_SIZE,
                    (o) =>
                        o.IsImplemented(BufferSize)
                        ?.IsUIntValueType(BufferSize, out _)
                )
                // Validate testIndicator
                .ValidateValueProperty(
                    HeaderAttributes.TEST_INDICATOR,
                    (o) =>
                        o.IsImplemented(TestIndicator)
                        ?.IsBooleanValueType(TestIndicator, out _)
                )
                // Return validation errors
                .HasError(out validationErrors);
        }
    }
}
