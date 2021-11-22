using AutoMapper;
using SimbirsoftWorkshop.WebApi.Entities;
using SimbirsoftWorkshop.WebApi.Models;

namespace SimbirsoftWorkshop.WebApi.AutoMapper
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, PersonBookDto>()
                .ForMember(pb => pb.Id, opt => opt.MapFrom(b => b.Id))
                .ForMember(pb => pb.Name, opt => opt.MapFrom(b => b.Name));

            CreateMap<Book, ReceivingBookDto>()
                .ForMember(pb => pb.Id, opt => opt.MapFrom(b => b.Id))
                .ForMember(pb => pb.Name, opt => opt.MapFrom(b => b.Name));
        }
    }
}
