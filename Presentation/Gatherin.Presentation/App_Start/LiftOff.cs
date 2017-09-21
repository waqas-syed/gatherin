using System.ComponentModel;
using System.Web.Mvc;
using Gatherin.Persistence.Ninject;
using Gatherin.Presentation.Ninject;
using Gatherin.Services.Ninject;
using Ninject;

namespace Gatherin.Presentation
{
    /// <summary>
    /// Fires off configurations at the start up of the application
    /// </summary>
    public class LiftOff
    {
        /// <summary>
        /// Run the Configuratio for Di and AtuoMapper
        /// </summary>
        public static void Run()
        {   
            InitializeNinject();
        }

        /// <summary>
        /// Initialize Ninject dependencies
        /// </summary>
        private static void InitializeNinject()
        {
            var kernel = new StandardKernel();
            kernel.Load<PersistenceNinjectModule>();
            kernel.Load<ServicesNinjectModule>();
            kernel.Load<PresentationNinjectModule>();
        }
    }
}