using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sebrae.SAC.WebUI2.Models;
using Sebrae.SAC.WebUI2.Infraestrutura.Provider.Abstract;
using Sebrae.SAC.WebUI2.CAS_Service_Teste;
using System.Configuration;
using System.Security.Principal;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace Sebrae.SAC.WebUI2.Infraestrutura.Provider.Concrete
{
    public class Autenticacao : IAutenticacaoProvider
    {
        CAS_Service_Teste.SecuritySoapClient servico = new SecuritySoapClient();
        public bool Autenticar(AutenticacaoModel autenticacaoModel, out string msgErro)
        {
            try
            {
                bool erro = false;
                String MsgErro = String.Empty;
                ValidationSoapHeader validation = new ValidationSoapHeader();
                validation.Login = System.Configuration.ConfigurationManager.AppSettings["CAS_SEBRAE_LOGIN"];
                validation.Password = System.Configuration.ConfigurationManager.AppSettings["CAS_SEBRAE_SENHA"];
                var retorno = servico.Autenticar(validation, autenticacaoModel.Login.Replace(@"SP-SEBRAE\",""), autenticacaoModel.Senha);
                switch (retorno.Resultado)
                {
                    case CAS_Service_Teste.TiposResultadoExecucao.ExecucaoCompleta:
                        retorno = servico.GetUserInfo(validation, Convert.ToString(retorno.Retorno), System.Configuration.ConfigurationManager.AppSettings["SISTEMA_AUTENTICADO_CAES"]);
                        if (retorno.Resultado == CAS_Service_Teste.TiposResultadoExecucao.ExecucaoCompleta)
                        {
                            var DadosUsuario = (CAS_Service_Teste.XmlUsuarioInfo)retorno.Retorno;
                            AutenticacaoModel autenticaco = new AutenticacaoModel();
                            foreach (String grupo in DadosUsuario.GruposUsuario)
                            {
                                autenticaco.GruposUsuario.Add(grupo);
                            }
                            foreach (var LocalTrabalho in DadosUsuario.LocaisUsuario)
                            {
                                autenticaco.LocaisUsuario.Add(new LocalUsuario
                                {
                                    Descricao = LocalTrabalho.Descricao,
                                    IdLocal = LocalTrabalho.IdLocal,
                                    IdLocalTipo = LocalTrabalho.IdLocalTipo
                                });
                            }
                            autenticaco.Login = autenticacaoModel.Login.Replace(@"SP-SEBRAE\", "");
                            autenticaco.Codigo = DadosUsuario.Codigo;
                            autenticaco.CPF = DadosUsuario.CPF;
                            autenticaco.Email = DadosUsuario.Email;
                            autenticaco.IdPessoa = DadosUsuario.IdPessoa;
                            autenticaco.IdSituacao = DadosUsuario.IdSituacao;
                            autenticaco.IdUsuario = DadosUsuario.IdUsuario;
                            autenticaco.LocalTrabalho = DadosUsuario.LocalTrabalho;
                            autenticaco.Situacao = DadosUsuario.Situacao;
                            autenticaco.Tipo = DadosUsuario.Tipo;
                            HttpContext.Current.Session["UsuarioAutenticado"] = autenticaco;
                            erro = false;
                            MsgErro = String.Empty;
                        }
                        break;
                    default:
                        erro = true;
                        MsgErro = retorno.Mensagem;
                        break;
                }
                msgErro = MsgErro;
                return erro;
            }
            catch (Exception ex)
            {
                msgErro = ex.Message.ToString();
                return true;
            }
        }

        /// <summary>
        /// Desautenticar usuario Logado
        /// </summary>
        public void Desautenticar()
        {
            HttpContext.Current.Session.Remove("UsuarioAutenticado");
        }

        /// <summary>
        /// Verifica se ja possui uma autenticação
        /// </summary>
        public bool Autenticado
        {
            get
            {
                return
                    HttpContext.Current.Session["UsuarioAutenticado"] != null
                    &&
                    HttpContext.Current.Session["UsuarioAutenticado"].GetType() == typeof(AutenticacaoModel);
            }
        }

        public AutenticacaoModel UsuarioAutenticado
        {
            get
            {
                if (Autenticado)
                {
                    return (AutenticacaoModel)HttpContext.Current.Session["UsuarioAutenticado"];
                }
                else
                {
                    return null;
                }
            }
        }


        public bool RetornarEstrutura(string token, string chave)
        {
            ValidationSoapHeader validation = new ValidationSoapHeader();
            validation.Login = System.Configuration.ConfigurationManager.AppSettings["CAS_SEBRAE_LOGIN"];
            validation.Password = System.Configuration.ConfigurationManager.AppSettings["CAS_SEBRAE_SENHA"];
            var permissoes = (List<XmlPermissaoInfo>)servico.RetornarEstrutura(validation, token, chave).Retorno;
            if (permissoes.Count == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Verifica o Usuario que esta logado no AD para autenticação
        /// </summary>
        /// <returns></returns>
        public AutenticacaoModel ObterDadosUsuarioLogado()
        {
            try
            {
                return new AutenticacaoModel
                {
                    Login = System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                    Erro = false
                };
            }
            catch (Exception ex)
            {
                return new AutenticacaoModel
                {
                    MsgErro = ex.Message,
                    Erro = true
                };
            }
        }
    }
}