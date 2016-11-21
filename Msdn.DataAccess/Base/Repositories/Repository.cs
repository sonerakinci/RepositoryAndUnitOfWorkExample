using Msdn.DataAccess.Abstract.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Msdn.DataAccess.Base.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        public Worker Worker { get; set; }
        private DbSet<TEntity> _table;

        internal DbSet<TEntity> Table
        {
            get { return _table ?? (_table = Worker.CreateDbSetInstance<TEntity>()); }
        }


        public TEntity First(Expression<Func<TEntity, bool>> filter)
        {
            return Table.First(filter);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> filter)
        {
            return Table.Find(filter);
        }
        public bool Any(Expression<Func<TEntity, bool>> filter = null)
        {
            return Table.Any(filter);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return orderBy == null ? Table.Where(filter) : orderBy(Table.Where(filter));
        }

        public IQueryable<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            return Table.Select(selector);
        }

        public IQueryable<TResult> Select<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector)
        {
            return Table.Where(filter).Select(selector);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Table.ToList();
        }

        public void ChangeEntityState(TEntity entity, EntityState state)
        {
            Worker.Context.Entry(entity).State = state;
        }

        public int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? Table.Count() : Table.Count(filter);
        }
    }
}
