using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SJ.One_Core.Data.Repositories
{
    public class BaseRepository<T> : IDisposable, IRepository<T>
        where T : class
    {
        protected SJOneContext Context { get; }
        private readonly DbSet<T> dbset;

        public BaseRepository() : this(new SJOneContext())
        {
        }
        public BaseRepository(SJOneContext context)
        {
            Context = context;
            dbset = Context.Set<T>();
        }
        public int Add(T entity)
        {
            dbset.Add(entity);
            return SaveChanges();
        }

        public int Add(IList<T> entities)
        {
            dbset.AddRange(entities);
            return SaveChanges();
        }

        public int Delete(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }

        public virtual List<T> GetAll() => dbset.ToList();

        public List<T> GetAll<TSortField>(Expression<Func<T, TSortField>> orderBy, bool ascending)
            => (ascending ? dbset.OrderBy(orderBy) : dbset.OrderByDescending(orderBy)).ToList();

        public T GetOne(int? id) => dbset.Find(id);

        public List<T> GetSome(Expression<Func<T, bool>> where) => dbset.Where(where).ToList();

        public int Update(T entity)
        {
            dbset.Update(entity);
            return SaveChanges();
        }

        public int Update(IList<T> entities)
        {
            dbset.UpdateRange(entities);
            return SaveChanges();
        }

        public List<T> ExecuteQuery(string sql) => dbset.FromSqlRaw(sql).ToList();

        public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects)
            => dbset.FromSqlRaw(sql, sqlParametersObjects).ToList();



        internal int SaveChanges()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
            catch (RetryLimitExceededException ex)
            {
                throw;
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
