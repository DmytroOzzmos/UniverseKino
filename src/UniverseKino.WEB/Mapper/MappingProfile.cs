using Autofac;
using AutoMapper;
using System.Collections.Generic;
using UniverseKino.Data.Entities;
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

            CreateMap<LoginRequestView, RegistrationRequestDTO>();

            CreateMap<SeatModel, SeatDTO>();
            CreateMap<SeatDTO, SeatModel>();

            CreateMap<CreateMovieRequestModel, MovieDTO>();

            CreateMap<CreateSessionRequestModel, CreateSessionDTO>();

            //CreateMap<ReservationRequestModel, Reservation>()
            //    .ForMember(x => x.IdSession, opt => opt.MapFrom(a => a.SessionId))
            //    .ForMember(x => x.)
        }


    }

    public static class MappExtension
    {
        // public static void RegisterMapper(this ContainerBuilder builder, MappingProfile profile, ServiceMappingProfile servProfile)
        // {

        // }
    }
}
