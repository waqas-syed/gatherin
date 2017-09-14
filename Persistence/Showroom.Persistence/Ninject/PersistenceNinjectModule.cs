using Ninject.Modules;
using Ninject.Web.Common;
using Showroom.Domain.Model;
using Showroom.Persistence.DatabasePipeline;
using Showroom.Persistence.Repositories;

namespace Showroom.Persistence.Ninject
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
            Bind<IMongoConfiguration>().To<MongoConfiguration>().InRequestScope();
            Bind<IRepository<Car>>().To<CarsRepository>().InTransientScope();
        }
    }
}
