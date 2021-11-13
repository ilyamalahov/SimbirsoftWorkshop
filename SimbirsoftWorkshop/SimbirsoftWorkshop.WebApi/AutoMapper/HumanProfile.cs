using AutoMapper;
using SimbirsoftWorkshop.WebApi.Entities;
using SimbirsoftWorkshop.WebApi.Models;

namespace SimbirsoftWorkshop.WebApi.AutoMapper
{
    public class HumanProfile : Profile
    {
        public HumanProfile()
        {
            CreateMap<Human, HumanDto>().ReverseMap();
        }
    }
}
