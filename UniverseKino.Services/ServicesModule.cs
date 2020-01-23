using Autofac;
using Microsoft.Extensions.Logging;
using UniverseKino.Data;
using UniverseKino.Data.EF;

namespace UniverseKino.Services
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            
            builder.RegisterModule<DataModule>();

            builder.Register(c => new AuthService(c.Resolve<ApplicationContext>()))
                .As<IAuthService>()
                //.InstancePerLifetimeScope();
                .InstancePerLifetimeTransient();

        }

    }
}