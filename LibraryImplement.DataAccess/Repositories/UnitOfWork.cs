using LibraryImplement.DataAccess.Abstracts;
using LibraryImplement.DataAccess.Database;
using LibraryImplement.DataAccess.MsEntityFrameworks;
using RailwayStation.DataAccess.Repositories.IRepositories;

namespace RailwayStation.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDBContext _db;

        public UnitOfWork(LibraryDBContext db)
        {
            _db = db;
            Book = new BookDal(_db);
            BorrowedBook = new BorrowedBookDal(_db);
        }

        public IBookDal Book { get; private set; }
        public IBorrowedBookDal BorrowedBook { get; private set; }

    public void Save()
        {
            _db.SaveChanges();
        }
    }
}
