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
using UniverseKino.Services.Services;

namespace UniverseKino.Services
{
    public class ServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {


            builder.RegisterModule<DataModule>();
            builder.RegisterType<AuthService>().As<IAuthService>();
            //builder.RegisterType<InfoMoviesService>().As<IInfoMoviesService>();

            //builder.Register(x =>
            //{
            //    var rep = new GenericRepository<Movie>(x.Resolve<UniverseKinoContext>());
            //    var serv = new InfoMoviesService(
            //         rep,
            //         x.Resolve<IMapper>()
            //          );
            //    return serv;
            //}
            //)
            //         .As<IInfoMoviesService>();


            // builder.Register(x =>
            // new AuthService(x.Resolve<ApplicationContext>()))
            //     .As<IAuthService>();

            builder.RegisterType<ViewInfoService>().As<IViewInfoService>();
            builder.RegisterType<CheckService>().As<ICheckService>();
            
            builder.Register(x => new ManageMoviesService(
                    x.Resolve<IUnitOfWorkEntities>(),
                    x.Resolve<IMapper>(),
                    x.Resolve<ICheckService>()))
                .As<IManageMoviesService>();

            //builder.Register(x =>
            //{
            //    var rep = x.Resolve<UnitOfWork>().Movies;
            //    var serv = new InfoMoviesService(
            //         rep,
            //         x.Resolve<IMapper>()
            //          );
            //    return serv;
            //}
            //)
            //         .As<IInfoMoviesService>();

            builder.Register(x => new InfoMoviesService(
                    x.Resolve<IUnitOfWorkEntities>(),
                    x.Resolve<IMapper>()))
                .As<IInfoMoviesService>();

            builder.Register(x => new InfoSessionsService(
                    x.Resolve<IUnitOfWorkEntities>(),
                    x.Resolve<IMapper>()))
                .As<IInfoSessionsService>();
        }

    }
}