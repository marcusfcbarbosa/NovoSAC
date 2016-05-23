using Ninject;
using SAC_.WebUI2.Infraestrutura.Provider.Abstract;
using SAC_.WebUI2.Infraestrutura.Provider.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAC_.WebUI2.Infraestrutura
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {

        private IKernel ninjectKernel;


        public NinjectControllerFactory() {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }


        /// <summary>
        /// Para que seja possivel pegar a instancia 
        /// do nosso Controller
        /// Dessa forma a dependencia que meu controller precisar, o ninject as irá adicionar
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="controllerType"></param>
        /// <returns></returns>
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        #region "Mapeamento das dependencias"
        /// <summary>
        /// Para cada Interface sua respectiva  classe
        /// </summary>
        #endregion
        private void AddBindings() {
            ninjectKernel.Bind<IAutenticacaoProvider>().To<Autenticacao>();
        }

    }
}