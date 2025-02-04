using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
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
        public ParsedValue<DateTime> CreationTime { get; set; }

        /// <inheritdoc/>
        [MtconnectNodeAttribute(HeaderAttributes.SENDER)]
        public string Sender { get; set; }

        /// <inheritdoc/>
        [MtconnectNodeAttribute(HeaderAttributes.VERSION)]
        public string AgentVersion { get; set; }

        /// <inheritdoc/>
        [MtconnectNodeAttribute(HeaderAttributes.INSTANCE_ID)]
        public ParsedValue<ulong> InstanceId { get; set; }

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
        public ResponseDocumentHeader(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        /// <inheritdoc/>
        public override bool TryValidate(ValidationReport report)
        {
            using (var validationContext = report.CreateContext(this))
            {
                var baseResult = base.TryValidate(report);

                const string documentationAttributes = "https://model.mtconnect.org/#Structure__EAID_2299B0B3_B209_47ae_B93A_BA694AD50051";

                if (string.IsNullOrEmpty(AgentVersion))
                {
                    validationContext.AddExceptions(new MtconnectValidationException(
                        Contracts.Enums.ValidationSeverity.ERROR,
                        $"Response Document Header MUST include a 'version' attribute.",
                        SourceNode) {
                        Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.NOT_FOUND,
                        SourceContext = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY,
                        SourceContextScope = nameof(AgentVersion)
                    });
                }

                if (CreationTime == null)
                {
                    validationContext.AddExceptions(new MtconnectValidationException(
                        Contracts.Enums.ValidationSeverity.ERROR,
                        $"Response Document Header MUST include a 'creationTime' attribute.",
                        SourceNode) {
                        Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.NOT_FOUND,
                        SourceContext = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY,
                        SourceContextScope = nameof(CreationTime)
                    });
                }

                if (InstanceId == default(ulong))
                {
                    validationContext.AddExceptions(new MtconnectValidationException(
                        Contracts.Enums.ValidationSeverity.ERROR,
                        $"Response Document Header MUST include a 'instanceId' attribute.",
                        SourceNode) {
                        Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.NOT_FOUND,
                        SourceContext = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY,
                        SourceContextScope = nameof(InstanceId)
                    });
                }

                if (string.IsNullOrEmpty(Sender))
                {
                    validationContext.AddExceptions(new MtconnectValidationException(
                        Contracts.Enums.ValidationSeverity.ERROR,
                        $"Response Document Header MUST include a 'sender' attribute.",
                        SourceNode) {
                        Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.NOT_FOUND,
                        SourceContext = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY,
                        SourceContextScope = nameof(Sender)
                    });
                }

                return baseResult && !validationContext.HasErrors();
            }
        }
    }
}
