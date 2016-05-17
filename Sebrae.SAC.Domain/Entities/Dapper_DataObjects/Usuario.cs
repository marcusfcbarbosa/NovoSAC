using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Sebrae.SAC.Domain.Entities.Dapper_DataObjects
{
    [Table("dbo.Usuario")]
    public class Usuario
    {
        [Key]
        public Int32 IdUsuario { get; set; }

        public Int32 IdPessoa { get; set; }

        public String Email { get; set; }

        public String Password { get; set; }

        public Int32 Codigo { get; set; }

        public String CPF { get; set; }

        public String Login { get; set; }

        public String NomeUsuario { get; set; }

        public char Tipo { get; set; }

        public Int32 IdLocalTrabalho { get; set; }

        /// <summary>
        /// IdSituacao da referencia a tabela Situacao
        /// 1 = Ativo
        /// 2 = Inativo
        /// </summary>
        public Int32 IdSituacao { get; set; }
    }
}
