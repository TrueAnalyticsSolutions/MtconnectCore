using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Assets.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Assets
{
    public abstract class Asset : MtconnectNode
    {
        /// <inheritdoc cref="AssetAttributes.ASSET_ID"/>
        [MtconnectNodeAttribute(AssetAttributes.ASSET_ID)]
        public string AssetId { get; set; }

        /// <inheritdoc cref="AssetAttributes.TIMESTAMP"/>
        [MtconnectNodeAttribute(AssetAttributes.TIMESTAMP)]
        public DateTime Timestamp { get; set; }

        /// <inheritdoc cref="AssetAttributes.DEVICE_UUID"/>
        [MtconnectNodeAttribute(AssetAttributes.DEVICE_UUID)]
        public string DeviceUuid { get; set; }

        /// <inheritdoc cref="AssetAttributes.REMOVED"/>
        [MtconnectNodeAttribute(AssetAttributes.REMOVED)]
        public bool? Removed { get; set; }

        /// <inheritdoc/>
        public Asset() : base() { }

        /// <inheritdoc/>
        public Asset(XmlNode xNode, XmlNamespaceManager nsmgr, string defaultNamespace, MtconnectVersions version) : base(xNode, nsmgr, defaultNamespace ?? Constants.DEFAULT_DEVICES_XML_NAMESPACE, version) { }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 4 Section 3.2.3.1")]
        private bool validateAssetId(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(AssetId))
            {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, $"Asset MUST include a 'assetId' attribute.", SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 4 Section 3.2.3.1")]
        private bool validateTimestamp(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (Timestamp == null || Timestamp == default(DateTime))
            {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, $"Asset MUST include a 'timestamp' attribute.", SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
