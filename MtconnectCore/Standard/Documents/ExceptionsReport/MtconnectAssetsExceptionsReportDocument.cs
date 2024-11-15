using MtconnectCore.Standard.Contracts.Enums;
using System.Xml;

namespace MtconnectCore.Standard.Documents.ExceptionsReport
{
    public class MtconnectAssetsExceptionsReportDocument : MtconnectExceptionsReportDocument<MtconnectAssetsException>
    {
        public override DocumentTypes Type => DocumentTypes.AssetsExceptionsReport;

        public MtconnectAssetsExceptionsReportDocument(XmlDocument xDoc) : base(xDoc) { }

        public override bool TryAddItem(XmlNode xNode, XmlNamespaceManager nsmgr, out MtconnectAssetsException item) => throw new System.NotImplementedException();
    }
}
