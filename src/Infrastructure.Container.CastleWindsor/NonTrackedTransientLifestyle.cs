using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Lifestyle;

namespace Infrastructure.Container.CastleWindsor
{
    /// <summary>
    /// A transient that is not tracked by the castle windsor container.
    /// </summary>
    [Serializable]
    public class NonTrackedTransientLifestyle : AbstractLifestyleManager
    {
        /// <summary>
        /// Invoked when the container gets disposed. The container will not call it multiple times in multithreaded environments.
        ///               However it may be called at the same time when some out of band release mechanism is in progress. Resolving those potential
        ///               issues is the task of implementors
        /// </summary>
        public override void Dispose() {
        }

        /// <summary>
        /// Release
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public override bool Release(object instance)
        {
            return true;
        }

   

    }
}
