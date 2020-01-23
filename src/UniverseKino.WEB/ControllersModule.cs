using Autofac;
using UniverseKino.Services;

namespace UniverseKino.WEB
{
    public class ControllersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            // builder.Register(c => new ValuesService(c.Resolve<ILogger<ValuesService>>()))
            //     .As<IValuesService>()
            //     .InstancePerLifetimeScope();
            builder.RegisterModule<ServicesModule>();

        }

    }
}