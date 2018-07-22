using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolrProducts.Search.Defaults;
using SolrProducts.Search.Filters;
using SolrProducts.Search.Queries;
using SolrProducts.Search.Sorting;

namespace SolrProducts.Search.Converters
{
    public static class QueryConverter
    {
        public static Query ConvertToQuery(List<KeyValuePair<string, string>> queryString)
        {
            var searchText = queryString.FirstOrDefault(x => x.Key == "SearchText").Value;
            var queryStringFilters = queryString.FirstOrDefault(x => x.Key == "Filters");
            var page = queryString.FirstOrDefault(x => x.Key == "Page").Value;
            var sortOrder = queryString.FirstOrDefault(x => x.Key == "SortOrder").Value;

            var queryFilters = new List<Filter>();
            if (!string.IsNullOrEmpty(queryStringFilters.Value))
            {
                var filters = queryStringFilters.Value.Split(new char[] { '|' });
                if (filters.Length > 0)
                {
                    foreach (var filter in filters)
                    {
                        var specificFilter = filter.Split(new char[] { '=' });
                        if (specificFilter.Length == 2)
                        {
                            var f = new Filter { Name = specificFilter[0] };
                            var filterList = new List<string>();
                            var filterValues = specificFilter[1].Split(new char[] { ',' });
                            foreach (var filterValue in filterValues)
                            {
                                filterList.Add(filterValue);
                            }
                            f.Values = filterList;
                            queryFilters.Add(f);
                        }
                    }
                }
            }

            int? goToPage = null;
            int parsedPageResult;
            if (!string.IsNullOrEmpty(page) && int.TryParse(page, out parsedPageResult))
            {
                if (parsedPageResult >= 1)
                    goToPage = parsedPageResult;
            }

            SortOrder order = null;
            if (!string.IsNullOrEmpty(sortOrder))
            {
                var orderKeyAndValue = sortOrder.Split(new[] {'='});
                if (orderKeyAndValue.Length == 2)
                {
                    order = new SortOrder
                    {
                        SortField = orderKeyAndValue[0],
                        Direction = orderKeyAndValue[1] == "desc" ? Direction.Descending : Direction.Ascending
                    };
                }
            }

            var myQuery = new Query
            {
                NumToReturn = DefaultSettings.DefaultNumToReturn,
                SearchText = searchText,
                Filters = queryFilters,
                Facets = DefaultSettings.DefaultFacets,
                Page = goToPage,
                SortOrder = order
            };

            return myQuery;
        }
    }
}
