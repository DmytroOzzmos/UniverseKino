using System;
using System.Linq;
using System.Reflection;
using Autofac;
using AutoMapper;
using Microsoft.Extensions.Logging;
using UniverseKino.Core;
using UniverseKino.Data;
using UniverseKino.Data.EF;
using UniverseKino.Data.Entities;
using UniverseKino.Data.Interfaces;
using UniverseKino.Data.Repositories;
using UniverseKino.Services.Services;
using UniverseKino.Services.Interfaces;

namespace UniverseKino.Services
{
    public class ServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {


            builder.RegisterModule<DataModule>();
            builder.RegisterType<AuthService>().As<IAuthService>();
            

            builder.RegisterType<ViewInfoService>().As<IViewInfoService>();
            builder.RegisterType<CheckService>().As<ICheckService>();
            builder.RegisterType<ManageMoviesService>().As<IManageMoviesService>();

            builder.RegisterType<InfoMoviesService>()
                .As<IInfoMoviesService>();

            builder.RegisterType<InfoSessionsService>()
                .As<IInfoSessionsService>();

            //builder.Register(x => new InfoMoviesService(
            //    x.Resolve<IUnitOfWorkEntities>(),
            //    x.Resolve<IMapper>()))
            //    .As<IInfoMoviesService>();

            //builder.Register(x => new InfoSessionsService(
            //    x.Resolve<IUnitOfWorkEntities>(),
            //    x.Resolve<IMapper>()))
            //    .As<IInfoSessionsService>();
        }

    }
}