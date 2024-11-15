using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.ExceptionsReport.Attributes;
using System.Xml;

namespace MtconnectCore.Standard.Documents.ExceptionsReport
{
    public class MtconnectExceptionsReportHeader : ResponseDocumentHeader
    {
        [MtconnectNodeAttribute(HeaderAttributes.TEST_INDICATOR)]
        public bool TestIndicator { get; set; }

        /// <inheritdoc />
        public MtconnectExceptionsReportHeader() : base() { }

        /// <inheritdoc />
        public MtconnectExceptionsReportHeader(XmlNode xNode, XmlNamespaceManager nsmgr, Contracts.Enums.MtconnectVersions version) : base(xNode, nsmgr, version) { }
    }
}
