namespace LibraryImplement.Models.DTOs.Books
{
    public class BookListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ImagePath { get; set; }
        public bool IsInLibrary { get; set; }

        public ICollection<BorrowedBook> BorrowedBooks { get; set; }

    }
}
