using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sebrae.SAC.WebUI2.Startup))]
namespace Sebrae.SAC.WebUI2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
