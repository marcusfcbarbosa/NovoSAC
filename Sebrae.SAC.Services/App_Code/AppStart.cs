using Autofac;
using Autofac.Integration.Wcf;
using SAC_.Services.Injection;

namespace SAC_.Services.App_Code
{
    public static class AppStart
    {
        //http://docs.autofac.org/en/latest/integration/wcf.html#was-hosting-and-non-http-activation
        public static void AppInitialize()
        {
            var builder = new ContainerBuilder();

            // Register your WCF service implementations
            
            //builder.RegisterType<EmpresaService>();

            //Register your modules
            builder.RegisterModule(new AutofacModule());

            // Set the dependency resolver
            var container = builder.Build();

            AutofacHostFactory.Container = container;
        }
    }
}