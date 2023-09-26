using LibraryImplement.Business.Abstracts;
using LibraryImplement.Models;
using RailwayStation.DataAccess.Repositories.IRepositories;

namespace LibraryImplement.Business.Concretes
{
    public class BorrowedBookService : IBorrowedBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BorrowedBookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(BorrowedBook entity)
        {
            _unitOfWork.BorrowedBook.Add(entity);
            _unitOfWork.Save();
        }

        public BorrowedBook? GetByID(int id)
        {
            return _unitOfWork.BorrowedBook.GetByID(id);
        }

        public List<BorrowedBook> GetList()
        {
            return _unitOfWork.BorrowedBook.GetList();
        }

        public void Remove(BorrowedBook entity)
        {
            _unitOfWork.BorrowedBook.Remove(entity);
            _unitOfWork.Save();
        }

        public void Update(BorrowedBook entity)
        {
            _unitOfWork.BorrowedBook.Update(entity);
            _unitOfWork.Save();
        }
    }
}
