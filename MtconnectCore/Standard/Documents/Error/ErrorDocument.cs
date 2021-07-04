using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Error.Attributes;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Error
{
    public class ErrorDocument : ResponseDocument<ErrorDocumentHeader, Error>
    {
        public override DocumentTypes Type => DocumentTypes.Errors;

        public override string DefaultNamespace => Constants.DEFAULT_XML_NAMESPACE;

        public override string DataElementName => "Errors";

        internal override ErrorDocumentHeader _header { get; set; }
        public ErrorDocumentHeader Header => _header;

        public ErrorDocument(XmlDocument xDoc) : base(xDoc)
        {
            _header = new ErrorDocumentHeader(xDoc.DocumentElement.FirstChild, NamespaceManager);
        }

        public override bool TryAddItem(XmlNode xNode, XmlNamespaceManager nsmgr, out Error item)
        {
            Logger.Verbose("Reading Error {XnodeKey}", xNode.TryGetAttribute(ErrorAttributes.ERROR_CODE));
            item = new Error(xNode, nsmgr);
            if (!item.IsValid())
            {
                Logger.Warn($"[Invalid Error] Error is not formatted properly, refer to Part 1 Section 9 of MTConnect Standard.");
                return false;
            }
            _items.Add(item);
            return true;
        }
    }
}
