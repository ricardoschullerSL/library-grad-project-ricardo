﻿using Autofac;
using Autofac.Integration.WebApi;
using LibraryGradProject.Models;
using LibraryGradProject.Repos;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System;
using System.Data.Entity;

namespace LibraryGradProject
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            // Autofac
            var builder = new ContainerBuilder();            

            // Register Web API controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register types
            builder.RegisterType<BookRepository>().As<IRepository<Book>>().SingleInstance();
            builder.RegisterType<BookReservationRepository>().As<IRepository<BookReservation>>().SingleInstance();
            builder.RegisterType<DbContextFactory>().As<DbContextFactory>().SingleInstance();
            // Set the dependency resolver to be Autofac
            var container = builder.Build();
            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
