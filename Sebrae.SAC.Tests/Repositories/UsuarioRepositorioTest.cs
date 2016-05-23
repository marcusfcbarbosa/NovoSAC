using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using SAC_.Domain.Abstract;
using SAC_.Domain.Concrete;
using SAC_.Domain.Entities;


[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace SAC_.Tests.Repositories
{
    [TestClass]
    public class UsuarioRepositorioTest
    {

        IUsuarioRepositorio usuarioRepositorio;
        Usuario usuario1, usuario2, usuario3;

        private static readonly log4net.ILog log = LogHelper.Getlogger();

        [TestInitialize]
        public void InicializaTeste()
        {
            usuarioRepositorio = new EFUsuarioRepositorio();
        }
        
        [TestMethod]
        public void AutenticaLoginCadastradadoNaBaseCAS()
        {
            var retorno = usuarioRepositorio.AutenticaUsuario("marcusfcb", "123");
            Assert.AreNotEqual(null, retorno);
        }
    }
}