using System.Xml;

namespace MtconnectCore.Standard.Documents.ExceptionsReport
{
    public abstract class MtconnectExceptionsReportDocument<T> : ResponseDocument<MtconnectExceptionsReportHeader, T> where T : MtconnectException
    {
        /// <inheritdoc/>
        public override Contracts.Enums.DocumentTypes Type => Contracts.Enums.DocumentTypes.ExceptionsReport;

        /// <inheritdoc/>
        public override string DataElementName => "ExceptionsReport";

        internal override MtconnectExceptionsReportHeader _header { get; set; }
        /// <inheritdoc cref="_header"/>
        public MtconnectExceptionsReportHeader Header => _header;

        /// <inheritdoc/>
        public MtconnectExceptionsReportDocument(XmlDocument xDoc) : base(xDoc)
        {
            _header = new MtconnectExceptionsReportHeader(xDoc.DocumentElement.FirstChild, NamespaceManager, MtconnectVersion.GetValueOrDefault());
        }
    }
}
