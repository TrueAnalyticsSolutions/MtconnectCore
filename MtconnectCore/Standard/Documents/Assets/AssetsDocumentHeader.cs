using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Assets
{
    /// <inheritdoc />
    public class AssetsDocumentHeader : ResponseDocumentHeader
    {
        /// <summary>
        /// A value representing the maximum number of Asset Documents that can be stored in the Agent that published the Response Document.
        /// </summary>
        [MtconnectNodeAttribute(Contracts.Enums.Assets.Attributes.HeaderAttributes.ASSET_BUFFER_SIZE)]
        public uint? AssetBufferSize { get; set; }

        /// <summary>
        /// A value representing the maximum number of Asset Documents that can be stored in the Agent that published the Response Document.
        /// </summary>
        [MtconnectNodeAttribute(Contracts.Enums.Assets.Attributes.HeaderAttributes.ASSET_BUFFER_SIZE)]
        public uint? AssetCount { get; set; }

        /// <inheritdoc />
        public AssetsDocumentHeader() : base() { }

        /// <inheritdoc />
        public AssetsDocumentHeader(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE, version) { }

        /// <inheritdoc />
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            base.TryValidate(out validationErrors);

            const string documentationAttributes = "See Part 2 Section 4.4.2 of the MTConnect standard.";

            if (!AssetBufferSize.HasValue)
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"MTConnectDevices Header MUST include a 'assetBufferSize' attribute. {documentationAttributes}"));
            }

            if (!AssetCount.HasValue)
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"MTConnectDevices Header MUST include a 'assetCount' attribute. {documentationAttributes}"));
            }

            return !validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR);
        }
    }
}
