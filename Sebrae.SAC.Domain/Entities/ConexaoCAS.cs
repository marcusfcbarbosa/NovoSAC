using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace SAC_.Domain.Entities
{
    class ConexaoCAS
    {
        public static string DatabaseConnection = ConfigurationManager.ConnectionStrings["CAS_USUARIO_GRUPOS"].ConnectionString; 
    }
}
