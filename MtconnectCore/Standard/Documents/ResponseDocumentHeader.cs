using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents
{
    /// <summary>
    /// Structural interface for a MTConnect Response Document Header. See Part 1 Section 6.5 of MTConnect specification.
    /// </summary>
    public abstract class ResponseDocumentHeader : MtconnectNode, IResponseDocumentHeader
    {
        /// <inheritdoc/>
        [MtconnectNodeAttribute(HeaderAttributes.CREATION_TIME)]
        public DateTime CreationTime { get; set; }

        /// <inheritdoc/>
        [MtconnectNodeAttribute(HeaderAttributes.SENDER)]
        public string Sender { get; set; }

        /// <inheritdoc/>
        [MtconnectNodeAttribute(HeaderAttributes.VERSION)]
        public string AgentVersion { get; set; }

        /// <inheritdoc/>
        [MtconnectNodeAttribute(HeaderAttributes.INSTANCE_ID)]
        public ulong InstanceId { get; set; }

        /// <summary>
        /// Initializes a blank MTConnect Response Document Header.
        /// </summary>
        public ResponseDocumentHeader() : base() { }

        /// <summary>
        /// Initializes a MTConnect Response Document Header from a source XML node.
        /// </summary>
        /// <param name="xNode">A source XML node from the MTConnect Response Document.</param>
        /// <param name="nsmgr">Reference to the namespace manager.</param>
        /// <param name="defaultNamespace">Reference to the namespace primarily used for this node.</param>
        /// <param name="version"></param>
        public ResponseDocumentHeader(XmlNode xNode, XmlNamespaceManager nsmgr, string defaultNamespace, MtconnectVersions version) : base(xNode, nsmgr, defaultNamespace, version) { }

        /// <inheritdoc/>
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            const string documentationAttributes = "See Part 1 Section 6.5.1 of the MTConnect standard.";
            validationErrors = new List<MtconnectValidationException>();

            if (string.IsNullOrEmpty(AgentVersion))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Response Document Header MUST include a 'version' attribute. {documentationAttributes}",
                    SourceNode));
            }

            if (CreationTime == null)
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Response Document Header MUST include a 'creationTime' attribute. {documentationAttributes}",
                    SourceNode));
            }

            if (InstanceId == default(ulong))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Response Document Header MUST include a 'instanceId' attribute. {documentationAttributes}",
                    SourceNode));
            }

            if (string.IsNullOrEmpty(Sender))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Response Document Header MUST include a 'sender' attribute. {documentationAttributes}",
                    SourceNode));
            }

            return !validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR);
        }
    }
}
