using Sebrae.SAC.Domain.Abstract;
using Sebrae.SAC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Sebrae.SAC.Services
{
    public class EmpresaService : IEmpresaService
    {
        //private IEmpresaRepository empresaRepositorio;

        //public EmpresaService(IEmpresaRepository empRepositorio)
        //{
        //    empresaRepositorio = empRepositorio;
        //}

        //public Empresa RetornaEmpresa(string idEmpresa)
        //{
        //    var e = empresaRepositorio.Retorna(Convert.ToInt32(idEmpresa));
        //    return e;
        //}

        //public List<Empresa> RetornaEmpresas()
        //{
        //    return empresaRepositorio.ListarTodos.ToList();
        //}
    }
}