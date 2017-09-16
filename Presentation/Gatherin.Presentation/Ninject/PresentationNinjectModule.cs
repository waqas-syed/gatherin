using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gatherin.Presentation.Controllers;
using Ninject.Modules;

namespace Gatherin.Presentation.Ninject
{
    /// <summary>
    /// Laods the Ninejct dependencies
    /// </summary>
    public class PresentationNinjectModule : NinjectModule
    {
        /// <summary>
        /// Load the dependencies
        /// </summary>
        public override void Load()
        {
            Bind<GatheringsController>().ToSelf().InTransientScope();
        }
    }
}