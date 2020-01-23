using AutoMapper;
using System;
using UniverseKino.Core;
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
}
