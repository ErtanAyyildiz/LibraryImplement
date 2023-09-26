using LibraryImplement.DataAccess.Abstracts;

namespace RailwayStation.DataAccess.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        IBookDal Book { get; }
        IBorrowedBookDal BorrowedBook { get; }
        void Save();    
    }
}
