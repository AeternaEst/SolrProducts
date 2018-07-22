using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolrProducts.IoC.Ninject.Bootstrap;
using SolrProducts.Logic.Interfaces;
using SolrProducts.Logic.Services;
using Ninject;

namespace SolrProducts.IoC.Ninject.CustomResolvers
{
    public class MvcResolver : System.Web.Mvc.IDependencyResolver
    {
        protected IKernel Kernel;

        public MvcResolver(IKernel kernel)
        {
            Kernel = kernel;
        }

        public object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var resolved = Kernel.GetAll(serviceType).ToList();

            if (resolved.Any())
                return resolved; ;

            return resolved.DefaultIfEmpty();
        }
    }
}
