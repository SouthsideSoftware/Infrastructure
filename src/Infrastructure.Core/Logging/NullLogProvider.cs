using System;

namespace Infrastructure.Core.Logging
{
    /// <summary>
    /// Implementation of ILogProvider that returns a do-nothing
    /// logger.
    /// </summary>
    public class NullLogProvider : ILogProvider {
        /// <summary>
        /// Gets the ILog implementation for the type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ILog GetLogger(Type type) {
            return new NullLog(type.FullName);
        }

        /// <summary>
        /// Gets the ILog implementation for the key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ILog GetLogger(string key) {
            return new NullLog(key);
        }
    }
}
