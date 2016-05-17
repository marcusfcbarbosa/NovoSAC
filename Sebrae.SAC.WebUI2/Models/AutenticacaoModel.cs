using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Sebrae.SAC.WebUI2.Models
{
    public class AutenticacaoModel
    {
        public AutenticacaoModel() {
            GruposUsuario = new List<String>();
            LocaisUsuario = new List<LocalUsuario>();
        }

        [Required(ErrorMessage = "Login obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Senha obrigatório")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public Int32? Codigo { get; set; }
        
        public String CPF { get; set; }

        public String Email { get; set; }


        public IList<String> GruposUsuario { get; set; }

        public Int32? IdLocalTrabalho { get; set; }

        public Int32? IdPessoa { get; set; }

        public String IdSituacao { get; set; }

        public Int32? IdUsuario { get; set; }


        public String LocalTrabalho { get; set; }

        public String Situacao { get; set; }

        public String Tipo { get; set; }


        public IList<LocalUsuario> LocaisUsuario { get; set; }


        public bool Erro { get; set; }

        public String MsgErro { get; set; }
    }

    public class LocalUsuario
    {


        public String Descricao { get; set; }

        public Int32? IdLocal { get; set; }

        public Int32? IdLocalTipo { get; set; }

    }
}