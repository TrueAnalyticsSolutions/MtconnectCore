using MtconnectCore.Standard.Contracts.Enums;
using System.Xml;

namespace MtconnectCore.Standard.Documents.ExceptionsReport
{
    public class MtconnectDevicesExceptionsReportDocument : MtconnectExceptionsReportDocument<MtconnectDevicesException>
    {
        public override DocumentTypes Type => DocumentTypes.AssetsExceptionsReport;

        public MtconnectDevicesExceptionsReportDocument(XmlDocument xDoc) : base(xDoc) { }

        public override bool TryAddItem(XmlNode xNode, XmlNamespaceManager nsmgr, out MtconnectDevicesException item) => throw new System.NotImplementedException();
    }
}
