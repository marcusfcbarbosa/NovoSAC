using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sebrae.SAC.Domain.Concrete
{
    public class Repository<TEntity> where TEntity : class, new()
    {
        protected SacContext _db = new SacContext();

        public IEnumerable<TEntity> ListarTodos
        {
            get { return _db.Set<TEntity>().ToList(); }
        }

        public IQueryable<TEntity> TodosQueryable
        {
            get { return _db.Set<TEntity>().AsQueryable(); }
        }

        public void Inserir(TEntity novo)
        {
            _db.Set<TEntity>().Add(novo);
            _db.SaveChanges();
        }

        public void Atualizar(TEntity item)
        {
            _db.Set<TEntity>().Attach(item);
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Excluir(int Id)
        {
            var item = this.Retorna(Id);
            this.Excluir(item);
        }

        public void Excluir(TEntity item)
        {
            if (item == null)
                return;

            _db.Set<TEntity>().Remove(item);
            _db.SaveChanges();
        }

        public TEntity Retorna(int Id)
        {
            return _db.Set<TEntity>().Find(Id);
        }

        //public TEntity Retorna(params object[] keyValues)
        //{
        //    return _db.Set<TEntity>().Find(keyValues);
        //}
    }
}