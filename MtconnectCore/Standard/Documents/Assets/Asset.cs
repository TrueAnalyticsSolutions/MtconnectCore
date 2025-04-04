using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Assets.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
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
        public Asset(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 4 Section 3.2.3.1")]
        protected virtual bool ValidateProperties(out ICollection<MtconnectValidationException> validationErrors)
        {
            return new NodeValidationContext(this)
                // Validate AssetId property
                .ValidateValueProperty<AssetAttributes>(nameof(AssetId), (o) =>
                    o.IsImplemented(AssetId)
                    ?.If(
                        v => string.IsNullOrEmpty(AssetId),
                        v => throw new MtconnectValidationException(
                            ValidationSeverity.ERROR,
                            "Asset MUST include a 'assetId' attribute.",
                            SourceNode) {
                            Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.NOT_FOUND,
                            ScopeType = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY,
                            Scope = nameof(AssetId)
                        }
                    )
                )
                // Validate Timestamp property
                //.ValidateValueProperty<AssetAttributes>(nameof(Timestamp), (o) =>
                //    o.IsImplemented(Timestamp)
                //    ?.If(
                //        v => Timestamp == null || Timestamp == default(DateTime),
                //        v => throw new MtconnectValidationException(
                //            ValidationSeverity.ERROR,
                //            "Asset MUST include a 'timestamp' attribute.",
                //            SourceNode)
                //    )
                //)
                // Return validation errors
                .HasError(out validationErrors);
        }

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 4 Section 3.2.3.1")]
        //private bool validateAssetId(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (string.IsNullOrEmpty(AssetId))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, $"Asset MUST include a 'assetId' attribute.", SourceNode));
        //    }
        //    return !validationErrors.Any(o => o.Severity >= ValidationSeverity.ERROR);
        //}

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 4 Section 3.2.3.1")]
        //private bool validateTimestamp(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (Timestamp == null || Timestamp == default(DateTime))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, $"Asset MUST include a 'timestamp' attribute.", SourceNode));
        //    }
        //    return !validationErrors.Any(o => o.Severity >= ValidationSeverity.ERROR);
        //}
    }
}
