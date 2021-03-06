﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAC_.WebUI2.Models;
using System.Web.SessionState;
using SAC_.WebUI2.Models;
using SAC_.WebUI2.Infraestrutura.Provider.Abstract;
using System.Web.Security;


namespace SAC_.WebUI2.Controllers
{
    public class AcessoController : Controller
    {

        private IAutenticacaoProvider autenticacaoProvider;

        public AcessoController(IAutenticacaoProvider AutenticacaoProviderParam)
        {
            autenticacaoProvider = AutenticacaoProviderParam;
        }
        
        //
        // GET: /Login/
        public ActionResult Login()
        {
            ViewBag.Title = "ATENDIMENTO";
            return View();
        }

        [HttpPost]
        public ActionResult Login(AutenticacaoModel autenticacaoModel, String ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                string msgErro = String.Empty;
                if (autenticacaoProvider.Autenticar(autenticacaoModel, out msgErro))
                {
                    //if (String.IsNullOrEmpty(msgErro)) {
                        FormsAuthentication.SetAuthCookie(autenticacaoModel.Login, false);
                        return Redirect(ReturnUrl ?? Url.Action("Default", "Home"));
                    //}
                }
                else {
                    TempData["Mensagem"] = "Falha de Autenticação";
                    return RedirectToAction("Login");
                }
            }
            return RedirectToAction("Login");
        }


        public ActionResult LoginPeloAd()
        {
            String ReturnUrl = String.Empty;
            string msgErro = String.Empty;
            if (!autenticacaoProvider.Autenticar(new AutenticacaoModel { Login = autenticacaoProvider.ObterDadosUsuarioLogado().Login }, out msgErro))
            {
                FormsAuthentication.SetAuthCookie(autenticacaoProvider.ObterDadosUsuarioLogado().Login, false);
                return Redirect(Url.Action("Default", "Home"));
            }
            return RedirectToAction("Login");
        }
       
        public ActionResult Sair()
        {
            autenticacaoProvider.Desautenticar();
            return RedirectToAction("Login");
        }
	}
}