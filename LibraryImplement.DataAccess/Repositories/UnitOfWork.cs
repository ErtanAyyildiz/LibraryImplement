using LibraryImplement.DataAccess.Database;
using RailwayStation.DataAccess.Repositories.IRepositories;

namespace RailwayStation.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDBContext _db;

        public UnitOfWork(LibraryDBContext db)
        {
            _db = db;
            
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
