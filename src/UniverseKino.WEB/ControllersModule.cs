using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using AutoMapper;
using UniverseKino.Core;
using UniverseKino.Services;

namespace UniverseKino.WEB
{
    public class ControllersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            var mappingConfig = new MapperConfiguration(mc =>
                           {
                               mc.AddProfile(new MappingProfile());
                           });
            //      .Select(r => r.Activator.LimitType);
            // // builder.Register(c => new ValuesService(c.Resolve<ILogger<ValuesService>>()))
            //     .As<IValuesService>()
            //     .InstancePerLifetimeScope();

            builder.RegisterModule<ServicesModule>();
            builder.RegisterInstance(mappingConfig.CreateMapper());

        }

    }
}