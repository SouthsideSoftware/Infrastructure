using Infrastructure.Logging.NLog;
using Machine.Specifications;

namespace Infrastructure.Container.CastleWindsor.Tests {
    public class AssemblyContext : IAssemblyContext, ICleanupAfterEveryContextInAssembly {
        #region IAssemblyContext Members

        public void OnAssemblyStart() {
            Infrastructure.Core.Configuration.Settings.LogWithNLog().Configure();
        }

        public void OnAssemblyComplete() {}

        #endregion

        public void AfterContextCleanup() {
        }
    }
}