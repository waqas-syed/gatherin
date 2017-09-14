using Gatherin.Persistence.DatabasePipeline;
using Gatherin.Persistence.Repositories;
using Ninject.Modules;

namespace Gatherin.Persistence.Ninject
{
    /// <summary>
    /// Declares the dependencies for the Persistence Module
    /// </summary>
    public class PersistenceNinjectModule : NinjectModule
    {
        /// <summary>
        /// Load the dependencies
        /// </summary>
        public override void Load()
        {
            Bind<IMongoConfiguration>().To<MongoConfiguration>().InSingletonScope();
            Bind<ICarRepository>().To<CarsRepository>().InTransientScope();
        }
    }
}
