using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sebrae.SAC.WebUI2.Controllers
{
    public class CadastroController : Controller
    {
        //
        // GET: /Cadastro/
        public ActionResult PesquisaLocais()
        {
            return View();
        }

        public ActionResult PesquisaCliente()
        {
            return View();
        }


        public ActionResult PessoaFisica()
        {
            return View();
        }


        public ActionResult Locais()
        {
            return View();
        }

	}
}