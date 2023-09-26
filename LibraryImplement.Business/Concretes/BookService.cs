using LibraryImplement.Business.Abstracts;
using LibraryImplement.Models;
using RailwayStation.DataAccess.Repositories.IRepositories;

namespace LibraryImplement.Business.Concretes
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Book entity)
        {
            _unitOfWork.Book.Add(entity);
            _unitOfWork.Save();
        }

        public ICollection<Book> GetAll()
        {
            return _unitOfWork.Book.GetAll();
        }

        public Book? GetByID(int id)
        {
            return _unitOfWork.Book.GetByID(id);
        }

        public List<Book> GetList()
        {
            return _unitOfWork.Book.GetList();
        }

        public void Remove(Book entity)
        {
            _unitOfWork.Book.Remove(entity);
            _unitOfWork.Save();
        }

        public void Update(Book entity)
        {
            _unitOfWork.Book.Update(entity);
            _unitOfWork.Save();
        }
    }
}
