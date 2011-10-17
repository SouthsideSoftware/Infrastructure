using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Infrastructure.Core.Logging;

namespace Infrastructure.Logging.Trace {
    /// <summary>
    /// Logger that works with standard .NET trace logging.
    /// </summary>
    public class TraceLog : ILog {
        /// <summary>
        /// Gets the name of the logger.
        /// </summary>
        public string Name {
            get {
                return "Trace";
            }
        }

        /// <summary>
        /// Gets <see langword="true"/>.
        /// </summary>
        /// <remarks>Because of the way trace logging works, this always returns true and should not be used.</remarks>
        public bool IsErrorEnabled {
            get {
                return true;
            }
        }

        /// <summary>
        /// Gets <see langword="true"/>.
        /// </summary>
        /// <remarks>Because of the way trace logging works, this always returns true and should not be used.</remarks>
        public bool IsFatalEnabled {
            get {
                return true;
            }
        }

        /// <summary>
        /// Gets <see langword="true"/>.
        /// </summary>
        /// <remarks>Because of the way trace logging works, this always returns true and should not be used.</remarks>
        public bool IsDebugEnabled {
            get {
                return true;
            }
        }

        /// <summary>
        /// Gets <see langword="true"/>.
        /// </summary>
        public bool IsInfoEnabled {
            get {
                return true;
            }
        }

        /// <summary>
        /// Gets <see langword="true"/>.
        /// </summary>
        public bool IsWarnEnabled {
            get {
                return true;
            }
        }

        /// <summary>
        /// Log a message at the error level.
        /// </summary>
        /// <param name="message"></param>
        public void Error(object message) {
            System.Diagnostics.Trace.TraceError(message.ToString());
        }

        /// <summary>
        /// Log a message and exception at the error level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Error(object message, Exception exception) {
            System.Diagnostics.Trace.TraceError("{0} {1}", message, exception.ToString());
        }

        /// <summary>
        /// Log a message using a format string at the error level.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void ErrorFormat(string format, params object[] args) {
            System.Diagnostics.Trace.TraceError(format, args);
        }

        /// <summary>
        /// Log a message at the fatal level.
        /// </summary>
        /// <param name="message"></param>
        public void Fatal(object message) {
            System.Diagnostics.Trace.TraceError(message.ToString());
        }

        /// <summary>
        /// Log a message and an exception at the fatal level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Fatal(object message, Exception exception) {
            System.Diagnostics.Trace.TraceError("{0} {1}", message, exception.ToString());
        }

        /// <summary>
        /// Log a message using a format string at the fatal level.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void FatalFormat(string format, params object[] args) {
            System.Diagnostics.Trace.TraceError(format, args);
        }

        /// <summary>
        /// Log a message at the debug level.
        /// </summary>
        /// <param name="message"></param>
        public void Debug(object message) {
            System.Diagnostics.Trace.WriteLine(message);
        }

        /// <summary>
        /// Log a message and exception at the debug level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Debug(object message, Exception exception) {
            System.Diagnostics.Trace.WriteLine(string.Format("{0} {1}", message, exception));
        }

        /// <summary>
        /// Log a message using a format string at the debug level.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void DebugFormat(string format, params object[] args) {
            System.Diagnostics.Trace.WriteLine(string.Format(format, args));
        }

        /// <summary>
        /// Log a message at the info level.
        /// </summary>
        /// <param name="message"></param>
        public void Info(object message) {
            System.Diagnostics.Trace.TraceInformation(message.ToString());
        }

        /// <summary>
        /// Log a message and exception at the info level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Info(object message, Exception exception) {
            System.Diagnostics.Trace.TraceInformation(string.Format("{0} {1}", message, exception));
        }

        /// <summary>
        /// Log a message using a format string at the info level.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void InfoFormat(string format, params object[] args) {
            System.Diagnostics.Trace.TraceInformation(string.Format(format, args));
        }

        /// <summary>
        /// Log a message at the warning level.
        /// </summary>
        /// <param name="message"></param>
        public void Warn(object message) {
            System.Diagnostics.Trace.TraceWarning(message.ToString());
        }

        /// <summary>
        /// Log a message and exception at the warning level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Warn(object message, Exception exception) {
            System.Diagnostics.Trace.TraceWarning("{0} {1}", message, exception);
        }

        /// <summary>
        /// Log a message using a format string at the warning level.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void WarnFormat(string format, params object[] args) {
            System.Diagnostics.Trace.TraceWarning(format, args);
        }
    }
}
