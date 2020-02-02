using Autofac;
using AutoMapper;
using System.Collections.Generic;
using UniverseKino.Services;
using UniverseKino.Services.Dto;
using UniverseKino.WEB.Models;

namespace UniverseKino.WEB
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegistrationRequestView, RegistrationRequestDTO>();

            CreateMap<LoginRequestView, LoginRequestDTO>();

            CreateMap<SeatModel, SeatDTO>();
            CreateMap<SeatDTO, SeatModel>();

            CreateMap<SessionModel, SessionDTO>();
            CreateMap<SessionDTO, SessionModel>();
        }


    }

    public static class MappExtension
    {
        // public static void RegisterMapper(this ContainerBuilder builder, MappingProfile profile, ServiceMappingProfile servProfile)
        // {

        // }
    }
}
