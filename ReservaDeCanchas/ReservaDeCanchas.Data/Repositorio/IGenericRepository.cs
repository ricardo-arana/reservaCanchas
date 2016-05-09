using System;
using System.Linq;
using System.Linq.Expressions;

namespace ReservaDeCanchas.Data.Repositorio
{
    public interface IGenericRepository<TEntidad> where TEntidad : class
    {
        IQueryable<TEntidad> GetAll();
        IQueryable<TEntidad> Find(Expression<Func<TEntidad, bool>> predicate);
        TEntidad Single(Expression<Func<TEntidad, bool>> predicate);
        TEntidad SingleOrDefault(Expression<Func<TEntidad, bool>> predicate);
        TEntidad First(Expression<Func<TEntidad, bool>> predicate);

        void Add(TEntidad entity);
        void Delete(TEntidad entity);
        void Update(TEntidad entity);
    }

}