using AutoMapper;
using SimbirsoftWorkshop.WebApi.Entities;
using SimbirsoftWorkshop.WebApi.Models;

namespace SimbirsoftWorkshop.WebApi.AutoMapper
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, PersonBookGenreDto>()
                .ForMember(pbg => pbg.Id, opt => opt.MapFrom(g => g.Id))
                .ForMember(pbg => pbg.Name, opt => opt.MapFrom(g => g.Name));
        }
    }
}
