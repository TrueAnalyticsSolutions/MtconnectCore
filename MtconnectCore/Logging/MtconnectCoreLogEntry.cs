using System;

namespace MtconnectCore.Logging
{
    // Immutable DTO that contains the log information.
    public class MtconnectCoreLogEntry
    {
        public LoggingEventType Severity { get; }
        public string Message { get; }
        public Exception Exception { get; }
        public object[] Parameters { get; }

        public MtconnectCoreLogEntry(
            LoggingEventType severity,
            string message,
            Exception exception = null,
            params object[] parameters
        )
        {
            if (message == null) throw new ArgumentNullException("message");
            if (message == string.Empty)
                throw new ArgumentException("empty", "message");

            this.Severity = severity;
            this.Message = message;
            this.Exception = exception;
            this.Parameters = parameters;
        }
    }
}
