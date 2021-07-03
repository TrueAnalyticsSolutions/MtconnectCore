using MtconnectCore.Standard.Documents.Error;
using System;
using System.Collections.Generic;
using System.Text;

namespace MtconnectCore.Standard.Contracts.Errors
{
    public class MtconnectDocumentErrorException : Exception
    {
        public string ErrorCode { get; set; }

        public MtconnectDocumentErrorException(Error error) : base($"MTConnect Document error {error.ErrorCode} occurred", new Exception(error.Value))
        {
            ErrorCode = error.ErrorCode.ToString();
        }
    }
}
