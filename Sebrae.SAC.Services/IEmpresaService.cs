using SAC_.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SAC_.Services
{
    [ServiceContract]
    public interface IEmpresaService
    {
        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //    ResponseFormat = WebMessageFormat.Json,
        //    RequestFormat = WebMessageFormat.Json,
        //    UriTemplate = "Empresa/{idEmpresa}")]
        //Empresa RetornaEmpresa(string idEmpresa);


        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //   ResponseFormat = WebMessageFormat.Json,
        //   RequestFormat = WebMessageFormat.Json,
        //   UriTemplate = "Empresas/")]
        //List<Empresa> RetornaEmpresas();
    }
}
