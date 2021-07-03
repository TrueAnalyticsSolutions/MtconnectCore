using System;
using System.Collections.Generic;
using System.Text;

namespace MtconnectCore.Standard.Contracts.Enums.Error
{
    /// <summary>
    /// Reference Part 1, Section 9.1.2.3 of the MTConnect Standard for a list of appropriate values for the errorCode attribute
    /// </summary>
    public enum ErrorCodes
    {
        ASSET_NOT_FOUND,
        INTERNAL_ERROR,
        INVALID_REQUEST,
        INVALID_URI,
        INVALID_XPATH,
        NO_DEVICE,
        OUT_OF_RANGE,
        QUERY_ERROR,
        TOO_MANY,
        UNAUTHORIZED,
        UNSUPPORTED
    }
}
