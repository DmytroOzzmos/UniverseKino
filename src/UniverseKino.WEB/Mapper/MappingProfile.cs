using Autofac;
using AutoMapper;
using UniverseKino.Services;
using UniverseKino.WEB.Models;

namespace UniverseKino.WEB
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegistrationRequestView, RegistrationRequestDTO>();
            // .ForMember(x => x.Email, opt => opt.MapFrom(x1 => x1.UserName));
            CreateMap<LoginRequestView, LoginRequestDTO>();
            //CreateMap<RegistrationRequestView, RegistrationRequestDTO>();
            //CreateMap<CreateLotDTO, Lot>();
        }


    }

    public static class MappExtension
    {
        // public static void RegisterMapper(this ContainerBuilder builder, MappingProfile profile, ServiceMappingProfile servProfile)
        // {

        // }
    }
}
