using LibraryImplement.DataAccess.Abstracts;
using LibraryImplement.DataAccess.Database;
using LibraryImplement.Models;
using Microsoft.EntityFrameworkCore;
using RailwayStation.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryImplement.DataAccess.MsEntityFrameworks
{
    public class BookDal : Repository<Book>, IBookDal
    {
        private readonly LibraryDBContext _db;
        public BookDal(LibraryDBContext db) : base(db)
        {
            _db = db;
        }

        public ICollection<Book> GetAll()
        {
            if (_db.Books.Any())
            {
                return _db.Books.Include(b => b.BorrowedBooks).ToList();
            }
            else
            {
                return new List<Book>();
            }
        }
    }
}
