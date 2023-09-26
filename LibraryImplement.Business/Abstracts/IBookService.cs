using LibraryImplement.Models;

namespace LibraryImplement.Business.Abstracts
{
    public interface IBookService : IGenericService<Book>
    {
        public ICollection<Book> GetAll();

    }
}
