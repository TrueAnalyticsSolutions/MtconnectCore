using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Assets.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Assets.Elements;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
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

        /// <inheritdoc cref="CuttingToolAttributes.REMOVED"/>
        [MtconnectNodeAttribute(CuttingToolAttributes.REMOVED)]
        public bool? Removed { get; set; }

        /// <inheritdoc cref="CuttingToolElements.DESCRIPTION"/>
        [MtconnectNodeElements(nameof(CuttingToolElements.DESCRIPTION), nameof(TrySetDescription))]
        public CuttingToolDescription Description { get; set; }

        /// <inheritdoc cref="CuttingToolElements.CUTTING_TOOL_DEFINITION"/>
        [MtconnectNodeElements(nameof(CuttingToolElements.CUTTING_TOOL_DEFINITION), nameof(TrySetDefinition))]
        public CuttingToolDefinition Definition { get; set; }

        /// <inheritdoc cref="CuttingToolElements.CUTTING_TOOL_LIFE_CYCLE"/>
        [MtconnectNodeElements(nameof(CuttingToolElements.CUTTING_TOOL_LIFE_CYCLE), nameof(TrySetToolLifeCycle))]
        public CuttingToolLifeCycle LifeCycle { get; set; }

        /// <inheritdoc cref="CuttingToolElements.CUTTING_TOOL_ARCHETYPE_REFERENCE"/>
        [MtconnectNodeElements(nameof(CuttingToolElements.CUTTING_TOOL_ARCHETYPE_REFERENCE), nameof(TrySetToolArchetypeReference))]
        public CuttingToolArchetypeReference ArchetypeReference { get; set; }

        /// <inheritdoc />
        public CuttingTool() : base() { }

        /// <inheritdoc/>
        public CuttingTool(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        public bool TrySetDescription(XmlNode xNode, XmlNamespaceManager nsmgr, out CuttingToolDescription cuttingToolDescription)
            => base.TrySet<CuttingToolDescription>(xNode, nsmgr, nameof(Description), out cuttingToolDescription);

        public bool TrySetDefinition(XmlNode xNode, XmlNamespaceManager nsmgr, out CuttingToolDefinition cuttingToolDefinition)
            => base.TrySet<CuttingToolDefinition>(xNode, nsmgr, nameof(Definition), out cuttingToolDefinition);

        public bool TrySetToolLifeCycle(XmlNode xNode, XmlNamespaceManager nsmgr, out CuttingToolLifeCycle cuttingToolLifeCycle)
            => base.TrySet<CuttingToolLifeCycle>(xNode, nsmgr, nameof(LifeCycle), out cuttingToolLifeCycle);

        public bool TrySetToolArchetypeReference(XmlNode xNode, XmlNamespaceManager nsmgr, out CuttingToolArchetypeReference cuttingToolArchetypeReference)
            => base.TrySet<CuttingToolArchetypeReference>(xNode, nsmgr, nameof(ArchetypeReference), out cuttingToolArchetypeReference);

        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.1")]
        public bool ValidateProperties(out ICollection<MtconnectValidationException> validationErrors)
        {
            return new NodeValidationContext(this)
                // Validate Timestamp
                //.ValidateValueProperty<CuttingToolAttributes>(nameof(Timestamp), (o) =>
                //    o.IsImplemented(Timestamp)
                //    ?.IsRequired(Timestamp)
                //)
                // Validate AssetId
                .ValidateValueProperty<CuttingToolAttributes>(nameof(AssetId), (o) =>
                    o.IsImplemented(AssetId)
                    ?.IsRequired(AssetId)
                )
                // Validate SerialNumber
                .ValidateValueProperty<CuttingToolAttributes>(nameof(SerialNumber), (o) =>
                    o.IsImplemented(SerialNumber)
                    ?.IsRequired(SerialNumber)
                )
                // Validate ToolId
                .ValidateValueProperty<CuttingToolAttributes>(nameof(ToolId), (o) =>
                    o.IsImplemented(ToolId)
                    ?.IsRequired(ToolId)
                )
                // Validate DeviceUuid
                .ValidateValueProperty<CuttingToolAttributes>(nameof(DeviceUuid), (o) =>
                    o.IsImplemented(DeviceUuid)
                    ?.IsRequired(DeviceUuid)
                )
                // Validate Definition deprecated
                //.ValidateValueProperty<CuttingToolElements>(nameof(Definition), (o) =>
                //    o.IsDeprecated(Definition)
                //)
                // Validate AssetId Recommendation
                //.ValidateValueProperty<CuttingToolAttributes>(nameof(AssetId), (o) =>
                //    o.IsImplemented(AssetId)
                //    ?.If(
                //        v => !string.Equals(AssetId, $"{ToolId}.{SerialNumber}", StringComparison.OrdinalIgnoreCase),
                //        v => o.AddValidationMessage(
                //            ValidationSeverity.MESSAGE,
                //            $"CuttingTool 'assetId' SHOULD be the combination of the 'toolId' and 'serialNumber' as in 'toolId.serialNumber'.")
                //    )
                //)
                // Return validation errors
                .HasError(out validationErrors);
        }

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.1")]
        //private bool validateTimestamp(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (Timestamp == null)
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"CuttingTool MUST include a 'timestamp' attribute."));
        //    }
        //    return !validationErrors.Any(o => o.Severity >= ValidationSeverity.ERROR);
        //}

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.1")]
        //private bool validateAssetId(out ICollection<MtconnectValidationException> validationErrors) {
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (string.IsNullOrEmpty(AssetId))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"CuttingTool MUST include a 'assetId' attribute."));
        //    }
        //    return !validationErrors.Any(o => o.Severity >= ValidationSeverity.ERROR);
        //}

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1")]
        //private bool validateAssetId_Recommendation(out ICollection<MtconnectValidationException> validationErrors) {
        //    validationErrors = new List<MtconnectValidationException>();

        //    if (!string.IsNullOrEmpty(AssetId) && !string.Equals(AssetId, $"{ToolId}.{SerialNumber}", StringComparison.OrdinalIgnoreCase))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.MESSAGE,
        //            $"CuttingTool 'assetId' SHOULD be the combination of the 'toolId' and 'serialNumber' as in 'toolId.serialNumber'."));
        //    }

        //    return !validationErrors.Any(o => o.Severity >= ValidationSeverity.ERROR);
        //}

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.1")]
        //private bool validateSerialNumber(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (string.IsNullOrEmpty(SerialNumber))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"CuttingTool MUST include a 'serialNumber' attribute."));
        //    }
        //    return !validationErrors.Any(o => o.Severity >= ValidationSeverity.ERROR);
        //}

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.1")]
        //private bool validateToolId(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (string.IsNullOrEmpty(ToolId))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"CuttingTool MUST include a 'toolId' attribute."));
        //    }
        //    return !validationErrors.Any(o => o.Severity >= ValidationSeverity.ERROR);
        //}

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.1")]
        //private bool validateDeviceUuid(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (string.IsNullOrEmpty(DeviceUuid))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"CuttingTool MUST include a 'deviceUuid' attribute."));
        //    }
        //    return !validationErrors.Any(o => o.Severity >= ValidationSeverity.ERROR);
        //}

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 4 Section 6.1.1")]
        //private bool validateCuttingToolDefinition_Deprecated(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (Definition != null)
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.WARNING,
        //            $"CuttingToolDefinition was deprecated in Version 1.3.0"));
        //    }
        //    return !validationErrors.Any(o => o.Severity >= ValidationSeverity.ERROR);
        //}
    }
}
