using MtconnectCore.Standard.Documents;
using System;

namespace MtconnectCore.Standard.Contracts.Errors
{
    public partial class MtconnectDocumentTypeMismatch<THeader, TItem> : Exception where THeader : IResponseDocumentHeader where TItem : MtconnectNode
    {
        public string ExpectedType { get; set; }
        public string ReceivedType { get; set; }

        public MtconnectDocumentTypeMismatch(ResponseDocument<THeader, TItem> document)
        {
            ExpectedType = document.Type.ToString();
            ReceivedType = document.DocumentElementName;
        }

        public override string ToString()
        {
            return $"MTConnect Document does not match expected document type. Expected {ExpectedType} and received {ReceivedType}. {Message}";
        }
    }
}
