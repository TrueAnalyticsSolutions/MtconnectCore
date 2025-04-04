using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Error.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Error
{
    /// <inheritdoc />
    public class ErrorDocument : ResponseDocument<ErrorDocumentHeader, Error>
    {
        private const string MODEL_BROWSER_URL = "https://model.mtconnect.org/#Package___19_0_3_91b028d_1579560529522_593444_6515";

        /// <inheritdoc/>
        public override DocumentTypes Type => DocumentTypes.Errors;

        /// <inheritdoc/>
        public override string DataElementName => "Errors";

        internal override ErrorDocumentHeader _header { get; set; }
        /// <inheritdoc cref="_header"/>
        public ErrorDocumentHeader Header => _header;

        /// <inheritdoc/>
        public ErrorDocument(XmlDocument xDoc) : base(xDoc)
        {
            _header = new ErrorDocumentHeader(xDoc.DocumentElement.FirstChild, NamespaceManager, MtconnectVersion.GetValueOrDefault());
        }

        /// <inheritdoc />
        public override bool TryAddItem(XmlNode xNode, XmlNamespaceManager nsmgr, out Error item) => base.TryAdd<Error>(xNode, nsmgr, ref _items, out item);


        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL)]
        private bool validateDevices(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();

            // Check Multiplicity of hasDevice
            if (Items.Length < 1)
            {
                validationErrors.Add(
                    new MtconnectValidationException(
                        ValidationSeverity.FATAL,
                        $"MTConnectErrors MUST include at least one Error element",
                        SourceDocument.DocumentElement) {
                        HelpLink = "https://model.mtconnect.org/#Structure__EAID_76BFE349_267B_45b3_B5FF_3C89D29AE715",
                        Source = SourceDocument.DocumentElement.LocalName,
                        Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.NOT_FOUND,
                        ScopeType = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.PART,
                        Scope = "xmlns:" + DefaultNamespace
                    });
            }

            return !validationErrors.Any(o => o.Severity >= ValidationSeverity.ERROR);
        }
    }
}
