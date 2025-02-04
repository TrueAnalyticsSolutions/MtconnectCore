using System;
using System.Collections.Generic;
using System.Text;

namespace MtconnectCore.Standard.Contracts.Enums.ExceptionsReport
{
    /// <summary>
    /// Representation of available value types for MTConnectException Code to specify the category of exception.
    /// </summary>
    public enum ExceptionCodeEnum
    {
        /// <summary>
        /// Indicates a the context value type is mismatched. For example, a string instead of an Enumeration value.
        /// </summary>
        TYPE_MISMATCH,
        /// <summary>
        /// Indicates a property or sub-class of the context is missing.
        /// </summary>
        NOT_FOUND,
        /// <summary>
        /// Indicates the context has been deprecated.
        /// </summary>
        DEPRECATED,
        /// <summary>
        /// Indicates the context is considered an extension of the MTConnect Standard.
        /// </summary>
        EXTENDED,
        /// <summary>
        /// Indicates the context is out of range.
        /// </summary>
        OUT_OF_RANGE,
        /// <summary>
        /// Indicates that an entity that must be unique has been duplicated within the context.
        /// </summary>
        DUPLICATE_ENTRY,
        /// <summary>
        /// Indicates that the format of the provided data is invalid or does not conform to the expected pattern.
        /// </summary>
        INVALID_FORMAT,
    }
}
