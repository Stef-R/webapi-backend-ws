using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

using Backend.WebApi.Controllers;
using static Backend.WebApi.Controllers.ProductsController;

namespace Backend.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Reg filter
            config.Filters.Add(new VerisionCheckFilter());

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            config.Services.Replace(typeof(IExceptionHandler), new NotFoundHandler());
        }
    }
}
