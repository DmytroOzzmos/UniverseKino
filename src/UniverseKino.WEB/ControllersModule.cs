using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using AutoMapper;
using UniverseKino.Core;
using UniverseKino.Services;
using UniverseKino.WEB.Models;
using UniverseKino.WEB;
using UniverseKino.Services.Services;
using UniverseKino.Services;

namespace UniverseKino.WEB
{
    public class ControllersModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // builder.RegisterInstance
            builder.Register(x => new MappingProfile());
            builder.Register(x => new PasswordHasher());
            builder.RegisterType<MappingProfile>();
            builder.RegisterType<ServicesMappingProfile>();
            // ServiceMappingProfile
            // builder.Build();
            var arr = new List<Profile> { };
            // builder.Register(x => new AuthController(x.Resolve<IMapper>()));
            builder.Register(x =>
                        new MapperConfiguration(mc =>
                       mc.AddProfiles(new List<Profile>
                       {
                            x.Resolve<MappingProfile>(),
                            x.Resolve<ServicesMappingProfile>()
                       }
                           )
                        ).CreateMapper()
            )
            .As<IMapper>();           // builder.RegisterType<Profile>();

            builder.RegisterModule<ServicesModule>();

            // builder.Register(x => )
        }

    }
}