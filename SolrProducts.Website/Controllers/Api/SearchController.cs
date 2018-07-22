using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SolrProducts.Logic.Interfaces;
using SolrProducts.Logic.ModelBinders;
using SolrProducts.Logic.Services;
using SolrProducts.Search.Converters;
using SolrProducts.Search.Filters;
using SolrProducts.Search.Index;
using SolrProducts.Search.Queries;

namespace SolrProducts.Controllers.Api
{
    [System.Web.Http.RoutePrefix("search")]
    public class SearchController : ApiController
    {
        protected ISearcher Searcher;
        protected IService Service;

        public SearchController(IService service, ISearcher searcher)
        {
            Service = service;
            Searcher = searcher;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult Search([System.Web.Http.ModelBinding.ModelBinder(typeof(CustomSearchModelBinder))]Query query)
        {
            var results = Searcher.Search(query);

            return Ok(results);
        }

        [Route("di")]
        [HttpGet]
        public IHttpActionResult Di()
        {
            var model = Service.HelloWorld();

            return Ok(model + " Web API");
        }
    }
}