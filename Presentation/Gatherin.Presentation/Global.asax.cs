using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Gatherin.Persistence.Ninject;
using Gatherin.Presentation.Mappings;
using Gatherin.Presentation.Ninject;
using Gatherin.Services.Ninject;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Mvc;

namespace Gatherin.Presentation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            EnsureAuthIndexes.Exist();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            LiftOff.Run();
        }

        /*protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load<PersistenceNinjectModule>();
            kernel.Load<ServicesNinjectModule>();
            kernel.Load<PresentationNinjectModule>();

            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            return kernel;
        }*/
    }
}
