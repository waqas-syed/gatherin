using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gatherin.Presentation.Startup))]
namespace Gatherin.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
