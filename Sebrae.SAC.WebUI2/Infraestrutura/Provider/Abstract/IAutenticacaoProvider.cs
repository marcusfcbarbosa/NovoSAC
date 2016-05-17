using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sebrae.SAC.WebUI2.Models;

namespace Sebrae.SAC.WebUI2.Infraestrutura.Provider.Abstract
{
    public interface IAutenticacaoProvider
    {
        /// <summary>
        /// Método que chama o web-Service CAS
        /// </summary>
        /// <param name="autenticacaoModel"></param>
        /// <param name="msgErro"></param>
        /// <returns></returns>
        bool Autenticar(AutenticacaoModel autenticacaoModel, out string msgErro);

        /// <summary>
        /// Remove a Sessão
        /// </summary>
        void Desautenticar();
        
        
        /// <summary>
        /// Atributo apenas recuperado
        /// </summary>
        bool Autenticado { get; }


        /// <summary>
        /// Irá retornar uma autenticação
        /// </summary>
        AutenticacaoModel UsuarioAutenticado { get; }


        AutenticacaoModel ObterDadosUsuarioLogado();

        Boolean RetornarEstrutura(String token, String chave);



    }
}
