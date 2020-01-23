using System.Net.Mime;
using AutoMapper;
using System;
using UniverseKino.Core;
using UniverseKino.Services;
using UniverseKino.Data.Entities;

namespace UniverseKino.Services
{
    public class MappingProfile : MapperProfileConfig
    {
        public MappingProfile()
        {
            CreateMap<RegistrationRequestDTO, ApplicationUser>();
            //CreateMap<RegistrationRequestView, RegistrationRequestDTO>();
            //CreateMap<RegistrationRequestView, RegistrationRequestDTO>();
            //CreateMap<CreateLotDTO, Lot>();
        }
    }
}
