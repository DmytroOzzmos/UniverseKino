using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using UniverseKino.Core;
using UniverseKino.Services;

namespace UniverseKino.WEB
{
    public class ControllersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            

            //      .Select(r => r.Activator.LimitType);
            // // builder.Register(c => new ValuesService(c.Resolve<ILogger<ValuesService>>()))
            //     .As<IValuesService>()
            //     .InstancePerLifetimeScope();
            builder.RegisterModule<ServicesModule>();

        }

    }
}