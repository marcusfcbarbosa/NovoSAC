using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAC_.Domain.Entities;

namespace SAC_.Domain.Abstract
{
    public interface IUsuarioRepositorio
    {
         Usuario AutenticaUsuario(String Login, String Senha);
    }
}
