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
            // .ForMember(x => x.Email, opt => opt.MapFrom(x1 => x1.UserName));
            CreateMap<LoginRequestView, LoginRequestDTO>();
            //CreateMap<RegistrationRequestView, RegistrationRequestDTO>();
            //CreateMap<CreateLotDTO, Lot>();

            CreateMap<SeatModel, SeatDTO>();
            CreateMap<SeatDTO, SeatModel>();

            CreateMap<SessionModel, SessionDTO>();
                //.ForMember(a => a.NameMovie, opt => opt.MapFrom(b => b.NameMovie));
            CreateMap<SessionDTO, SessionModel>();
            CreateMap<List<SessionModel>, List<SessionDTO>>();
            CreateMap<List<SessionDTO>, List<SessionModel>>();
        }


    }

    public static class MappExtension
    {
        // public static void RegisterMapper(this ContainerBuilder builder, MappingProfile profile, ServiceMappingProfile servProfile)
        // {

        // }
    }
}
