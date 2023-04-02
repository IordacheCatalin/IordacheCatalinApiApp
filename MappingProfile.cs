using AutoMapper;
using FirstApiApp.DTOs;
using FirstApiApp.DTOs.CreateUpdateObjects;

namespace FirstApiApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Announcement, CreateUpdateAnnouncement>().ReverseMap();
        }

    }
}
