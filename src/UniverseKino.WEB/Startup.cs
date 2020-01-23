using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using UniverseKino.Core;

namespace UniverseKino.WEB
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; private set; }

        public void Configure(IApplicationBuilder app)
        {
            app.
            app.UseMvc();
            
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Add any Autofac modules or registrations.
            // This is called AFTER ConfigureServices so things you
            // register here OVERRIDE things registered in ConfigureServices.
            //
            // You must have the call to AddAutofac in the Program.Main
            // method or this won't be called.

            builder.RegisterModule(new ControllersModule());

            //var list = new List<Type>();
            //foreach (Type mytype in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
            //    .Where(mytype => mytype.GetInterfaces().Contains(typeof(IMapperProfile))))
            //{
            //    builder.RegisterType(mytype);

            //    list.Add(mytype);
            //}

            //var container = builder.Build();

            //foreach (var mapProfile in list)
            //{
            //    container.Resolve(mapProfile);
            //}
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Use extensions from libraries to register services in the
            // collection. These will be automatically added to the
            // Autofac container.
            //
            // Note if you have this method return an IServiceProvider
            // then ConfigureContainer will not be called.
            services.AddMvc();
        }
    }
}
