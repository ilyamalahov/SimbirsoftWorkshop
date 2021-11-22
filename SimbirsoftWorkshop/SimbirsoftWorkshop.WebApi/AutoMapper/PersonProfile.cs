using AutoMapper;
using SimbirsoftWorkshop.WebApi.Entities;
using SimbirsoftWorkshop.WebApi.Models;

namespace SimbirsoftWorkshop.WebApi.AutoMapper
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>()
                .ForMember(p => p.Id, opt => opt.MapFrom(p => p.Id))
                .ForMember(p => p.FirstName, opt => opt.MapFrom(p => p.FirstName))
                .ForMember(p => p.LastName, opt => opt.MapFrom(p => p.LastName))
                .ForMember(p => p.MiddleName, opt => opt.MapFrom(p => p.MiddleName))
                .ForMember(p => p.Birthday, opt => opt.MapFrom(p => p.Birthday));
            
            CreateMap<PersonDto, Person>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.FirstName, opt => opt.MapFrom(p => p.FirstName))
                .ForMember(p => p.LastName, opt => opt.MapFrom(p => p.LastName))
                .ForMember(p => p.MiddleName, opt => opt.MapFrom(p => p.MiddleName))
                .ForMember(p => p.Birthday, opt => opt.MapFrom(p => p.Birthday));

            CreateMap<Person, ReceivingBookPersonDto>()
                .ForMember(rbp => rbp.Id, opt => opt.MapFrom(p => p.Id))
                .ForMember(rbp => rbp.FirstName, opt => opt.MapFrom(p => p.FirstName))
                .ForMember(rbp => rbp.LastName, opt => opt.MapFrom(p => p.LastName))
                .ForMember(rbp => rbp.MiddleName, opt => opt.MapFrom(p => p.MiddleName));
        }
    }
}
