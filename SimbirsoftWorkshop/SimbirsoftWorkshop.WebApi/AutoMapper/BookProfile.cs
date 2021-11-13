using AutoMapper;
using SimbirsoftWorkshop.WebApi.Entities;
using SimbirsoftWorkshop.WebApi.Models;

namespace SimbirsoftWorkshop.WebApi.AutoMapper
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
