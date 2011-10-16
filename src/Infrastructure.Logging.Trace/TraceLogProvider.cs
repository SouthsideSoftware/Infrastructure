using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Core.Logging;

namespace Infrastructure.Logging.Trace {
    /// <summary>
    /// Log provider that works with standard .NET trace logging.  Set trace switch TraceLogLevel to control logging.
    /// </summary>
    public class TraceLogProvider : ILogProvider {
        TraceLog log = new TraceLog();
        /// <summary>
        /// Gets the ILog implementation for the type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ILog GetLogger(Type type) {
            return log;
        }

        /// <summary>
        /// Gets the ILog implementation for the key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ILog GetLogger(string key) {
            return log;
        }
    }
}
