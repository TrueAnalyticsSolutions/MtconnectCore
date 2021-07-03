using System;

namespace MtconnectCore.Logging
{
    public static class MtconnectCoreLogger {
        /// <summary>
        /// Sets the minimum logging level when no <see cref="IMtconnectCoreLogger"/> is provided.
        /// </summary>
        public static LoggingEventType InternalLogLevel { get; set; } = LoggingEventType.Information;

        private static IMtconnectCoreLogger _logger;
        /// <summary>
        /// Reference to the logger used within the MtconnectCore library.
        /// </summary>
        public static IMtconnectCoreLogger Logger => _logger ?? (_logger = new InternalLogger());

        /// <summary>
        /// Sets the logger to be used throughout the MtconnectCore library.
        /// </summary>
        /// <param name="logger">Reference to the implemented logger. See <see cref="IMtconnectCoreLogger"/></param>
        public static void RegisterLogger(IMtconnectCoreLogger logger) {
            _logger = logger;
        }

        public static void Log(this IMtconnectCoreLogger logger, string message, params object[] parameters)
        {
            logger.Log(new MtconnectCoreLogEntry(LoggingEventType.Information, message, null, parameters));
        }

        public static void Debug(this IMtconnectCoreLogger logger, string message, Exception exception = null, params object[] parameters)
        {
            logger.Log(new MtconnectCoreLogEntry(LoggingEventType.Debug, message, exception, parameters));
        }

        public static void Verbose(this IMtconnectCoreLogger logger, string message, params object[] parameters)
        {
            logger.Log(new MtconnectCoreLogEntry(LoggingEventType.Verbose, message, null, parameters));
        }

        public static void Warn(this IMtconnectCoreLogger logger, string message, params object[] parameters)
        {
            logger.Log(new MtconnectCoreLogEntry(LoggingEventType.Warning, message, null, parameters));
        }

        public static void Error(this IMtconnectCoreLogger logger, Exception ex, string message = null, params object[] parameters)
        {
            logger.Log(
                new MtconnectCoreLogEntry(LoggingEventType.Error, message ?? ex.Message, ex, parameters));
        }
    }
}
