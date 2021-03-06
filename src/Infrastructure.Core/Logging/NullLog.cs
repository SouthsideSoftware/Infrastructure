﻿using System;
using Infrastructure.Core.CodeContracts;

namespace Infrastructure.Core.Logging {
    /// <summary>
    /// ILog implementation that will log to nothing unless 
    /// the global configuration changes to a specific logger in
    /// which case the specific logger will be used.
    /// </summary>
    /// <remarks>The check of the global configuration is necessary
    /// to work-around case of library consumers that initalize 
    /// static ILog instances using static initializers.  The
    /// problem is that static initializers can be called at any time
    /// unless there is a static constructor, which means the ILog
    /// can be initialized before configuration takes place.</remarks>
    public class NullLog : ILog {
        static readonly ILog stubLogger = new StubLog();
        ILog redirectedLogProvider;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        public NullLog(string name) {
            ParameterCheck.StringRequiredAndNotWhitespace(name, "name");

            Name = name;
        }

        /// <summary>
        /// This getter deals with the case where someone initialized a static logger
        /// using a static initializer, which caused it to be unexpectedly initialized
        /// to the null logger before configuration was completed.  This getter checks
        /// to see if configuration has changed.  If it has, it grabs the logger from 
        /// the newly configured log provider so logging works as the user expects.
        /// </summary>
        ILog RedirectedLogProvider {
            get {
                if (redirectedLogProvider != null) {
                    return redirectedLogProvider;
                }
                if (!(Configuration.Settings.LogProvider is NullLogProvider)) {
                    redirectedLogProvider = Configuration.Settings.LogProvider.GetLogger(Name);
                    return redirectedLogProvider;
                }

                return stubLogger;
            }
        }

        /// <summary>
        /// Gets the name of the logger.
        /// </summary>
        public string Name {
            get;
            private set;
        }

        /// <summary>
        /// Gets <see langword="true"/> if error logging is enabled.
        /// </summary>
        public bool IsErrorEnabled {
            get {
                return RedirectedLogProvider.IsErrorEnabled;
            }
        }

        /// <summary>
        /// Gets <see langword="true"/> if logging is enabled at the fatal level.
        /// </summary>
        public bool IsFatalEnabled {
            get {
                return RedirectedLogProvider.IsFatalEnabled;
            }
        }

        /// <summary>
        /// Gets <see langword="true"/> if debug level logging is enabled.
        /// </summary>
        public bool IsDebugEnabled {
            get {
                return RedirectedLogProvider.IsDebugEnabled;
            }
        }

        /// <summary>
        /// Gets <see langword="true"/> if info level logging is enabled.
        /// </summary>
        public bool IsInfoEnabled {
            get {
                return RedirectedLogProvider.IsInfoEnabled;
            }
        }

        /// <summary>
        /// Gets <see langword="true"/> if warning level logging is enabled.
        /// </summary>
        public bool IsWarnEnabled {
            get {
                return RedirectedLogProvider.IsWarnEnabled;
            }
        }

        /// <summary>
        /// Log a message at the error level.
        /// </summary>
        /// <param name="message"></param>
        public void Error(object message) {
            RedirectedLogProvider.Error(message);
        }

        /// <summary>
        /// Log a message and exception at the error level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Error(object message, Exception exception) {
            RedirectedLogProvider.Error(message, exception);
        }

        /// <summary>
        /// Log a message using a format string at the error level.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void ErrorFormat(string format, params object[] args) {
            RedirectedLogProvider.ErrorFormat(format, args);
        }

        /// <summary>
        /// Log a message at the fatal level.
        /// </summary>
        /// <param name="message"></param>
        public void Fatal(object message) {
            RedirectedLogProvider.Fatal(message);
        }

        /// <summary>
        /// Log a message and an exception at the fatal level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Fatal(object message, Exception exception) {
            RedirectedLogProvider.Fatal(message, exception);
        }

        /// <summary>
        /// Log a message using a format string at the fatal level.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void FatalFormat(string format, params object[] args) {
            RedirectedLogProvider.FatalFormat(format, args);
        }

        /// <summary>
        /// Log a message at the debug level.
        /// </summary>
        /// <param name="message"></param>
        public void Debug(object message) {
            RedirectedLogProvider.Debug(message);
        }

        /// <summary>
        /// Log a message and exception at the debug level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Debug(object message, Exception exception) {
            RedirectedLogProvider.Debug(message, exception);
        }

        /// <summary>
        /// Log a message using a format string at the debug level.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void DebugFormat(string format, params object[] args) {
            RedirectedLogProvider.DebugFormat(format, args);
        }

        /// <summary>
        /// Log a message at the info level.
        /// </summary>
        /// <param name="message"></param>
        public void Info(object message) {
            RedirectedLogProvider.Info(message);
        }

        /// <summary>
        /// Log a message and exception at the info level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Info(object message, Exception exception) {
            RedirectedLogProvider.Info(message, exception);
        }

        /// <summary>
        /// Log a message using a format string at the info level.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void InfoFormat(string format, params object[] args) {
            RedirectedLogProvider.InfoFormat(format, args);
        }

        /// <summary>
        /// Log a message at the warning level.
        /// </summary>
        /// <param name="message"></param>
        public void Warn(object message) {
            RedirectedLogProvider.Warn(message);
        }

        /// <summary>
        /// Log a message and exception at the warning level.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Warn(object message, Exception exception) {
            RedirectedLogProvider.Warn(message, exception);
        }

        /// <summary>
        /// Log a message using a format string at the warning level.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void WarnFormat(string format, params object[] args) {
            RedirectedLogProvider.WarnFormat(format, args);
        }
    }
}