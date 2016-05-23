using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAC_.Domain.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> ListarTodos { get; }
        IQueryable<TEntity> TodosQueryable { get; }

        void Inserir(TEntity novo);
        void Atualizar(TEntity item);
        void Excluir(TEntity item);
        void Excluir(int Id);
        TEntity Retorna(int Id);
    }
}