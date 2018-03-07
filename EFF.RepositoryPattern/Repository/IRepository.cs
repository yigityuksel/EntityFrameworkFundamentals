using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EFF.RepositoryPattern.Repository
{

    //Its collection, does not contains save/update methods.
    public interface IRepository<TEntity> where TEntity : class
    {
        //Find Objects
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //Adding Objects
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        //Removing Objects.
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}