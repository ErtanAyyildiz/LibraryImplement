using LibraryImplement.Models;
using RailwayStation.DataAccess.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryImplement.DataAccess.Abstracts
{
    public interface IBorrowedBookDal:IRepository<BorrowedBook>
    {
    }
}
