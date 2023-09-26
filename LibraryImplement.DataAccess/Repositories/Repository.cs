using Microsoft.EntityFrameworkCore;
using RailwayStation.DataAccess.Database;
using RailwayStation.DataAccess.Repositories.IRepositories;
using System.Linq.Expressions;

namespace RailwayStation.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly RailwayStationContext _db;
        internal DbSet<T> dbSet;

        public Repository(RailwayStationContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.AddAsync(entity);
        }

        public T GetByID(int id)
        {
            return dbSet.Find(id);
        }

        public List<T> GetList()
        {
            return dbSet.ToList();
        }

        public List<T> GetListByFilter(Expression<Func<T, bool>> filter)
        {
            return dbSet.Where(filter).ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
