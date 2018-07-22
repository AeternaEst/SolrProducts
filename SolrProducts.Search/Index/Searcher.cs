using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolrProducts.Search.Converters;
using SolrProducts.Search.Defaults;
using SolrProducts.Search.Documents;
using SolrProducts.Search.Facets;
using SolrProducts.Search.Queries;
using CommonServiceLocator;
using SolrNet;
using SolrNet.Commands.Parameters;

namespace SolrProducts.Search.Index
{
    public class Searcher : ISearcher
    {
        protected ISolrOperations<Product> SolrOperations;

        public Searcher()
        {
            SolrOperations = ServiceLocator.Current.GetInstance<ISolrOperations<Product>>();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var query = SolrQuery.All;

            var results = SolrOperations.Query(query);

            return results;
        }

        public QueryResult<Product> Search(Query query)
        {
            var options = new QueryOptions();

            AbstractSolrQuery q = new SolrQuery(!string.IsNullOrEmpty(query.SearchText) ? query.SearchText : "*");
            options.ExtraParams = new[] { new KeyValuePair<string, string>("df", "description") };

            options.Rows = query.NumToReturn ?? DefaultSettings.DefaultNumToReturn;
            options.StartOrCursor = OffsetConverter.GetOffsetFromCurrentPage(query.Page);

            options.OrderBy = SortOrderConverter.GetSortOrder(query);

            string facetToExclude;
            options.FilterQueries = FilterConverter.GetSolrNetFilters(query, out facetToExclude);

            options.Facet = FacetConverter.GetSolrNetFacetParameters(query, facetToExclude);

            options.Highlight = HighlightConverter.GetSolrNetHighlightingParameters(query.SearchText);

            var results = SolrOperations.Query(q, options);

            var convertedResults = ResultConverter.GetQueryResult(results);

            if (convertedResults == null)
            {
                convertedResults.ErrorMessages = new[] { "An error occured communicating with the solr instance" };
            }
            
            return convertedResults;
        } 
    }
}
