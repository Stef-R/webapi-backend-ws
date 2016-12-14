using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Backend.WebApi;
using Backend.WebApi.Controllers;

namespace Backend.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ProductsController prodCrlt = new ProductsController();
            prodCrlt.InitializeSample();
        }
    }
}
