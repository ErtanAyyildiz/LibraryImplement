using LibraryImplement.DataAccess.Abstracts;
using LibraryImplement.DataAccess.Database;
using LibraryImplement.Models;
using RailwayStation.DataAccess.Repositories;

namespace LibraryImplement.DataAccess.MsEntityFrameworks
{
    public class BorrowedBookDal : Repository<BorrowedBook>, IBorrowedBookDal
    {
        private readonly LibraryDBContext _db;
        public BorrowedBookDal(LibraryDBContext db) : base(db)
        {
            _db=db;
        }
    }
}
