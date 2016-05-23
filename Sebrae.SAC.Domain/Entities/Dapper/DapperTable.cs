using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Dapper;

namespace SAC_.Domain.Entities.Dapper
{
    public class DapperTable<T> : IDisposable
    {

        private readonly string _tableName;

        public DapperContext Context { get; private set; }

        public DapperTable(string tableName, DapperContext context)
        {
            _tableName = tableName;
            Context = context;
        }
        public DapperTable(string tableName)
            : this(tableName, null)
        {
            Context = new DapperContext();
        }

        public virtual T FindBy(String columnName, object keyValue)
        {
            T item = default(T);

            using (var cn = Context.Connection)
            {
                item = cn.Query<T>(String.Format("SELECT * FROM {0} WHERE {1}=@value", _tableName, columnName), new { value = keyValue }).FirstOrDefault();
            }
            return item;
        }

        public virtual T Query(String sqlQuery, String columnName, object keyValue)
        {
            T item = default(T);

            using (var cn = Context.Connection)
            {
                item = cn.Query<T>(String.Format("{0} WHERE {1}=@value", sqlQuery, columnName), new { value = keyValue }).FirstOrDefault();
            }

            return item;
        }

        public virtual List<T> Query(String sqlQuery, object param)
        {
            List<T> items = default(List<T>);

            using (var cn = Context.Connection)
            {
                items = cn.Query<T>(sqlQuery, param).ToList();
            }

            return items;
        }

        public virtual IEnumerable<T> Query(String sqlQuery, Boolean param)
        {
            IEnumerable<T> items = default(IEnumerable<T>);

            using (var cn = Context.Connection)
            {
                items = cn.Query<T>(sqlQuery, param).ToList();
            }
            return items;
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
                    Context.Connection.Dispose();
                }
                disposed = true;
            }

        }

        // Destructor
        ~DapperTable()
        {
            Dispose(false);
        }

        #endregion
    }
}
