using System.Net.Mime;
using AutoMapper;
using System;
using UniverseKino.Core;
using UniverseKino.Services;
using UniverseKino.Data.Entities;
using UniverseKino.Services.Dto;
using System.Collections.Generic;

namespace UniverseKino.Services
{
    public class ServicesMappingProfile : Profile
    {
        public ServicesMappingProfile()
        {
            CreateMap<RegistrationRequestDTO, ApplicationUser>()
                .ForMember(x => x.Role, opt => opt.MapFrom(y => "User"));
            // .ForMember(x => x.Role, opt => opt.MapFrom(y => "User"));


            CreateMap<ApplicationUser, RegistrationRequestDTO>();
            //CreateMap<RegistrationRequestView, RegistrationRequestDTO>();
            //CreateMap<RegistrationRequestView, RegistrationRequestDTO>();
            //CreateMap<CreateLotDTO, Lot>();

            CreateMap<SeatDTO, Seat>();
            CreateMap<Seat, SeatDTO>();

            CreateMap<MovieDTO, Movie>();
            CreateMap<Movie, MovieDTO>();

            CreateMap<SessionDTO, Session>();
            //.ForMember(a => a.Movie, opt => opt.MapFrom(b => b.NameMovie));

            //CreateMap<SessionDTO, Session>();
            CreateMap<Session, SessionDTO>()
                .ForMember(a => a.NameMovie, opt => opt.MapFrom(b => b.Movie.Name))
                .ForMember(a => a.GenreMovie, opt => opt.MapFrom(b => b.Movie.Genre))
                .ForMember(a => a.DurationMovie, opt => opt.MapFrom(b => b.Movie.Duration))
                .ForMember(a => a.NumberHall, opt => opt.MapFrom(b => b.CinemaHall.Number))
                .ForMember(a => a.Seats, opt => opt.MapFrom(b => b.CinemaHall.Seats));
        }
    }
}
