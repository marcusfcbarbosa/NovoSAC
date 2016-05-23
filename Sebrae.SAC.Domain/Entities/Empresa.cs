using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAC_.Domain.Entities
{
    [Table("Empresa")]
    public class Empresa
    {
        [Key]
        public Int32 ID { get; set; }

        public String Nome { get; set; }

        public String Cnpj { get; set; }


        public String Cnae { get; set; }

        public String Telefone { get; set; }

        public Int32 NumeroFuncionarios { get; set; }


        public String Estado { get; set; }

        public String Municipio { get; set; }

        public String Bairro { get; set; }

        public String Rua { get; set; }

        public String Numero { get; set; }

        public String Cep { get; set; }

        public String Email { get; set; }

        /// <summary>
        /// Metodo para se implementar a assertiva
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var empresaParam = (Empresa)obj;
            if (this.ID == empresaParam.ID || this.Nome == empresaParam.Nome || this.Cnpj == empresaParam.Cnpj || this.Email == empresaParam.Email)
            {
                return true;
            }
            return false;
        }
    }
}
