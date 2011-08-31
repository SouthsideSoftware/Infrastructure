using System;
using System.Reflection;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Container;
using Infrastructure.Core.Logging;
using Infrastructure.Core.Resources;

namespace Infrastructure.Core {
    /// <summary>
    /// Configuration of commons
    /// </summary>
    public class Configuration {
        ILog logger;
        static readonly Configuration settings = new Configuration();

        IServiceLocator serviceLocator;

        Configuration() {
            LogProvider = new NullLogProvider();
        }

        /// <summary>
        /// Gets the settings instance.
        /// </summary>
        public static Configuration Settings {
            get {
                return settings;
            }
        }

        /// <summary>
        /// Use this in code so that the logger is not used until after
        /// the log provider is initialized by configuration.  Otherwise, you will always get 
        /// the null logger provider.
        /// </summary>
        ILog Logger {
            get {
                if (logger == null) {
                    logger = LogManager.GetLogger(typeof(Configuration));
                }
                return logger;
            }
        }

        /// <summary>
        /// Gets the service locator configured.
        /// </summary>
        public IServiceLocator ServiceLocator {
            get {
                return serviceLocator;
            }
        }

        /// <summary>
        /// Gets the configured log provider.
        /// </summary>
        internal ILogProvider LogProvider {
            get;
            private set;
        }

        /// <summary>
        /// Assigns the service locator builder.
        /// </summary>
        public void BuildWith(IServiceLocator serviceLocator) {
            ParameterCheck.ParameterRequired(serviceLocator, "serviceLocator");

            this.serviceLocator = serviceLocator;
        }

        /// <summary>
        /// Assigns the log provider.
        /// </summary>
        /// <param name="logProvider"></param>
        public void LogWith(ILogProvider logProvider) {
            ParameterCheck.ParameterRequired(logProvider, "logProvider");

            LogProvider = logProvider;
        }

        /// <summary>
        /// Apply the configuration.
        /// </summary>
        public void Configure() {
            LogInitializer.Initialize();
            RunComponentInstallers();
        }

        /// <summary>
        /// Clears the service locator configuration and re-runs the component installers.
        /// </summary>
        public void ResetServiceLocator()
        {
            serviceLocator.Clear();
            RunComponentInstallers();
        }

        internal void RunComponentInstallers() {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                try {
                    if (!assembly.FullName.Contains("ReSharper")) {
                        foreach (Type t in assembly.GetTypes()) {
                            if (typeof(IComponentInstaller).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract &&
                                t.IsPublic) {
                                (Activator.CreateInstance(t) as IComponentInstaller).Install(serviceLocator);
                            }
                        }
                    }
                }
                catch (ReflectionTypeLoadException tle) {
                    Logger.ErrorFormat(
                        Messages.Configuration_RunComponentInstallers_CouldNotLoadTypesFromAssembly,
                        assembly.FullName, tle);
                    foreach (Exception e in tle.LoaderExceptions) {
                        Logger.ErrorFormat(Messages.Configuration_RunComponentInstallers_LoaderError, e.Message);
                    }
                }
            }
        }
    }
}