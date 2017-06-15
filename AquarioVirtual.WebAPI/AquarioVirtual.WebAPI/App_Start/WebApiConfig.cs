using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Practices.Unity;
using AquarioVirtual.Domain.Interfaces;
using AquarioVirtual.Utils.Helpers;
using AquarioVirtual.Infra.Repositories;

namespace AquarioVirtual.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var container = new UnityContainer();
            container.RegisterType<IArtigoRepository, ArtigoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUsuarioRepository, UsuarioRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICategoriaRepository, CategoriaRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPeixeRepository, PeixeRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
