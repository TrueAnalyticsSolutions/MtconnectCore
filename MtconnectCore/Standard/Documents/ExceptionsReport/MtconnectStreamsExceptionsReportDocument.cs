using MtconnectCore.Standard.Contracts.Enums;
using System.Xml;

namespace MtconnectCore.Standard.Documents.ExceptionsReport
{
    public class MtconnectStreamsExceptionsReportDocument : MtconnectExceptionsReportDocument<MtconnectStreamsException>
    {
        public override DocumentTypes Type => DocumentTypes.AssetsExceptionsReport;

        public MtconnectStreamsExceptionsReportDocument(XmlDocument xDoc) : base(xDoc) { }

        public override bool TryAddItem(XmlNode xNode, XmlNamespaceManager nsmgr, out MtconnectStreamsException item) => throw new System.NotImplementedException();
    }
}
