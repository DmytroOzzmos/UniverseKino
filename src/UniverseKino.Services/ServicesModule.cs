using Autofac;
using AutoMapper;
using Microsoft.Extensions.Logging;
using UniverseKino.Core;
using UniverseKino.Data;
using UniverseKino.Data.EF;

namespace UniverseKino.Services
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var mappingConfig = new MapperConfiguration(mc =>
               {
                   mc.AddProfile(new MappingProfile());
               });


            var a = new MappingProfile();
            builder.RegisterModule<DataModule>();

            builder.Register(x =>
            new AuthService(x.Resolve<ApplicationContext>(),
                mappingConfig.CreateMapper())
                )
                .As<IAuthService>()
            .InstancePerDependency();


        }

    }
}