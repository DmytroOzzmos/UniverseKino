using AutoMapper;
using System;
using UniverseKino.Core;
using UniverseKino.Services;
using UniverseKino.WEB.Models;

namespace UniverseKino.WEB
{
    public class MappingProfile : Profile, IMapperProfile
    {
        public MappingProfile()
        {

            CreateMap<RegistrationRequestView, RegistrationRequestDTO>();
            CreateMap<TokenResponseView, TokenResponseDTO>();
            CreateMap<LoginRequestView, LoginRequestDTO>();
            //CreateMap<RegistrationRequestView, RegistrationRequestDTO>();
            //CreateMap<CreateLotDTO, Lot>();
        }
    }
}
