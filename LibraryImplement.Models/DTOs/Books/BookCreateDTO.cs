using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryImplement.Models.DTOs.Books
{
    public class BookCreateDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string? ImagePath { get; set; }
    }
}
