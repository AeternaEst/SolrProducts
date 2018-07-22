using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using SolrProducts.Search.Converters;
using SolrProducts.Search.Queries;

namespace SolrProducts.Logic.ModelBinders
{
    public class CustomSearchModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof (Query))
            {
                var queryString = actionContext.Request.GetQueryNameValuePairs()?.ToList();
                if (queryString != null)
                {
                    var result = QueryConverter.ConvertToQuery(queryString);

                    bindingContext.Model = result;
                    return true;
                }
            }

            return false;
        }
    }
}
