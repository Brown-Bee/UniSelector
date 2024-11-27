using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UniSelector.DataAccess.Data;
using UniSelector.DataAccess.Repository.IRepository;

namespace UniSelector.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext? _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool isTracked = true)
        {
            IQueryable<T> query;
            if (isTracked) query = dbSet;
            else query = dbSet.AsNoTracking();
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var IncludeProp in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(IncludeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter is not null)
            {
                query = dbSet.Where(filter);

            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var IncludeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(IncludeProp);
                }
            }
            return query.ToList();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }



        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
