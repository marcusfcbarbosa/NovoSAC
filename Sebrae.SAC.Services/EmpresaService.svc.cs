using SAC_.Domain.Abstract;
using SAC_.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SAC_.Services
{
    public class EmpresaService : IEmpresaService
    {
        private IEmpresaRepository empresaRepositorio;

        public EmpresaService(IEmpresaRepository empRepositorio)
        {
            empresaRepositorio = empRepositorio;
        }

        public Empresa RetornaEmpresa(string idEmpresa)
        {
            var e = empresaRepositorio.Retorna(Convert.ToInt32(idEmpresa));
            return e;
        }

        public List<Empresa> RetornaEmpresas()
        {
            return empresaRepositorio.ListarTodos.ToList();
        }
    }
}