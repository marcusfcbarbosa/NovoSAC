using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Dapper;


namespace Sebrae.SAC.Domain.Entities.Dapper
{
    public class DapperContext : IDisposable
    {
        public IDbConnection Connection { get; set; }

        public DapperContext()
        {
            try
            {
                OpenConnection();
            }
            catch (NullReferenceException ex) { throw new NullReferenceException("Não foi encontrada nenhuma configuração de conexão para esta aplicação", ex); }
            catch (Exception ex) { throw ex; }
        }

        private void OpenConnection()
        {

            if (Connection == null || Connection.State == ConnectionState.Closed || Connection.State == ConnectionState.Broken)
            {
                Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoSAC"].ConnectionString);
                Connection.Open();
            }
        }
        public virtual void Execute(String sqlQuery, object param)
        {
            OpenConnection();

            Connection.Execute(sqlQuery, param);
        }

        #region IDisposable Members

        // IDisposable implementation

        private bool disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Connection.Dispose();
                }
                disposed = true;
            }

        }

        // Destructor
        ~DapperContext()
        {
            Dispose(false);
        }

        #endregion
    }
}
