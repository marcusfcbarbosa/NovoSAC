using Sebrae.SAC.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Collections;
using Sebrae.SAC.Domain.Entities;
using Sebrae.SAC.Domain.Entities.Dapper;
using Dapper_Objects = Sebrae.SAC.Domain.Entities.Dapper_DataObjects;


[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Sebrae.SAC.Domain.Concrete
{
    
    public class EFUsuarioRepositorio : Repository<Usuario>, IUsuarioRepositorio 
    {
        private static readonly log4net.ILog log = LogHelper.Getlogger();

        //Quando for trabalhar com Dapper, não usar Injeção de dependencia
        /// <summary>
        /// Implementa a camada de negócio associada a autentcacao de usuarios no Sistema
        /// Desenvolvimento : Marcus Fernando Correa Barbosa
        /// </summary>
        /// <param name="Login"></param>
        /// <param name="Senha"></param>
        /// <returns></returns>
        public Entities.Usuario AutenticaUsuario(string Login, string Senha)
        {
            try {

                using (var cnx = new DapperContext().Connection)
                {
                    var query = cnx.Query<Dapper_Objects.Usuario>(@"
                                            Declare @Situacao_Ativa INT,
                                            @Situacao_Inativa INT
                                            
                                            set @Situacao_Ativa = 1
                                            set @Situacao_Inativa = 2
                                            
                                            SELECT
                                                        IdUsuario 
                                                        ,IdPessoa 
                                                        ,Email 
                                                        ,Password 
                                                        ,Codigo 
                                                        ,CPF 
                                                        ,Login 
                                                        ,NomeUsuario 
                                                        ,Tipo 
                                                        ,IdLocalTrabalho
                                                        ,IdSituacao

                                            FROM   dbo.Usuario WITH(NOLOCK)
                                                             WHERE  Excluido = 0
                                                                    AND IDSITUACAO = @Situacao_Ativa 
                                                                    AND ( Rtrim(LOGIN) LIKE Cast(@LOGIN AS VARCHAR) + '___'
                                                                           OR LOGIN = @LOGIN )"
                          , new { LOGIN = Login }
                      ).FirstOrDefault();
                    if (query != null)
                    {
                        return new Usuario
                        {
                            IdUsuario = query.IdUsuario,
                            IdPessoa = query.IdPessoa,
                            Email = query.Email,
                            Codigo = query.Codigo,
                            CPF = query.CPF,
                            NomeUsuario = query.NomeUsuario,
                            Tipo = query.Tipo,
                            IdLocalTrabalho = query.IdLocalTrabalho,
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }catch(Exception ex){
                log.Error(String.Format("Sebrae.SAC.Domain.Concrete.EFUsuarioRepositorio  (AutenticaUsuario)  : {0}", ex.Message));
                throw new InvalidOperationException("Erro de Autenticação");
            }
        }
    }
}
