using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryImplement.Models
{
    public class BorrowedBook
    {
        public int Id { get; set; }
        public string BorrowerName { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }

        // Relationship with Book
        public Book Book { get; set; }
        public int BookId { get; set; }

    }
}
