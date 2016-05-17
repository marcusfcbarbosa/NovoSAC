using Autofac;
using Sebrae.SAC.Domain.Abstract;
using Sebrae.SAC.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sebrae.SAC.Services.Injection
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