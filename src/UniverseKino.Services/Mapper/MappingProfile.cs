using System.Net.Mime;
using AutoMapper;
using System;
using UniverseKino.Core;
using UniverseKino.Services;
using UniverseKino.Data.Entities;
using UniverseKino.Services.Dto;

namespace UniverseKino.Services
{
    public class MappingProfile : MapperProfileConfig
    {
        public MappingProfile()
        {
            CreateMap<RegistrationRequestDTO, ApplicationUser>()
                .ForMember(x => x.Role, opt => opt.MapFrom(y => "User"));
            // .ForMember(x => x.Role, opt => opt.MapFrom(y => "User"));


            CreateMap<ApplicationUser, RegistrationRequestDTO>();
            //CreateMap<RegistrationRequestView, RegistrationRequestDTO>();
            //CreateMap<RegistrationRequestView, RegistrationRequestDTO>();
            //CreateMap<CreateLotDTO, Lot>();

            CreateMap<MovieDTO, Movie>();
            CreateMap<SeatDTO, Seat>();
            CreateMap<SessionDTO, Session>()
                .ForMember(a => a.Movie, opt => opt.MapFrom(b => b.NameMovie));
            //.ForMember(a => a.Movie.Genre, opt => opt.MapFrom(b => b.GenreMovie))
            //.ForMember(a => a.Movie.Duration, opt => opt.MapFrom(b => b.DurationMovie))
            //.ForMember(a => a.CinemaHall.Number, opt => opt.MapFrom(b => b.NumberHall))
            //.ForMember(a => a.CinemaHall.Seats, opt => opt.MapFrom(b => b.Seats));
        }
    }
}
