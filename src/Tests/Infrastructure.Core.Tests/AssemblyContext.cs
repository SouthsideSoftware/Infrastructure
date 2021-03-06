﻿using Infrastructure.Logging.NLog;
using Machine.Specifications;

namespace Infrastructure.Core.Tests {
    public class AssemblyContext : IAssemblyContext, ICleanupAfterEveryContextInAssembly {
        static bool isInitalized;

        public void OnAssemblyStart() {
            if (!isInitalized) {
                Infrastructure.Core.Configuration.Settings.LogWithNLog().Configure();
                isInitalized = true;
            }
        }

        public void OnAssemblyComplete() {}

        public void AfterContextCleanup() {
        }
    }
}