using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using System.Web.Routing;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using SolrProducts.Logic.Interfaces;
using SolrProducts.Logic.Services;
using Ninject;
using Ninject.Web.Mvc;

namespace SolrProducts
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(x => x.MapHttpAttributeRoutes());
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }     
}
