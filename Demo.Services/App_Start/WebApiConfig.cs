using Demo.Data;
using Demo.Repository;
using Demo.Services.Infrastructure;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Demo.Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new CustomExceptionFilterAttribute());


            string dataPath = HttpContext.Current.Server.MapPath($@"~/{ConfigurationManager.AppSettings["dataPath"]}");

            var container = new UnityContainer();
            container.RegisterType<ICandidateRepository, JsonCandidateRepository>(new InjectionFactory(c => new JsonCandidateRepository(dataPath)));
            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);
             config.DependencyResolver = new UnityResolver(container);
        }
    }
}
