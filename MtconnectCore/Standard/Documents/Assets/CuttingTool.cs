using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Assets.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Assets.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Assets
{
    public class CuttingTool : Asset {
        /// <inheritdoc cref="CuttingToolAttributes.ASSET_ID"/>
        [MtconnectNodeAttribute(CuttingToolAttributes.ASSET_ID)]
        public string AssetId { get; set; }

        /// <inheritdoc cref="CuttingToolAttributes.SERIAL_NUMBER"/>
        [MtconnectNodeAttribute(CuttingToolAttributes.SERIAL_NUMBER)]
        public string SerialNumber { get; set; }

        /// <inheritdoc cref="CuttingToolAttributes.MANUFACTURERS"/>
        [MtconnectNodeAttribute(CuttingToolAttributes.MANUFACTURERS)]
        public string Manufacturers { get; set; }

        /// <inheritdoc cref="CuttingToolAttributes.TIMESTAMP"/>
        [MtconnectNodeAttribute(CuttingToolAttributes.TIMESTAMP)]
        public DateTime Timestamp { get; set; }

        /// <inheritdoc cref="CuttingToolAttributes.DEVICE_UUID"/>
        [MtconnectNodeAttribute(CuttingToolAttributes.DEVICE_UUID)]
        public string DeviceUuid { get; set; }

        /// <inheritdoc cref="CuttingToolAttributes.TOOL_ID"/>
        [MtconnectNodeAttribute(CuttingToolAttributes.TOOL_ID)]
        public string ToolId { get; set; }

        /// <inheritdoc cref="CuttingToolElements.DESCRIPTION"/>
        [MtconnectNodeElements(nameof(CuttingToolElements.DESCRIPTION), nameof(TrySetDescription), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public CuttingToolDescription Description { get; set; }

        /// <inheritdoc cref="CuttingToolElements.CUTTING_TOOL_DEFINITION"/>
        [MtconnectNodeElements(nameof(CuttingToolElements.CUTTING_TOOL_DEFINITION), nameof(TrySetDefinition), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public CuttingToolDefinition Definition { get; set; }

        /// <inheritdoc cref="CuttingToolElements.CUTTING_TOOL_LIFE_CYCLE"/>
        [MtconnectNodeElements(nameof(CuttingToolElements.CUTTING_TOOL_LIFE_CYCLE), nameof(TrySetToolLifeCycle), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public CuttingToolLifeCycle LifeCycle { get; set; }

        /// <inheritdoc />
        public CuttingTool() : base() { }

        /// <inheritdoc/>
        public CuttingTool(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE, version) { }

        public bool TrySetDescription(XmlNode xNode, XmlNamespaceManager nsmgr, out CuttingToolDescription cuttingToolDescription)
            => base.TrySet<CuttingToolDescription>(xNode, nsmgr, nameof(Description), out cuttingToolDescription);

        public bool TrySetDefinition(XmlNode xNode, XmlNamespaceManager nsmgr, out CuttingToolDefinition cuttingToolDefinition)
            => base.TrySet<CuttingToolDefinition>(xNode, nsmgr, nameof(Definition), out cuttingToolDefinition);

        public bool TrySetToolLifeCycle(XmlNode xNode, XmlNamespaceManager nsmgr, out CuttingToolLifeCycle cuttingToolLifeCycle)
            => base.TrySet<CuttingToolLifeCycle>(xNode, nsmgr, nameof(LifeCycle), out cuttingToolLifeCycle);

        /// <inheritdoc/>
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            base.TryValidate(out validationErrors);

            const string documentationAttributes = "See Part 4 Section 6.1 of the MTConnect standard.";

            if (Timestamp == null) {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"CuttingTool MUST include a 'timestamp' attribute. {documentationAttributes}"));
            }

            if (string.IsNullOrEmpty(SerialNumber))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"CuttingTool MUST include a 'serialNumber' attribute. {documentationAttributes}"));
            }

            if (string.IsNullOrEmpty(ToolId))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"CuttingTool MUST include a 'toolId' attribute. {documentationAttributes}"));
            }

            if (string.IsNullOrEmpty(DeviceUuid))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"CuttingTool MUST include a 'deviceUuid' attribute. {documentationAttributes}"));
            }

            if (string.IsNullOrEmpty(AssetId))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"CuttingTool MUST include a 'assetId' attribute. {documentationAttributes}"));
            }

            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectValidationMethod(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1")]
        private bool validateAssetId_Recommendation(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            
            if (!string.IsNullOrEmpty(AssetId) && !string.Equals(AssetId, $"{ToolId}.{SerialNumber}", StringComparison.OrdinalIgnoreCase))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.MESSAGE,
                    $"CuttingTool 'assetId' SHOULD be the combination of the 'toolId' and 'serialNumber' as in 'toolId.serialNumber'."));
            }

            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
