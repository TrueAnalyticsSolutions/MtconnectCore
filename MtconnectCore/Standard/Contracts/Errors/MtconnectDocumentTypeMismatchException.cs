using MtconnectCore.Standard.Documents;
using System;

namespace MtconnectCore.Standard.Contracts.Errors
{
    /// <summary>
    /// An exception raised when the MTConnect Document Type received from the Agent request conflicted with what was expected.
    /// </summary>
    /// <typeparam name="THeader">Reference to the type of <see cref="IResponseDocumentHeader"/>.</typeparam>
    /// <typeparam name="TItem">Reference to the root element in the <see cref="IResponseDocument"/>.</typeparam>
    public partial class MtconnectDocumentTypeMismatchException<THeader, TItem> : Exception where THeader : IResponseDocumentHeader where TItem : MtconnectNode
    {
        /// <summary>
        /// The expected MTConnect Response Document type. See also, <seealso cref="IResponseDocument.Type"/>.
        /// </summary>
        public string ExpectedType { get; set; }

        /// <summary>
        /// The actual document type that was received from the MTConnect Agent.
        /// </summary>
        public string ReceivedType { get; set; }

        /// <summary>
        /// Initializes a <see cref="MtconnectDocumentTypeMismatchException{THeader, TItem}"/> from the response document.
        /// </summary>
        /// <param name="document"></param>
        public MtconnectDocumentTypeMismatchException(ResponseDocument<THeader, TItem> document)
        {
            ExpectedType = document.Type.ToString();
            ReceivedType = document.DocumentElementName;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"MTConnect Document does not match expected document type. Expected {ExpectedType} and received {ReceivedType}. {Message}";
        }
    }
}
