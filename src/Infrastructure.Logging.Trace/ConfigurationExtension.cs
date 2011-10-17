using Infrastructure.Core;
using Infrastructure.Core.CodeContracts;

namespace Infrastructure.Logging.Trace
{
    /// <summary>
    /// Extensions for working with configuration.
    /// </summary>
    public static class ConfigurationExtension
    {
        /// <summary>
        /// Log using Trace
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static Configuration LogWithTrace(this Configuration configuration)
        {
            ParameterCheck.ParameterRequired(configuration, "configuration");

            configuration.LogWith(new TraceLogProvider());
            return configuration;
        }
    }
}
