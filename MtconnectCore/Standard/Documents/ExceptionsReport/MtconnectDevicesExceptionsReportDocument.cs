using System.Xml;

namespace MtconnectCore.Standard.Documents.ExceptionsReport
{
    public class MtconnectDevicesExceptionsReportDocument : MtconnectExceptionsReportDocument<MtconnectDevicesException>
    {
        public MtconnectDevicesExceptionsReportDocument(XmlDocument xDoc) : base(xDoc) { }

        public override bool TryAddItem(XmlNode xNode, XmlNamespaceManager nsmgr, out MtconnectDevicesException item) => throw new System.NotImplementedException();
    }
}
