using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using SolrProducts.IoC.Ninject.CustomResolvers;
using SolrProducts.Logic.Interfaces;
using SolrProducts.Logic.Services;
using Ninject;
using Ninject.Web.Mvc;
using SolrProducts.Search.Index;

namespace SolrProducts.IoC.Ninject.Bootstrap
{
    public static class Setup
    {
        public static IKernel SetupKernel()
        {
            var kernel = new StandardKernel();

            kernel.Bind<IService>().To<Service>();
            kernel.Bind<ISearcher>().To<Searcher>();

            return kernel;
        }

        public static void InitCustomResolvers()
        {
            var kernel = SetupKernel();

            System.Web.Mvc.DependencyResolver.SetResolver(new MvcResolver(kernel));
            GlobalConfiguration.Configure(config => config.DependencyResolver = new ApiResolver(kernel));
        }

        public static void InitNinjectResolvers()
        {
            var kernel = SetupKernel();

            System.Web.Mvc.DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            GlobalConfiguration.Configure(config => config.DependencyResolver = new ApiResolver(kernel));
        }
    }
}
