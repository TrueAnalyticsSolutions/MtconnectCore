﻿using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using HeaderAttributes = MtconnectCore.Standard.Contracts.Enums.Devices.Attributes.HeaderAttributes;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <inheritdoc/>
    public class DevicesDocumentHeader : ResponseDocumentHeader
    {
        /// <summary>
        /// A value representing the maximum number of Data Entities that MAY be retained in the Agent that published the Response Document at any point in time.
        /// </summary>
        [MtconnectNodeAttribute(HeaderAttributes.BUFFER_SIZE)]
        public uint BufferSize { get; set; }

        /// <summary>
        /// A flag indicating that the Agent that published the Response Document is operating in a test mode.The contents of the Response Document may not be valid and SHOULD be used for testing and simulation purposes only.
        /// </summary>
        [MtconnectNodeAttribute(HeaderAttributes.TEST_INDICATOR)]
        public bool TestIndicator { get; set; }

        /// <summary>
        /// A value representing the maximum number of Asset Documents that can be stored in the Agent that published the Response Document.
        /// </summary>
        [MtconnectNodeAttribute(HeaderAttributes.ASSET_BUFFER_SIZE)]
        public uint? AssetBufferSize { get; set; }

        /// <summary>
        /// A number representing the current number of Asset Documents that are currently stored in the Agent as of the creationTime that the Agent published the Response Document.
        /// </summary>
        [MtconnectNodeAttribute(HeaderAttributes.ASSET_COUNT)]
        public uint? AssetCount { get; set; }

        /// <inheritdoc />
        public DevicesDocumentHeader() : base() { }

        /// <inheritdoc />
        public DevicesDocumentHeader(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE, version) { }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2")]
        private bool validateBufferSize(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (BufferSize == default(uint))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"MTConnectDevices Header MUST include a 'bufferSize' attribute."));
            }

            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2")]
        private bool validateAssetBufferSize(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!AssetBufferSize.HasValue)
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"MTConnectDevices Header MUST include a 'assetBufferSize' attribute."));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2")]
        private bool validateAssetCount(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!AssetCount.HasValue)
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"MTConnectDevices Header MUST include a 'assetCount' attribute."));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
