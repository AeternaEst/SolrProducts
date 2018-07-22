using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolrProducts.IoC.Ninject.Bootstrap;
using Ninject;
using System.Web.Http.Dependencies;

namespace SolrProducts.IoC.Ninject.CustomResolvers
{
    public class ApiResolver : IDependencyResolver
    {
        protected IKernel Kernel;

        public ApiResolver(IKernel kernel)
        {
            Kernel = kernel;
        }

        public void Dispose()
        {

        }

        public object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var resolved = Kernel.GetAll(serviceType).ToList<object>();

            if (resolved.Any())
                return resolved;

            return Enumerable.Empty<object>();
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }
    }
}
