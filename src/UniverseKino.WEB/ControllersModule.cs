using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using UniverseKino.Core;
using UniverseKino.Services;

namespace UniverseKino.WEB
{
    public class ControllersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            

            
            // var types = builder.ComponentRegistry.Registrations
            //      .Where(r => typeof(IMapperProfile).IsAssignableFrom(r.Activator.LimitType))
            //      .Select(r => r.Activator.LimitType);
            // // builder.Register(c => new ValuesService(c.Resolve<ILogger<ValuesService>>()))
            //     .As<IValuesService>()
            //     .InstancePerLifetimeScope();
            builder.RegisterModule<ServicesModule>();

        }

    }
}