using System;
using System.Linq;
using System.Reflection;
using Autofac;
using AutoMapper;
using Microsoft.Extensions.Logging;
using UniverseKino.Core;
using UniverseKino.Data;
using UniverseKino.Data.EF;
using UniverseKino.Data.Interfaces;
using UniverseKino.Services.Services;

namespace UniverseKino.Services
{
    public class ServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {


            builder.RegisterModule<DataModule>();
            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<InfoMoviesService>().As<IInfoMoviesService>();
            builder.Register(x => new InfoMoviesService(
                    x.Resolve<IUnitOfWorkEntities>(),
                     x.Resolve<IMapper>()
                     ))
                     .As<InfoMoviesService>();
            // builder.Register(x =>
            // new AuthService(x.Resolve<ApplicationContext>()))
            //     .As<IAuthService>();


        }

    }
}