using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolrProducts.Search.Defaults;
using SolrProducts.Search.Queries;
using SolrNet;

namespace SolrProducts.Search.Converters
{
    public static class FilterConverter
    {
        public static ICollection<ISolrQuery> GetSolrNetFilters(Query query, out string facetExclusion)
        {
            facetExclusion = null;
            if (query.Filters != null && query.Filters.Any())
            {
                var filters = new List<ISolrQuery>();
                for (int i = 0; i < query.Filters.Count(); i++)
                {
                    var filter = query.Filters.ElementAt(i);
                    ISolrQuery solrQuery = new SolrQueryInList(filter.Name, filter.Values);

                    if (i == query.Filters.Count() - 1)
                    {
                        var localParams = new LocalParams(new Dictionary<string, string> {
                            {
                                "tag",
                                DefaultSettings.DefaultExcludePrefix + filter.Name
                            } });
                        solrQuery = new LocalParams.LocalParamsQuery(solrQuery, localParams);
                        facetExclusion = filter.Name;
                    }
                        
                    filters.Add(solrQuery);
                }

                return filters;
            }

            return null;
        } 
    }
}
