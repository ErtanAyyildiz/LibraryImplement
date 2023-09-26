using AutoMapper;
using LibraryImplement.Models;
using LibraryImplement.Models.DTOs.Books;

namespace LibraryImplement.WebUI.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Book, BookListDTO>().ReverseMap();
            CreateMap<Book, BookCreateDTO>().ReverseMap();
        }
    }
}
