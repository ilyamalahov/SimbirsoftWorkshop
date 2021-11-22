using AutoMapper;
using SimbirsoftWorkshop.WebApi.Entities;
using SimbirsoftWorkshop.WebApi.Models;

namespace SimbirsoftWorkshop.WebApi.AutoMapper
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, PersonBookAuthorDto>()
                .ForMember(pba => pba.Id, opt => opt.MapFrom(a => a.Id))
                .ForMember(pba => pba.FirstName, opt => opt.MapFrom(a => a.FirstName))
                .ForMember(pba => pba.LastName, opt => opt.MapFrom(a => a.LastName))
                .ForMember(pba => pba.MiddleName, opt => opt.MapFrom(a => a.MiddleName));
        }
    }
}
