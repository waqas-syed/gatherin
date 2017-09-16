using Ninject.Modules;

namespace Gatherin.Services.Ninject
{
    /// <summary>
    /// Ninejct modue that declares dependncies needed for this services layer to run
    /// </summary>
    public class ServicesNinjectModule : NinjectModule
    {
        /// <summary>
        /// Load all the said dependencies
        /// </summary>
        public override void Load()
        {
            Bind<IGatheringService>().To<GatheringService>().InTransientScope();
        }
    }
}
