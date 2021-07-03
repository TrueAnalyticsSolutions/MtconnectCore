using System;
using System.Diagnostics;

namespace MtconnectCore.Logging
{
    /// <summary>
    /// An internal implementation of <see cref="IMtconnectCoreLogger"/> that is used when no other loggers are specified
    /// </summary>
    internal class InternalLogger : IMtconnectCoreLogger
    {
        public InternalLogger() { }

        public void Log(MtconnectCoreLogEntry entry)
        {
            if (MtconnectCoreLogger.InternalLogLevel < entry.Severity) return;

            DateTime now = DateTime.UtcNow;
            if (entry.Exception == null)
            {
                Debug.Write($"{now.ToShortTimeString()} [{entry.Severity}] {entry.Message} {entry.Parameters}");
            }
            else
            {
                Debug.Fail($"{now.ToShortTimeString()} [{entry.Severity}] {entry.Message} {entry.Parameters}\r\n\t{entry.Exception}");
            }
        }
    }
}
