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

namespace UniverseKino.WEB
{
    public class ControllersModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.Register(x => new PasswordHasher());

            builder.RegisterModule<ServicesModule>();

        }

    }
}