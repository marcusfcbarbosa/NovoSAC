using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sebrae.SAC.Domain.Entities;

namespace Sebrae.SAC.Domain.Abstract
{
    public interface IUsuarioRepositorio
    {
         Usuario AutenticaUsuario(String Login, String Senha);
    }
}
