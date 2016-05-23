using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SAC_.WebUI2.Startup))]
namespace SAC_.WebUI2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
