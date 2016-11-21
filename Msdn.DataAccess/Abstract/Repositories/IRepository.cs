using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Msdn.DataAccess.Abstract.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        TEntity First(Expression<Func<TEntity, bool>> filter);
        TEntity Find(Expression<Func<TEntity, bool>> filter);

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        bool Any(Expression<Func<TEntity, bool>> filter = null);
        int Count(Expression<Func<TEntity, bool>> filter = null);

        IQueryable<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> selector);
        IQueryable<TResult> Select<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector);

        IEnumerable<TEntity> GetAll();

        void ChangeEntityState(TEntity entity, EntityState state);
    }
}
