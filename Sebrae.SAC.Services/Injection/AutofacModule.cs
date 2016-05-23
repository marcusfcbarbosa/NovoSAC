using Autofac;
using SAC_.Domain.Abstract;
using SAC_.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAC_.Services.Injection
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Depois Habilitar os novos serviços aqui
            //builder.RegisterType<ClienteRepository>().As<IClienteRepository>();
            //builder.RegisterType<EFEmpresaRepository>().As<IEmpresaRepository>();
        }
    }
}