using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using SolrProducts.Search.Defaults;
using SolrProducts.Search.Documents;
using SolrProducts.Search.Facets;
using SolrProducts.Search.Queries;
using SolrNet;

namespace SolrProducts.Search.Converters
{
    public static class ResultConverter
    {
        public static QueryResult<Product> GetQueryResult(SolrQueryResults<Product> results)
        {
            var convertedResults = new QueryResult<Product>();
            if (results.Header.Status == 0)
            {
                convertedResults.Success = true;
                convertedResults.Results = results;
                convertedResults.TotalResults = results.NumFound;

                convertedResults.FacetResults = results.FacetFields.Select(x =>
                    new FacetResult
                    {
                        FacetName = x.Key,
                        Results = x.Value
                    });

                convertedResults.AvailableSorting = DefaultSettings.DefaultSortOrders;
                convertedResults.Highlights = results.Highlights != null && results.Highlights.Any()
                    ? results.Highlights?.Select(x => new Highlight.Highlight
                    {
                        DocumentId = x.Key,
                        Snippet = x.Value.Snippets?.FirstOrDefault().Value?.FirstOrDefault()
                    })
                    : null;

                return convertedResults;
            }

            convertedResults.Success = false;
            return null;
        } 
    }
}
