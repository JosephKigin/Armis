using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Armis.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        //IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);  TODO: These are from the example at https://medium.com/swlh/building-a-nice-multi-layer-net-core-3-api-c68a9ef16368
        //Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate); TODO: Figure out how to use these.
        Task Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
