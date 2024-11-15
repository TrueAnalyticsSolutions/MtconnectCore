using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Enums.ExceptionsReport;

namespace MtconnectCore.Standard.Documents.ExceptionsReport
{
    /// <summary>
    /// Base class for MTConnect Exception instances.
    /// </summary>
    public abstract class MtconnectException : MtconnectNode
    {
        /// <summary>
        /// Detailed description explaining the context of the exception.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Indicates how severely the exceptions violates the MTConnect Standard.
        /// </summary>
        public Contracts.Enums.ValidationSeverity Severity { get; set; }

        /// <summary>
        /// Specifies the category for the exception.
        /// </summary>
        public ExceptionCodeEnum Code { get; set; }

        /// <summary>
        /// Reference to the source class for the exception. Note: This could be XPath, JPath, etc.
        /// </summary>
        public virtual object Source { get; set; }

        /// <summary>
        /// Specifies the context for the exception as it relates to the <see cref="Source"/>. 
        /// </summary>
        public ExceptionContextEnum Context { get; set; }

        /// <summary>
        /// Optional reference to the scope for the context. For example, consider <see cref="Context"/> == VALUE_PROPERTY, then this could be <c>category</c> for a <c>DataItem</c>.
        /// </summary>
        public string ContextScope { get; set; }
    }
}
