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
        /// URI of the artifact of where the exception occurred.
        /// </summary>
        public virtual object Source { get; set; }

        /// <summary>
        /// Path to the exception.
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        /// Designates the exception property kind. For example, <c>ScopeTypeEnum</c>: {<see cref="ExceptionContextEnum.ENTITY" />, <see cref="ExceptionContextEnum.VALUE_PROPERTY" />, or <see cref="ExceptionContextEnum.PART" />}.
        /// </summary>
        public ExceptionContextEnum ScopeType { get; set; }

        /// <summary>
        /// Optional reference to the scope (or name of a property) for the context. For example, consider <see cref="ScopeType"/> == VALUE_PROPERTY, then this could be <c>category</c> for a <c>DataItem</c>.
        /// </summary>
        public string Scope { get; set; }
    }
}
