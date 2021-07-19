using MtconnectCore.Standard.Documents.Error;
using System;
using System.Collections.Generic;
using System.Text;

namespace MtconnectCore.Standard.Contracts.Errors
{
    /// <summary>
    /// An exception containing a specific Error from a MTConnect Errors Response Document.
    /// </summary>
    public class MtconnectDocumentErrorException : Exception
    {
        /// <inheritdoc cref="Error.ErrorCode"/>
        public string ErrorCode { get; set; }

        /// <inheritdoc/>
        public MtconnectDocumentErrorException(Error error) : base($"MTConnect Document error {error.ErrorCode} occurred", new Exception(error.Value))
        {
            ErrorCode = error.ErrorCode.ToString();
        }
    }
}
